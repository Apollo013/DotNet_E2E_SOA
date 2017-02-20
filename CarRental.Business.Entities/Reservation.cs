using Core.Common.Contracts;
using Core.Common.Core;
using System;
using System.Runtime.Serialization;

namespace CarRental.Business.Entities
{
    [DataContract]
    public class Reservation : EntityBase, IIdentifiableEntity, IAccountOwnedEntity
    {
        #region Properties
        public int ReservationId { get; set; }
        public int AccountId { get; set; }
        public int CarId { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime ReturnDate { get; set; }
        #endregion

        #region 'IIdentifiableEntity' implementation
        [IgnoreDataMember]
        public int EntityId
        {
            get { return ReservationId; }
            set { ReservationId = value; }
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
