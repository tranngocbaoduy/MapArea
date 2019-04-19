﻿using MyMap.DBConnection;
using MyMap.ViewModel;
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
    public partial class LoginViewModel : BaseViewModel
    {
        public bool IsLogin = false;

        private String _UserName;
        public String UserName { get => _UserName; set { _UserName = value; OnPropertyChanged(); } }

        private String _Password;
        public String Password { get => _Password; set { _Password = value; OnPropertyChanged(); } }

        public ICommand ClickCloseLoginForm { get; set; }
        public ICommand ClickLoginButton { get; set; }
        public ICommand PasswordChangedCommand { get; set; }

        private PasswordBox _PasswordBox { get; set; }
        public PasswordBox PasswordBox { get => _PasswordBox; set { _PasswordBox = value; OnPropertyChanged(); } }
         
        public LoginViewModel()
        {

            // Close login form
            ClickCloseLoginForm = new RelayCommand<Window>((p) => { return true; }, (p) => { p.Close(); });

            // Set Password = Password on Form
            PasswordChangedCommand = new RelayCommand<PasswordBox>((p) => { return p == null ? false : true; }, (p) => { PasswordBox = p as PasswordBox; Password = p.Password; });

            ClickLoginButton = new RelayCommand<Window>((p) => { return true; }, (p) => { checkLogin(p); });

            // Check IsLogin Yet
            void checkLogin(Window p)
            {
                if (p == null)
                {
                    return;
                }
                if (Password == null || UserName == null)
                {
                    MessageBox.Show("Tài khoản hoặc mật khẩu không hợp lệ");
                    return;
                }
                var pass = Base64Encode(Password);
                var itemAccount = DataProvider.Ins.DB.MAPUSERs.Where(i => i.USERNAME == UserName && i.PASSWORD == pass).SingleOrDefault();

                if (itemAccount != null)
                {
                    IsLogin = true;
                    p.Close();
                }
                else
                {
                    MessageBox.Show("Tài khoản hoặc mật khẩu không hợp lệ");
                    return;
                }
            } 
        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

    }

}