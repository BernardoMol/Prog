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
    public partial class Frm_DemkonstracaoKey : Form
    {
        public Frm_DemkonstracaoKey()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Txt_Input.Text = "";
            Txt_Msg.Text = "";
            Lbl_Upper.Text = "";
            Lbl_Lower.Text = "";
        }

        private void Txt_Input_KeyDown(object sender, KeyEventArgs e)
        {
            Txt_Msg.AppendText("\r\n" + "Pressionei uma tecla " + e.KeyCode + "\r\n"); 
            Txt_Msg.AppendText("\t" + "Código ASC " + ((int)e.KeyCode) + "\r\n");
            Lbl_Upper.Text = e.KeyCode.ToString().ToUpper();
            Lbl_Lower.Text = e.KeyCode.ToString().ToLower();
        }

        private void Txt_Input_TextChanged(object sender, EventArgs e)
        {

        }

        private void Txt_Msg_TextChanged(object sender, EventArgs e)
        {

        }

        private void Lbl_Upper_Click(object sender, EventArgs e)
        {

        }

        private void Lbl_Maius_Click(object sender, EventArgs e)
        {

        }

        private void Frm_DemkonstracaoKey_Load(object sender, EventArgs e)
        {

        }

        private void Lbl_minus_Click(object sender, EventArgs e)
        {

        }

        private void Lbl_Lower_Click(object sender, EventArgs e)
        {

        }
    }
}
