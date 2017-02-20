using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Common.Core;
using FluentValidation;

namespace Core.Common.Tests
{
    internal class TestClass : ObjectBase
    {
        protected string _CleanProp = string.Empty;
        protected string _DirtyProp = string.Empty;
        protected string _StringProp = string.Empty;
        TestChild _Child = new TestChild();
        TestChild _notNoavigableChild = new TestChild();

        public string CleanProp
        {
            get { return _CleanProp; }
            set
            {
                if (_CleanProp == value)
                    return;

                _CleanProp = value;
                OnPropertyChanged(() => CleanProp);
            }
        }

        public string DirtyProp
        {
            get { return _DirtyProp; }
            set
            {
                if (_DirtyProp == value)
                    return;

                _DirtyProp = value;
                OnPropertyChanged(() => DirtyProp);
            }
        }

        public string StringProp
        {
            get { return _StringProp; }
            set
            {
                if (_StringProp == value)
                    return;

                _StringProp = value;
                OnPropertyChanged("StringProp", false);
            }
        }

        public TestChild Child
        {
            get { return _Child; }
        }

        [NonNavigable]
        public TestChild NotNavigableChild
        {
            get { return _notNoavigableChild; }
        }

        class TestClassValidator : AbstractValidator<TestClass>
        {
            public TestClassValidator()
            {
                RuleFor(obj => obj.StringProp).NotEmpty();
            }
        }

        protected override IValidator GetValidator()
        {
            return new TestClassValidator();
        }
    }
}
