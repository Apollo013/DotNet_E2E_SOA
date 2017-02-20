using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Core.Common.Core
{
    /// <summary>
    /// Base class for all business side entities
    /// </summary>
    [DataContract]
    public abstract class EntityBase : IExtensibleDataObject
    {
        /// <summary>
        /// A data contract serializer that allows entities to become version tolerent
        /// </summary>
        public ExtensionDataObject ExtensionData { get ; set ; }
    }
}
