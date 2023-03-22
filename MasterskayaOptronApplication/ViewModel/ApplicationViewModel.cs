﻿using MasterskayaOptronApplication.DbEntity;
using MasterskayaOptronApplication.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MasterskayaOptronApplication.ViewModel
{
    public class ApplicationViewModel : BaseViewModel
    {
        private ObservableCollection<User> _users;
        private User _user;
        private bool _enableButton = true;
        /*private string _firstName;
        private string _middleName;
        private string _lastName;
        private string _phone;*/

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

        public bool EnableButton
        {
            get => _enableButton;
            set
            {
                _enableButton = value;
                OnPropertyChanged(nameof(EnableButton));
            }
        }

        public ObservableCollection<User> Users
        {
            get => _users;
            set
            {
                _users = value;
                OnPropertyChanged(nameof(Users));
            }
        }
        public User User
        {
            get => _user;
            set
            {
                _user = value;
                OnPropertyChanged(nameof(User));
            }
        }
        /*public string FirstName
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
        }*/

        public bool CheckAdmin()
        {
            /*if(User.UserInfo.UserStatus.Name == "admin")
            {
                MessageBox.Show("Этот пользователь Админ", "тест", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else MessageBox.Show("Этот пользователь Не админ", "тест", MessageBoxButton.OK, MessageBoxImage.Information);*/

            return User.UserInfo.UserStatus.Name == "admin";
        }

        public void LoadData()
        {
            var result = DbStorage.DB_s.User.ToList();
            result.ForEach(element => Users?.Add(element));
        }

        public void OpenAdminPanel()
        {
            var adminPanel = new AdminPanelWindow(User);
            adminPanel.Show();
        }

        public ApplicationViewModel(User user)
        {
            Users = new ObservableCollection<User>();
            User = user;
            if (!CheckAdmin())
            {
                EnableButton = false;
            }
            LoadData();
        }
    }
}
