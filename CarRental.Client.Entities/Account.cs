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

        private string _LoginEmail = String.Empty;

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

        private string _FirstName = String.Empty;

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

        private string _LastName = String.Empty;

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

        private string _Address = String.Empty;

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

        private string _City = String.Empty;

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

        private string _State = String.Empty;

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

        private string _ZipCode = String.Empty;

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

        private string _CreditCard = String.Empty;

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

        private string _ExpDate = String.Empty;

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
        class AccountValidator : AbstractValidator<Account>
        {
            public AccountValidator()
            {
                RuleFor(obj => obj.LoginEmail).NotEmpty();
                RuleFor(obj => obj.FirstName).NotEmpty();
                RuleFor(obj => obj.LastName).NotEmpty();
                RuleFor(obj => obj.Address).NotEmpty();
                RuleFor(obj => obj.State).NotEmpty();
                RuleFor(obj => obj.ZipCode).NotEmpty();
            }
        }

        protected override IValidator GetValidator()
        {
            return new AccountValidator();
        }
        #endregion
    }
}
