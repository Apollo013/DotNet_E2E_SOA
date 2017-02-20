using Core.Common.Core;
using System;
using FluentValidation;

namespace CarRental.Client.Entities
{
    public class Rental : ObjectBase
    {
        #region Properties
        private int _RentalId;
        public int RentalId
        {
            get { return _RentalId; }
            set
            {
                if (_RentalId != value)
                {
                    _RentalId = value;
                    OnPropertyChanged(() => RentalId);
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

        private DateTime _DateRented;
        public DateTime DateRented
        {
            get { return _DateRented; }
            set
            {
                if (_DateRented != value)
                {
                    _DateRented = value;
                    OnPropertyChanged(() => DateRented);
                }
            }
        }

        private DateTime _DateReturned;
        public DateTime DateReturned
        {
            get { return _DateReturned; }
            set
            {
                if (_DateReturned != value)
                {
                    _DateReturned = value;
                    OnPropertyChanged(() => DateReturned);
                }
            }
        }

        private DateTime _DateDue;
        public DateTime DateDue
        {
            get { return _DateDue; }
            set
            {
                if (_DateDue != value)
                {
                    _DateDue = value;
                    OnPropertyChanged(() => DateDue);
                }
            }
        }
        #endregion

        #region Validation
        class RentalValidator : AbstractValidator<Rental>
        {
            public RentalValidator()
            {
                RuleFor(obj => obj.CarId).GreaterThan(0);
                RuleFor(obj => obj.AccountId).GreaterThan(0);
            }
        }
        protected override IValidator GetValidator()
        {
            return new RentalValidator();
        }
        #endregion
    }
}
