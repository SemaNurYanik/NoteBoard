﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NoteBoard.BLL;
using NoteBoard.Model;

namespace NoteBoard.UI.Winform
{
    public partial class frmRegister : Form
    {
        UserController _userController;
        public frmRegister()
        {
            InitializeComponent();
            _userController = new UserController();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text != txtPasswordAgain.Text)
            {
                MessageBox.Show("Şifreler eşleşmiyor!");
                return;
            }
            User newUser = new User();
            newUser.FirstName = txtName.Text;
            newUser.LastName = txtSurname.Text;
            newUser.UserName = txtUsername.Text;
            newUser.UserRole = UserRole.Standart;
            newUser.Passwords.Add(new Password()
            {
                PasswordText = txtPassword.Text
            });

            try
            {
                bool result = _userController.Add(newUser);
                if (result)
                {
                    MessageBox.Show("Kayıt başarılı.Kullanıcı onay süreciniz başladı.");
                    this.Close();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void frmRegister_FormClosed(object sender, FormClosedEventArgs e)
        {

            this.Owner.Show();
        }
    }
}
