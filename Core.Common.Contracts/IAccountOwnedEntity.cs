using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Common.Contracts
{
    /// <summary>
    /// Implemented by business entities to determine the 'account id' column
    /// </summary>
    public interface IAccountOwnedEntity
    {
        int OwnerAccountId { get; }
    }
}
