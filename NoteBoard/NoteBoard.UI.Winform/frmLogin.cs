using NoteBoard.BLL;
using NoteBoard.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoteBoard.UI.Winform
{
    public partial class frmLogin : Form
    {
        UserController _userController;
        public frmLogin()
        {
            InitializeComponent();
           
        }

        private void lblRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmRegister frm = new frmRegister();
            frm.Owner = this;
            frm.Show();
            this.Hide();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            _userController = new UserController();

            User currentUser = _userController.GetByLogin(txtUsername.Text, txtPassword.Text);
            if (currentUser != null)
            {
                if (currentUser.UserRole == UserRole.Standart)
                {
                    frmMain frm = new frmMain(currentUser);
                    //frm main ctor'unda user göndericez (gönderdik=>currentUser)
                    frm.Owner = this;
                    frm.Show();
                    this.Hide();
                }
                else
                {
                    frmAdmin frm = new frmAdmin();
                    frm.Owner = this;
                    frm.Show();
                    this.Hide();                    
                }
            }
            else
            {
                MessageBox.Show("Hatalı giriş bilgileri!");
            }
        }
    }
}
