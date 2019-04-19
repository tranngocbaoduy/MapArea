using MyMap.DBConnection;
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
    public partial class CreateAccountViewModel : BaseViewModel
    {
        public bool IsLogin = false;

        private String _UserName;
        public String UserName { get => _UserName; set { _UserName = value; OnPropertyChanged(); } }

        private String _Password;
        public String Password { get => _Password; set { _Password = value; OnPropertyChanged(); } }

        private String _RePassword;
        public String RePassword { get => _RePassword; set { _RePassword = value; OnPropertyChanged(); } }

        public ICommand ClickCloseLoginForm { get; set; }
        public ICommand ClickCreateButton { get; set; }
        public ICommand PasswordChangedCommand { get; set; }
        public ICommand RePasswordChangedCommand { get; set; }

        private PasswordBox _PasswordBox { get; set; }
        public PasswordBox PasswordBox { get => _PasswordBox; set { _PasswordBox = value; OnPropertyChanged(); } }

        private PasswordBox _RePasswordBox { get; set; }
        public PasswordBox RePasswordBox { get => _RePasswordBox; set { _RePasswordBox = value; OnPropertyChanged(); } }

        public CreateAccountViewModel()
        {

            // Close login form
            ClickCloseLoginForm = new RelayCommand<Window>((p) => { return true; }, (p) => { p.Close(); });

            // Set Password = Password on Form
            PasswordChangedCommand = new RelayCommand<PasswordBox>((p) => { return p == null ? false : true; }, (p) => { PasswordBox = p as PasswordBox; Password = p.Password; });

            RePasswordChangedCommand = new RelayCommand<PasswordBox>((p) => { return p == null ? false : true; }, (p) => { RePasswordBox = p as PasswordBox; RePassword = p.Password; });

            ClickCreateButton = new RelayCommand<Window>((p) => { return true; }, (p) => { CreateAccount(p); });

            // Check IsLogin Yet
            void CreateAccount(Window p)
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
                var itemAccount = DataProvider.Ins.DB.MAPUSERs.Where(i => i.USERNAME == UserName).ToList();

                if(itemAccount.Count() > 0)
                {
                    MessageBox.Show("Tài khoản đã tồn tại");
                    return; 
                }  

                if (Password == RePassword)
                {
                    Model.MAPUSER mapUSER = new Model.MAPUSER();
                    string pass = Base64Encode(Password);
                    mapUSER.USERNAME = UserName;
                    mapUSER.PASSWORD = pass;
                    DataProvider.Ins.DB.MAPUSERs.Add(mapUSER);
                    DataProvider.Ins.DB.SaveChanges();
                    MessageBox.Show("Tạo Tài Khoản thành công");
                    p.Close();
                }
                else
                {
                    MessageBox.Show("Mật khẩu Không trùng khớp");
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