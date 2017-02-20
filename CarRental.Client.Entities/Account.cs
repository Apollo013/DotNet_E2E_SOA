using Core.Common.Core;
using FluentValidation;
using System;

namespace CarRental.Client.Entities
{
    public class Account : ObjectBase
    {
        #region Properties
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

        private string _LoginEmail;

        public string LoginEmail
        {
            get { return _LoginEmail; }
            set
            {
                if (!_LoginEmail.Equals(value))
                {
                    _LoginEmail = value;
                    OnPropertyChanged(() => LoginEmail);
                }
            }
        }

        private string _FirstName;

        public string FirstName
        {
            get { return _FirstName; }
            set
            {
                if (!_FirstName.Equals(value))
                {
                    _FirstName = value;
                    OnPropertyChanged(() => FirstName);
                }
            }
        }

        private string _LastName;

        public string LastName
        {
            get { return _LastName; }
            set
            {
                if (!_LastName.Equals(value))
                {
                    _LastName = value;
                    OnPropertyChanged(() => LastName);
                }
            }
        }

        private string _Address;

        public string Address
        {
            get { return _Address; }
            set
            {
                if (!_Address.Equals(value))
                {
                    _Address = value;
                    OnPropertyChanged(() => Address);
                }
            }
        }

        private string _City;

        public string City
        {
            get { return _City; }
            set
            {
                if (!_City.Equals(value))
                {
                    _City = value;
                    OnPropertyChanged(() => City);
                }
            }
        }

        private string _State;

        public string State
        {
            get { return _State; }
            set
            {
                if (!_State.Equals(value))
                {
                    _State = value;
                    OnPropertyChanged(() => State);
                }
            }
        }

        private string _ZipCode;

        public string ZipCode
        {
            get { return _ZipCode; }
            set
            {
                if (!_ZipCode.Equals(value))
                {
                    _ZipCode = value;
                    OnPropertyChanged(() => ZipCode);
                }
            }
        }

        private string _CreditCard;

        public string CreditCard
        {
            get { return _CreditCard; }
            set
            {
                if (!_CreditCard.Equals(value))
                {
                    _CreditCard = value;
                    OnPropertyChanged(() => CreditCard);
                }
            }
        }

        private string _ExpDate;

        public string ExpDate
        {
            get { return _ExpDate; }
            set
            {
                if (!_ExpDate.Equals(value))
                {
                    _ExpDate = value;
                    OnPropertyChanged(() => ExpDate);
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
