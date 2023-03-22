﻿using MasterskayaOptronApplication.DbEntity;
using MasterskayaOptronApplication.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MasterskayaOptronApplication.View
{
    /// <summary>
    /// Логика взаимодействия для AdminPanelWindow.xaml
    /// </summary>
    public partial class AdminPanelWindow : Window
    {
        public AdminPanelWindow(User user)
        {
            InitializeComponent();

            DataContext = new AdminPanelViewModel(user);
            foreach (var item in App.Current.Windows)
            {
                if (item is MainWindow)
                {
                    this.Owner = item as Window;
                }
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as AdminPanelViewModel).AddUserDB();
        }
    }
}