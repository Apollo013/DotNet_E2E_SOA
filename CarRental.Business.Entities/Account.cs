using Core.Common.Contracts;
using Core.Common.Core;
using System.Runtime.Serialization;

namespace CarRental.Business.Entities
{
    [DataContract]
    public class Account : EntityBase, IIdentifiableEntity
    {
        #region Properties
        public int AccountId { get; set; }
        public string LoginEmail { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string CreditCard { get; set; }
        public string ExpDate { get; set; }
        #endregion

        #region 'IIdentifiableEntity' implementation
        [IgnoreDataMember]
        public int EntityId
        {
            get { return AccountId; }
            set { AccountId = value; }
        }
        #endregion
    }
}
