using System;
using Core.Common.Core;
using FluentValidation;

namespace CarRental.Client.Entities
{
    public class Car : ObjectBase
    {
        #region Properties
        private int _CarId;

        public int CarId
        {
            get { return _CarId; }
            set
            {
                if(_CarId != value)
                {
                    _CarId = value;
                    OnPropertyChanged(() => CarId);
                }                
            }
        }

        private string _Description = String.Empty;

        public string Description
        {
            get { return _Description; }
            set
            {
                if (!_Description.Equals(value))
                {
                    _Description = value;
                    OnPropertyChanged(() => Description);
                }
            }
        }

        private string _Color = String.Empty;

        public string Color
        {
            get { return _Color; }
            set
            {
                if (!_Color.Equals(value))
                {
                    _Color = value;
                    OnPropertyChanged(() => Color);
                }
            }
        }

        private int _Year;

        public int Year
        {
            get { return _Year; }
            set
            {
                if (_Year != value)
                {
                    _Year = value;
                    OnPropertyChanged(() => Year);
                }
            }
        }

        private decimal _RentalPrice;

        public decimal RentalPrice
        {
            get { return _RentalPrice; }
            set
            {
                if (!_RentalPrice.Equals(value))
                {
                    _RentalPrice = value;
                    OnPropertyChanged(() => RentalPrice);
                }
            }
        }

        private bool _CurrentlyRented;

        public bool CurrentlyRented
        {
            get { return _CurrentlyRented; }
            set
            {
                if (_CurrentlyRented != value)
                {
                    _CurrentlyRented = value;
                    OnPropertyChanged(() => CurrentlyRented);
                }
            }
        }
        #endregion

        #region Validation
        class CarValidator : AbstractValidator<Car>
        {
            public CarValidator()
            {
                RuleFor(obj => obj.Description).NotEmpty();
                RuleFor(obj => obj.Color).NotEmpty();
                RuleFor(obj => obj.RentalPrice).GreaterThan(0);
                RuleFor(obj => obj.Year).GreaterThan(2000).LessThanOrEqualTo(DateTime.Now.Year);
            }
        }

        protected override IValidator GetValidator()
        {
            return new CarValidator();
        }
        #endregion
    }
}
