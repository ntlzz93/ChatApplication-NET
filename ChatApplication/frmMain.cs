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
    public partial class frmMain : Form
    {
        private UsersEN currentUser;
        public frmMain()
        {
            InitializeComponent();
        }
        public frmMain(UsersEN aUserEN)
        {
            InitializeComponent();
            this.currentUser = aUserEN;
            test();    
        }
        public void test()
        {
            lblTest.Text = currentUser.Username;
        }
    }
}
