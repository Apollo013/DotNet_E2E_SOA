using Core.Common.Contracts;
using Prism.Mvvm;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.Serialization;
using FluentValidation;
using FluentValidation.Results;
using System.Text;

namespace Core.Common.Core
{
    public abstract class ObjectBase : NotificationObject, IDirtyCapable, IExtensibleDataObject, IDataErrorInfo
    {
        public ObjectBase()
        {
            _Validator = GetValidator();
            Validate();
        }

        #region 'IExtensibleDataObject' implementation
        [NonNavigable]
        public ExtensionDataObject ExtensionData { get; set; }
        #endregion

        #region 'PropertyChangedEventHandler' implementation
        /// <summary>
        /// Keeps track of all properties that have changed values (dirty)
        /// </summary>
        List<PropertyChangedEventHandler> _PropertyChangedSubscribers = new List<PropertyChangedEventHandler>();

        /// <summary>
        /// Property Changed Event Handler that ensures multiple event handlers are not created for the same property
        /// </summary>
        private event PropertyChangedEventHandler _PropertyChanged;
        public event PropertyChangedEventHandler PropertyChanged
        {
            add
            {
                if (!_PropertyChangedSubscribers.Contains(value))
                {
                    _PropertyChanged += value;
                    _PropertyChangedSubscribers.Add(value);
                }
            }
            remove
            {
                _PropertyChanged -= value;
                _PropertyChangedSubscribers.Remove(value);
            }
        }

        /// <summary>
        /// Event Handler that provides compile-time safety check
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="propertyExpression"></param>
        protected virtual void OnPropertyChanged<T>(Expression<Func<T>> propertyExpression)
        {
            string propertyName = PropertySupport.ExtractPropertyName(propertyExpression);
            OnPropertyChanged(propertyName);
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            OnPropertyChanged(propertyName, true);
        }

        protected virtual void OnPropertyChanged(string propertyName, bool isDirty)
        {
            if (_PropertyChanged != null)
            {
                _PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }

            if (isDirty)
            {
                _IsDirty = true;
            }
        }
        #endregion
               
        #region 'Dirty Objects' implementation
        /// <summary>
        /// Determines if this object is dirty
        /// </summary>
        private bool _IsDirty;
        [NonNavigable]
        public bool IsDirty
        {
            get { return _IsDirty; }
            set { _IsDirty = value; }
        }

        /// <summary>
        /// Gets a list of all dirty objects including both the parent object & it's children
        /// </summary>
        /// <returns></returns>
        public virtual List<ObjectBase> GetDirtyObjects()
        {
            List<ObjectBase> dirtyObjects = new List<ObjectBase>();

            WalkObjectGraph((o) =>
            {
                if (o.IsDirty)
                {
                    dirtyObjects.Add(o);
                }
                return false;
            }, coll => { });

            return dirtyObjects;
        }

        /// <summary>
        /// Flags current object and it's properties as non-dirty (clean)
        /// </summary>
        public virtual void CleanAll()
        {
            WalkObjectGraph((o) =>
            {
                if (o.IsDirty)
                {
                    o.IsDirty = false;
                }
                return false;
            }, coll => { });
        }

        /// <summary>
        /// Determines if ANY properties are dirty
        /// </summary>
        /// <returns></returns>
        public virtual bool IsAnythingDirty()
        {
            bool isDirty = false;

            WalkObjectGraph((o) =>
            {
                if (o.IsDirty)
                {
                    isDirty = true;
                    return true; // Short Circuit
                }
                else
                {
                    return false;
                }
            }, coll => { });

            return isDirty;
        }

        /// <summary>
        /// Checks the current object and it's children to see if they are dirty
        /// </summary>
        /// <returns></returns>
        protected void WalkObjectGraph(Func<ObjectBase, bool> snippetForObject, Action<IList> snippetForCollection, params string[] exemptProperties)
        {

            // Walk the object hierarchy graph and discover any dirty objects
            List<ObjectBase> visited = new List<ObjectBase>();
            Action<ObjectBase> walk = null;
            List<string> exemptions = new List<string>();

            if (exemptProperties != null)
            {
                exemptions = exemptProperties.ToList();
            }

            walk = (o) =>
            {
                if (o != null && !visited.Contains(o))
                {
                    visited.Add(o);

                    bool exitWalk = snippetForObject.Invoke(o);

                    if (!exitWalk)
                    {
                        // Use reflection to get all properties
                        PropertyInfo[] properties = o.GetBrowsableProperties();
                        foreach (PropertyInfo property in properties)
                        {
                            if (!exemptions.Contains(property.Name))
                            {
                                // Check if this property is a sub class, and walk it's properties
                                if (property.PropertyType.IsSubclassOf(typeof(ObjectBase)))
                                {

                                    ObjectBase obj = (ObjectBase)(property.GetValue(o, null));
                                    walk(obj);
                                }
                                else
                                {
                                    // Walk the properties of this object if it is a collection
                                    IList collection = property.GetValue(o, null) as IList;
                                    if (collection != null)
                                    {
                                        snippetForCollection.Invoke(collection);

                                        foreach (object item in collection)
                                        {
                                            if (item is ObjectBase)
                                            {
                                                walk((ObjectBase)item);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            };
        }
        #endregion

        #region 'IValidator' Implementation
        protected IValidator _Validator = null;
        protected abstract IValidator GetValidator();
        protected IEnumerable<ValidationFailure> _ValidationErrors = null;

        protected void Validate()
        {
            if (_Validator != null)
            {
                ValidationResult results = _Validator.Validate(this);
                _ValidationErrors = results.Errors;
            }
        }

        [NonNavigable]
        public virtual bool IsValid
        {
            get
            {
                return (_ValidationErrors.Any()) ? false : true;
            }
        }
        #endregion

        #region 'IDataErrorInfo' impementation (WPF Validation)
        [NonNavigable]
        public string Error { get { return String.Empty; } }

        [NonNavigable]
        public string this[string columnName]
        {
            get
            {
                var errors = new StringBuilder();

                if (_ValidationErrors != null && _ValidationErrors.Any())
                {
                    foreach (ValidationFailure validationError in _ValidationErrors)
                    {
                        if (validationError.PropertyName == columnName)
                        {
                            errors.AppendLine(validationError.ErrorMessage);
                        }                            
                    }
                }
                return errors.ToString();
            }
        }
        #endregion
    }
}
