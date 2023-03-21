using MasterskayaOptronApplication.DbEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterskayaOptronApplication.ViewModel
{
    public class ApplicationViewModel : BaseViewModel
    {
        private string _firstName;
        private string _middleName;
        private string _lastName;
        private string _phone;

        #region может понадобится
        /*
        private string _login;
        private string _password;
          
        public string Login
        {
            get => _login;
            set
            {
                _login = value;
                OnPropertyChanged(nameof(Login));
            }
        }
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }*/
        #endregion
        public string FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }
        public string MiddleName
        {
            get => _middleName;
            set
            {
                _middleName = value;
                OnPropertyChanged(nameof(MiddleName));
            }
        }
        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }
        public string Phone
        {
            get => _phone;
            set
            {
                _phone = value;
                OnPropertyChanged(nameof(Phone));
            }
        }
        public ApplicationViewModel(User user)
        {
            FirstName = user.UserInfo.FirstName;
            MiddleName = user.UserInfo.MiddleName;
            LastName = user.UserInfo.LastName;
            Phone = user.UserInfo.Phone;
        }
    }
}
