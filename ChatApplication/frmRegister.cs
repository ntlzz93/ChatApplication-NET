using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccess;
using BusinessLogic;

namespace ChatApplication
{
    public partial class frmRegister : Form
    {
        private User user = new User();
        private MainFunction Func = new MainFunction();
        public frmRegister()
        {
            InitializeComponent();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            try
            {
                user.Username = txtUsername.Text;
                string passSHA1;
                passSHA1 = Func.ToSHA1(txtPassword.Text);
                user.Password = passSHA1;
                if (Func.SignUp(user))
                {
                    MessageBox.Show("Đăng ký thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Đăng ký thất bại, vui lòng thử lại ", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("SignUp" + ex.ToString());
            }

        }
    }
}
