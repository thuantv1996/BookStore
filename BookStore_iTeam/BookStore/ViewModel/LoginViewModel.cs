using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BookStore.View;
using System.Windows;

namespace BookStore.ViewModel
{
    public class LoginViewModel
    {
        public ICommand LoginCommand { get; set; }
        public ICommand CloseCommand { get; set; }

        public LoginViewModel()
        {
            LoginCommand = new RelayCommand<object>((p) =>
            {
                Interface home = new Interface();
                home.Show();
                Application.Current.MainWindow.Close();
            },true);
            CloseCommand = new RelayCommand<object>((p) =>
            {
                Application.Current.MainWindow.Close();
            }, true);
        }

    }
}
