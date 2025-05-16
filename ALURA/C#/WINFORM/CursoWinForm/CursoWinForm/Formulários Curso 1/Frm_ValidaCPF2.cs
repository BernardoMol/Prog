using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CursoWindowsFormsBiblioteca;

namespace CursoWinForm
{
    public partial class Frm_ValidaCPF2 : Form
    {
        public Frm_ValidaCPF2()
        {
            InitializeComponent();
        }

        private void Btn_Reset_Click(object sender, EventArgs e)
        {
            Msk_CPF.Text = "";
        }

        private void Btn_Valida_Click_1(object sender, EventArgs e)
        {
            
            string vConteudo = Msk_CPF.Text;
            vConteudo = vConteudo.Replace(".", "").Replace("-", "");
            vConteudo = vConteudo.Trim();
            
            if (vConteudo == "")
            {
                MessageBox.Show("O CPF não pode estar em branco", "Mensagem de Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (vConteudo.Length != 11)
                {
                    MessageBox.Show("O CPF precisa de 11 digitos", "Mensagem de Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (MessageBox.Show("Voce deseja Validar o CPF?", "Mensagem de Validação", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        bool validaCPF = false;
                        validaCPF = Cls_Uteis.Valida(Msk_CPF.Text);
                        if (validaCPF == true)
                        {
                            MessageBox.Show("CPF Válido", "Mensagem de Validação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("CPF Invalido", "Mensagem de Validação", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                }
            }
        }
    }
}
