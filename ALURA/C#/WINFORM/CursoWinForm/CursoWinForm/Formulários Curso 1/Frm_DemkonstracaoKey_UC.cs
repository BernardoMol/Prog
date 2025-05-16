using System;
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
    public partial class Frm_DemkonstracaoKey_UC : UserControl
    {
        public Frm_DemkonstracaoKey_UC()
        {
            InitializeComponent();
        }

        private void Txt_Input_KeyDown(object sender, KeyEventArgs e)
        {
            Txt_Msg.AppendText("\r\n" + "Pressionei uma tecla " + e.KeyCode + "\r\n");
            Txt_Msg.AppendText("\t" + "Código ASC " + ((int)e.KeyCode) + "\r\n");
            Lbl_Upper.Text = e.KeyCode.ToString().ToUpper();
            Lbl_Lower.Text = e.KeyCode.ToString().ToLower();
        }

        private void Btn_reset_Click(object sender, EventArgs e)
        {
            Txt_Input.Text = "";
            Txt_Msg.Text = "";
            Lbl_Upper.Text = "";
            Lbl_Lower.Text = "";
        }

        // AS OUTRAS FUNÇÕES SãO DESNECESSARIOAS, DEVEM SER MISCLICK MEU
    }
}

