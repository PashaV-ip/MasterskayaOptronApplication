using MasterskayaOptronApplication.DbEntity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MasterskayaOptronApplication.ViewModel
{
    public class AdminPanelViewModel : BaseViewModel
    {
        private ObservableCollection<User> _users;
        private User _user;
        private User _addUser;

        public User AddUser
        {
            get => _addUser;
            set
            {
                _addUser = value;
                OnPropertyChanged(nameof(AddUser));
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
        public void LoadData()
        {
            if (Users.Count > 0)
            {
                Users.Clear();
            }
            var result = DbStorage.DB_s.User.ToList();
            result.ForEach(element => Users?.Add(element));
        }

        internal void AddUserDB()
        {
            MessageBox.Show($"{AddUser.Login} {AddUser.Password} {AddUser.UserInfo.MiddleName} {AddUser.UserInfo.UserStatus.Name}", "test", MessageBoxButton.OK, MessageBoxImage.Information);

            using (var db = new MasterskayaOptronEntities())
            {
                try
                {
                    var validateResult = ValidateEntity();

                    if (validateResult.Length > 0)
                    {
                        MessageBox.Show(validateResult.ToString() + "Ошибка в AddUserDB", "Информация", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    db.User.Add(AddUser);

                    db.SaveChanges();

                    MessageBox.Show("Данные успешно сохранены", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);

                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "Ошибка в TRY CATCHE", "Информация", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
        }

        private StringBuilder ValidateEntity()
        {
            var errors = new StringBuilder();

            if (_addUser != null)
            {
                if (string.IsNullOrEmpty(_addUser.Login))
                {
                    errors.AppendLine("Поле логин не может быть пустым!");
                }

                if (string.IsNullOrEmpty(_addUser.Password))
                {
                    errors.AppendLine("Поле пароль не может быть пустым!");
                }

                if (string.IsNullOrEmpty(_addUser.UserInfo.FirstName))
                {
                    errors.AppendLine("Поле фамилия не может быть пустым!");
                }

                if (string.IsNullOrEmpty(_addUser.UserInfo.MiddleName))
                {
                    errors.AppendLine("Поле имя не может быть пустым!");
                }

                if (string.IsNullOrEmpty(_addUser.UserInfo.LastName))
                {
                    errors.AppendLine("Поле отчество не может быть пустым!");
                }
                if (string.IsNullOrEmpty(_addUser.UserInfo.Phone))
                {
                    errors.AppendLine("Поле телефон не может быть пустым!");
                }
                if (string.IsNullOrEmpty(_addUser.UserInfo.UserStatus.Name))
                {
                    errors.AppendLine("Поле статус не может быть пустым!");
                }
            }

            return errors;
        }


        public AdminPanelViewModel(User user)
        {
            Users = new ObservableCollection<User>();
            User = user;
            AddUser = new User();
            AddUser.UserInfo = new UserInfo();
            AddUser.UserInfo.UserStatus = new UserStatus();
            LoadData();
        }
    }
}
