using Core.Common.Core;
using System;
using FluentValidation;

namespace CarRental.Client.Entities
{
    public class Reservation : ObjectBase
    {
        #region Properties
        private int _ReservationId;

        public int ReservationId
        {
            get { return _ReservationId; }
            set
            {
                if (_ReservationId != value)
                {
                    _ReservationId = value;
                    OnPropertyChanged(() => ReservationId);
                }
            }
        }

        private int _AccountId;

        public int AccountId
        {
            get { return _AccountId; }
            set
            {
                if (_AccountId != value)
                {
                    _AccountId = value;
                    OnPropertyChanged(() => AccountId);
                }
            }
        }

        private int _CarId;

        public int CarId
        {
            get { return _CarId; }
            set
            {
                if (_CarId != value)
                {
                    _CarId = value;
                    OnPropertyChanged(() => CarId);
                }
            }
        }

        private DateTime _RentalDate;

        public DateTime RentalDate
        {
            get { return _RentalDate; }
            set
            {
                if (_RentalDate != value)
                {
                    _RentalDate = value;
                    OnPropertyChanged(() => RentalDate);
                }
            }
        }

        private DateTime _ReturnDate;

        public DateTime ReturnDate
        {
            get { return _ReturnDate; }
            set
            {
                if (_ReturnDate != value)
                {
                    _ReturnDate = value;
                    OnPropertyChanged(() => ReturnDate);
                }
            }
        }
        #endregion

        #region Validation
        protected override IValidator GetValidator()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
