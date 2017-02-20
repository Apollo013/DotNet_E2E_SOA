using Core.Common.Contracts;
using Core.Common.Core;
using System;
using System.Runtime.Serialization;

namespace CarRental.Business.Entities
{
    [DataContract]
    public class Rental : EntityBase, IIdentifiableEntity, IAccountOwnedEntity
    {
        #region Properties
        public int RentalId { get; set; }
        public int AccountId { get; set; }
        public int CarId { get; set; }
        public DateTime DateRented { get; set; }
        public DateTime DateReturned { get; set; }
        public DateTime DateDue { get; set; }
        #endregion

        #region 'IIdentifiableEntity' implementation
        [IgnoreDataMember]
        public int EntityId {
            get { return RentalId; }
            set { RentalId = value; }
        }
        #endregion

        #region 'IAccountOwnedEntity' implementation
        [IgnoreDataMember]
        public int OwnerAccountId
        {
            get { return AccountId; }
        }
        #endregion
    }
}
