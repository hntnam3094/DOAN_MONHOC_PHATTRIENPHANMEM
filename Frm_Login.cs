using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLLa;
using BLLa.Database;
namespace PhanMem_QuanlySpa
{
    public partial class Frm_Login : Form
    {
        public Frm_Login()
        {
            InitializeComponent();
            LoadAccount();
        }


        void LoadAccount()
        {
            if (Properties.Settings.Default.username != string.Empty)
            {
                if (Properties.Settings.Default.remind == "yes")
                {
                    txt_username.Text = Properties.Settings.Default.username;
                    txt_password.Text = Properties.Settings.Default.password;
                    checkEdit1.Checked = true;
                }
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            LoginForm();
        }

        void LoginForm()
        {
            string username = txt_username.Text;
            string password = txt_password.Text;
         
            if (string.IsNullOrEmpty(txt_username.Text))
            {
                MessageBox.Show("Vui long nhap vao tai khoan!");
                return;
            }else
                if (string.IsNullOrEmpty(txt_password.Text))
                {
                    MessageBox.Show("Vui long nhap vao mat khau!");
                    return;
                }
                else
                {
                    Account acc = AccountDAO.Instance.getAccount(username, password);
                    if (AccountDAO.Instance.islOgin(username, password) == true)
                    {
                        if (AccountDAO.Instance.get_hoatdong(username, password) == 1)
                        {
                            MessageBox.Show("Tai khoan cua ban da bi khoa!");
                        }
                        if (AccountDAO.Instance.get_hoatdong(username, password) == 0)
                        {
                            if (checkEdit1.Checked)
                            {
                                Properties.Settings.Default.username = txt_username.Text;
                                Properties.Settings.Default.password = txt_password.Text;
                                Properties.Settings.Default.remind = "yes";
                                Properties.Settings.Default.Save();
                            }
                            else
                            {
                                Properties.Settings.Default.username = "";
                                Properties.Settings.Default.password = "";
                                Properties.Settings.Default.remind = "no";
                                Properties.Settings.Default.Save();
                            }
                            FromMain fmain = new FromMain(acc);
                            this.Hide();
                            fmain.ShowDialog();
                            this.Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show("tai khoang mat khau khong dung!");
                    }
                }

            
        }
    }
}
