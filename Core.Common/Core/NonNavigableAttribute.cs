using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Common.Core
{
    /// <summary>
    /// Flags a property to be ignored when performing dirty checks
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class NonNavigableAttribute : Attribute { }
}
