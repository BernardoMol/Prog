﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CursoWinForm.Formulários_Curso_1
{
    public partial class Frm_Login : Form
    {
        public string senha;
        public string login;
        public Frm_Login()
        {
            InitializeComponent();

            Lbl_Login.Text = "Usuario";
            Lbl_Password.Text = "Password";
            Btn_Ok.Text = "OK";
            Btn_Cancel.Text = "Cancel";
            
        }

        private void Btn_Ok_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            login = Txt_Login.Text;
            senha = Txt_Password.Text;
            this.Close();
        }

        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
