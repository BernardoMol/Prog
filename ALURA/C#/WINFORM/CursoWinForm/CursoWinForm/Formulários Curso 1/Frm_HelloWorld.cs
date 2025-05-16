using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CursoWinForm
{
    public partial class Frm_HelloWorld : Form
    {
        public Frm_HelloWorld()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Btn_Sair_Click(object sender, EventArgs e)
        {
            //Application.Exit();
            //DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //lbl_Titulo.Text = "Mudei o texto do label";
            lbl_Titulo.Text = TXT_Conteudo_Label.Text;
        }

        private void Frm_HelloWorld_Load(object sender, EventArgs e)
        {

        }
    }
}
