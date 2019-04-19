using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MyMap.ViewModel
{
    public partial class ControlBarViewModel : BaseViewModel
    {
        private String _VisibleLoginButton = "Visible";
        public String VisibleLoginButton { get => _VisibleLoginButton; set { _VisibleLoginButton = value; OnPropertyChanged(); } }

        private bool _IsLogin = false;
        public bool IsLogin
        {
            get => _IsLogin; set
            {
                _IsLogin = value; OnPropertyChanged();
                if (IsLogin)
                {
                    VisibleLoginButton = "Collapsed";
                }
            }
        }

        private String _Collapsed = "Collapsed";
        public String Collapsed { get => _Collapsed; set { _Collapsed = value; OnPropertyChanged(); } }

        private String _ShowNameUser { get; set; }
        public String ShowNameUser { get => _ShowNameUser; set { _ShowNameUser = value; OnPropertyChanged(); } }

        #region commands
        public ICommand CloseWindowCommand { get; set; }
        public ICommand MinimizeWindowCommand { get; set; }
        public ICommand MaximizeWindowCommand { get; set; }
        public ICommand MouseDownWindowCommand { get; set; }
        public ICommand ChangePasswordCommand { get; set; }
        public ICommand LoadedAccountWindowCommand { get; set; }
        public ICommand MouseDoubleClickWindowCommand { get; set; }
        public ICommand SignInCommand { get; set; }
        public ICommand SignUpCommand { get; set; }
        #endregion

        // Class control bar
        public ControlBarViewModel()
        {
            // Loaded Account
            //LoadedAccountWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            //{
            //    if (p != null)
            //    {
            //        var login = p.DataContext as MainViewModel;
            //        if (login != null)
            //        {
            //            if (login.Account != null)
            //            {
            //                Account = login.Account;
            //                ShowNameUser = "Hello " + Account.UserName;
            //                Collapsed = "Visible";
            //            }
            //        }
            //    }
            //});

            // Close window
            CloseWindowCommand = new RelayCommand<UserControl>((p) => { return p == null ? false : true; }, (p) =>
            {
                var w = Window.GetWindow(p) as Window;
                if (w != null)
                {
                    w.Close();
                }
            });

            // Change Password
            //ChangePasswordCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            //{
            //    ChangePassword ChangePassForm = new ChangePassword();
            //    ChangePassForm.ShowDialog();
            //});


            SignInCommand = new RelayCommand<UserControl>((p) => { return true; }, (p) =>
            {
                VisibleLoginButton = "Collapsed";
                Login loginForm = new Login();
                loginForm.ShowDialog();

                FrameworkElement window = GetWindowParent(p) as FrameworkElement;

                var w = window as Window;
                w.Hide();
                if (loginForm.DataContext == null)
                {
                    return;
                }
                // get value IsLogin of LoginViewModel check IsLogin ?? 
                var loginVM = loginForm.DataContext as LoginViewModel;
                if (loginVM.IsLogin)
                {
                    IsLogin = true;
                    MapCreate mapCreate = new MapCreate();
                    mapCreate.ShowDialog();


                }
                IsLogin = false;
                VisibleLoginButton = "Visible";
                w.Show();
            });

            SignUpCommand = new RelayCommand<UserControl>((p) => { return true; }, (p) =>
            {
                VisibleLoginButton = "Collapsed";
                CreateAccount createAccountForm = new CreateAccount();
                createAccountForm.ShowDialog();
                FrameworkElement window = GetWindowParent(p) as FrameworkElement;

                var w = window as Window;
                w.Hide();

                VisibleLoginButton = "Visible";
                w.Show();
            });

            FrameworkElement GetWindowParent(UserControl p)
            {
                FrameworkElement parent = p;
                while (parent.Parent != null)
                {
                    parent = parent.Parent as FrameworkElement;
                }
                return parent;
            }

            // Minimize window
            MinimizeWindowCommand = new RelayCommand<UserControl>((p) => { return p == null ? false : true; }, (p) =>
            {
                var w = Window.GetWindow(p) as Window;
                if (w != null)
                {
                    if (w.WindowState != WindowState.Minimized)
                    {
                        w.WindowState = WindowState.Minimized;
                    }
                    else
                    {
                        w.WindowState = WindowState.Normal;
                    }
                }
            });

            MouseDoubleClickWindowCommand = new RelayCommand<UserControl>((p) => { return p == null ? false : true; }, (p) =>
            {
                var w = Window.GetWindow(p) as Window;
                if (w != null)
                {
                    if (w.WindowState != WindowState.Maximized)
                    {
                        w.WindowState = WindowState.Maximized;
                    }
                    else
                    {
                        w.WindowState = WindowState.Normal;
                    }
                }
            });

            // Maximize window
            MaximizeWindowCommand = new RelayCommand<UserControl>((p) => { return p == null ? false : true; }, (p) =>
            {
                var w = Window.GetWindow(p) as Window;
                if (w != null)
                {
                    if (w.WindowState != WindowState.Maximized)
                    {
                        w.WindowState = WindowState.Maximized;
                    }
                    else
                    {
                        w.WindowState = WindowState.Normal;
                    }
                }
            });

            // Drag window
            MouseDownWindowCommand = new RelayCommand<UserControl>((p) => { return p == null ? false : true; }, (p) =>
            {
                try
                {
                    var w = Window.GetWindow(p) as Window;
                    if (w != null)
                    {
                        w.DragMove();
                    }
                }
                catch { }
            });





        }

    }

}

