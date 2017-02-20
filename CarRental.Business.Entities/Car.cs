using Core.Common.Contracts;
using Core.Common.Core;
using System.Runtime.Serialization;

namespace CarRental.Business.Entities
{
    [DataContract]
    public class Car : EntityBase , IIdentifiableEntity
    {
        #region Properties
        public int CarId { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
        public int Year { get; set; }
        public double RentalPrice { get; set; }
        public bool CurrentlyRented { get; set; }
        #endregion

        #region 'IIdentifiableEntity' implementation
        [IgnoreDataMember]
        public int EntityId {
            get { return CarId; } 
            set { CarId = value; }
        }
        #endregion
    }
}
