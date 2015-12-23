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
    public partial class frmLogin : Form
    {
        private DbDataContext db = new DbDataContext();
        private UsersBO aUserBO = new UsersBO();
        private MainFunction Fucn = new MainFunction();
        private UsersEN aUserEN;
        public frmLogin()
        {
            InitializeComponent();
            aUserEN = new UsersEN();
        }
        
        private void btnSignIn_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            if (Fucn.SignIn(username, password))
            {
                var userObject = db.Users.Where(b => b.Username == username).Where(b => b.Password == password).FirstOrDefault<User>();
                aUserEN.setValue(userObject);
                MessageBox.Show("Đăng nhập thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmMain form = new frmMain(aUserEN); 
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("Đăng nhập thất bại", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
        }

        private void frnSignUp_Click(object sender, EventArgs e)
        {
            frmRegister form = new frmRegister();
            form.ShowDialog();
 
        }
        private void MatchingEnterPress(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string username = txtUsername.Text;
                string password = txtPassword.Text;
                if (Fucn.SignIn(username, password))
                {
                    var userObject = db.Users.Where(b => b.Username == username).Where(b => b.Password == password).FirstOrDefault<User>();
                    aUserEN.setValue(userObject);
                    MessageBox.Show("Đăng nhập thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmMain form = new frmMain(aUserEN);
                    form.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Đăng nhập thất bại", "", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }
        }
    }
}
