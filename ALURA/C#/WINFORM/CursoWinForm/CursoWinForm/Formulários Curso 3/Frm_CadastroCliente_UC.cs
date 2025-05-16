using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CursoWindowsFormsBiblioteca;
using CursoWindowsFormsBiblioteca.Classes;
using System.ComponentModel.DataAnnotations;
using Microsoft.VisualBasic;

namespace CursoWindowsForms
{
    public partial class Frm_CadastroCliente_UC : UserControl
    {
        public Frm_CadastroCliente_UC()
        {
            InitializeComponent();
            Grp_Codigo.Text = "Código";
            Grp_DadosPessoais.Text = "Dados Pessoais";
            Grp_Endereco.Text = "Endereço";
            Grp_Outros.Text = "Outros";
            Lbl_Bairro.Text = "Bairro";
            Lbl_CEP.Text = "CEP";
            Lbl_Complemento.Text = "Complemento";
            Lbl_CPF.Text = "CPF";
            Lbl_Estado.Text = "Estado";
            Lbl_Logradouro.Text = "Logradouro";
            Lbl_NomeCliente.Text = "Nome";
            Lbl_NomeMae.Text = "Nome da Mãe";
            Lbl_NomePai.Text = "Nome do Pai";
            Lbl_Profissao.Text = "Profissão";
            Lbl_RendaFamiliar.Text = "Renda Familiar";
            Lbl_Telefone.Text = "Telefone";
            Lbl_Cidade.Text = "Cidade";
            Chk_TemPai.Text = "Pai desconhecido";
            Rdb_Masculino.Text = "Masculino";
            Rdb_Feminino.Text = "Feminino";
            Rdb_Indefinido.Text = "Indefinido";
            Grp_Genero.Text = "Genero";

            Cmb_Estados.Items.Clear();
            Cmb_Estados.Items.Add("Acre (AC)");
            Cmb_Estados.Items.Add("Alagoas(AL)");
            Cmb_Estados.Items.Add("Amapá(AP)");
            Cmb_Estados.Items.Add("Amazonas(AM)");
            Cmb_Estados.Items.Add("Bahia(BA)");
            Cmb_Estados.Items.Add("Ceará(CE)");
            Cmb_Estados.Items.Add("Distrito Federal(DF)");
            Cmb_Estados.Items.Add("Espírito Santo(ES)");
            Cmb_Estados.Items.Add("Goiás(GO)");
            Cmb_Estados.Items.Add("Maranhão(MA)");
            Cmb_Estados.Items.Add("Mato Grosso(MT)");
            Cmb_Estados.Items.Add("Mato Grosso do Sul(MS)");
            Cmb_Estados.Items.Add("Minas Gerais(MG)");
            Cmb_Estados.Items.Add("Pará(PA)");
            Cmb_Estados.Items.Add("Paraíba(PB)");
            Cmb_Estados.Items.Add("Paraná(PR)");
            Cmb_Estados.Items.Add("Pernambuco(PE)");
            Cmb_Estados.Items.Add("Piauí(PI)");
            Cmb_Estados.Items.Add("Rio de Janeiro(RJ)");
            Cmb_Estados.Items.Add("Rio Grande do Norte(RN)");
            Cmb_Estados.Items.Add("Rio Grande do Sul(RS)");
            Cmb_Estados.Items.Add("Rondônia(RO)");
            Cmb_Estados.Items.Add("Roraima(RR)");
            Cmb_Estados.Items.Add("Santa Catarina(SC)");
            Cmb_Estados.Items.Add("São Paulo(SP)");
            Cmb_Estados.Items.Add("Sergipe(SE)");
            Cmb_Estados.Items.Add("Tocantins(TO)");

            Tls_Principal.Items[0].ToolTipText = "Novo Cliente";
            Tls_Principal.Items[1].ToolTipText = "Abrir Cadastr";
            Tls_Principal.Items[2].ToolTipText = "Salvar";
            Tls_Principal.Items[3].ToolTipText = "Apagar Cliente";
            Tls_Principal.Items[4].ToolTipText = "Limpar tela";
        }

        private void Chk_TemPai_CheckedChanged(object sender, EventArgs e)
        {
            if (Chk_TemPai.Checked)
            {
                Txt_NomePai.Enabled = false;
            }
            else 
            { 
                Txt_NomePai.Enabled = true; 
            }
        }

        private void novoToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente.Unit C = new Cliente.Unit();
                C = LeituraFormulario();
                C.Id = Txt_Codigo.Text;
                C.ValidaClasse();
                C.ValidaComplemento();
                MessageBox.Show("Deu Bom", "ByteBank", MessageBoxButtons.OK);
            }
            catch (ValidationException Ex)
            {
                MessageBox.Show(Ex.Message, "ERRO: ByteBank", MessageBoxButtons.OK);
            }

            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "ERRO: ByteBank", MessageBoxButtons.OK);
            }
        }


        private void abrirToolStripButton_Click(object sender, EventArgs e)
        {

        }

        private void salvarToolStripButton_Click(object sender, EventArgs e)
        {
             
        }

        private void ApagatoolStripButton_Click(object sender, EventArgs e)
        {

        }

        private void LimpartoolStripButton_Click(object sender, EventArgs e)
        {

        }

        Cliente.Unit LeituraFormulario()
        {
            Cliente.Unit C = new Cliente.Unit();
            C.Id = Txt_Codigo.Text;
            C.Nome = Txt_NomeCliente.Text;
            C.NomeMae = Txt_NomeMae.Text;
            C.NomePai = Txt_NomePai.Text;
            if (Chk_TemPai.Checked)
            {
                C.NaoTemPai = true;
            }
            else
            {
                C.NaoTemPai = false;
            }
            if (Rdb_Masculino.Checked)
            {
                C.Genero = 0;
            }
            if (Rdb_Feminino.Checked)
            {
                C.Genero = 1;
            }
            if (Rdb_Indefinido.Checked)
            {
                C.Genero = 2;
            }

            C.Cpf = Txt_CPF.Text;

            C.Cep = Txt_CEP.Text;
            C.Logradouro = Txt_Logradouro.Text;
            C.Complemento = Txt_Complemento.Text;
            C.Cidade = Txt_Cidade.Text;
            C.Bairro = Txt_Bairro.Text;

            if (Cmb_Estados.SelectedIndex < 0)
            {
                C.Estado = "";
            }
            else
            {
                C.Estado = Cmb_Estados.Items[Cmb_Estados.SelectedIndex].ToString();
            }

            C.Telefone = Txt_Telefone.Text;
            C.Profissao = Txt_Profissao.Text;

            // outra forma de ver se o conteuo do campo é NUMERICO
            if (Information.IsNumeric(Txt_RendaFamiliar.Text)) 
            {
                Double vRenda = Convert.ToDouble(Txt_RendaFamiliar.Text);
                if (vRenda < 0)
                {
                    C.RendaFamiliar = 0;
                }
                else
                {
                    C.RendaFamiliar = vRenda;
                }
            }

            return C;
        }

        private void Txt_CEP_Leave(object sender, EventArgs e)
        {
            //var vJson = Cls_Uteis.GeraJSONCEP("20261140"); // genérico, para testes

            //Caso eu não tivesse transformado a função desserialided em GENÉRICA
            //Cep.Unit CEP = new Cep.Unit();
            //CEP = Cep.DesSerializedClassUnit(vJson);

            var vCep = Txt_CEP.Text;

            if (vCep != "")
            {
                if (vCep.Length == 8 )
                {
                    var vJson = Cls_Uteis.GeraJSONCEP(vCep);
                    Cep.Unit CEP = new Cep.Unit();
                    CEP = Cls_Uteis.DesSerializedClassUnit<Cep.Unit>(vJson);
                    Txt_Bairro.Text = CEP.bairro;
                    Txt_Logradouro.Text = CEP.logradouro;
                    Txt_Cidade.Text = CEP.localidade;

                    Cmb_Estados.SelectedIndex = -1; // index de item NULO
                    for (int i=0; i<=Cmb_Estados.Items.Count-1; i++)
                    {
                        var vPos = Strings.InStr( Cmb_Estados.Items[i].ToString(), "("+CEP.uf+")"  ); // do lado esquerdo é ONDE buscar e do direito é O QUE buscar
                        if (vPos > 0) //  a função acima retorna a posição do primeiro caractere de uma string dentro de outra string. // posição sempre > 0 dumb_ass???
                        {
                            Cmb_Estados.SelectedIndex = i; // força a seleção do item na caixa
                        }
                    }

                }
                else 
                {
                    MessageBox.Show("O CEP precisa ter 8 dígitos", "ERRO: ByteBank", MessageBoxButtons.OK);
                }  
            }
            else
            {
                MessageBox.Show("O CEP não pode ser nulo", "ERRO: ByteBank", MessageBoxButtons.OK);
            }


        }
    }
}
