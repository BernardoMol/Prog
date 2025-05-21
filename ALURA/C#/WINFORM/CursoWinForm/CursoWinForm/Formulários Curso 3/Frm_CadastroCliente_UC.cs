using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel.DataAnnotations;
using Microsoft.VisualBasic;
using CursoWindowsFormsBiblioteca;
using CursoWindowsFormsBiblioteca.Classes;
using CursoWindowsFormsBiblioteca.Database;
using System.Reflection;

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

            Btn_Busca.Text = "Buscar";
            Grp_DataGrid.Text = "Clientes";
            AtualizaGrid();


            LimparFormulario();
        }

        void LimparFormulario()
        {
            Txt_Codigo.Text = "";
            Txt_Bairro.Text = "";
            Txt_CEP.Text = "";
            Txt_Complemento.Text = "";
            Txt_CPF.Text = "";
            //Txt_Estado.Text = ""; // é combobox
            //Cmb_Estados.Text = ""; // Funciona, mas não o ideal
            Cmb_Estados.SelectedIndex = -1;
            Txt_Logradouro.Text = "";
            Txt_NomeCliente.Text = "";
            Txt_NomeMae.Text = "";
            Txt_NomePai.Text = "";
            Txt_Profissao.Text = "";
            Txt_RendaFamiliar.Text = "";
            Txt_Telefone.Text = "";
            Txt_Cidade.Text = "";

            Chk_TemPai.Checked = false;
            Rdb_Masculino.Checked = true;
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
                //C.IncluirFichario("C:\\Users\\Mol\\Documents\\GitHub\\Prog\\ALURA\\C#\\WINFORM\\CursoWinForm\\Fichario");
                //C.IncluirFicharioDB("Cliente");
                //C.IncluirFicharioSQL("Cliente");
                C.IncluirFicharioSQLREL();

                MessageBox.Show("OK! Cliente incluiodo com sucesso", "Bytebank", MessageBoxButtons.OK, MessageBoxIcon.Information);
                AtualizaGrid();

                //string clienteJSON = Cls_Uteis.SerializeObject(C);

                //Fichario F = new Fichario("C:\\Users\\Mol\\Documents\\GitHub\\Prog\\ALURA\\C#\\WINFORM\\CursoWinForm\\Fichario");
                //if (F.status)
                //{
                //    F.Incluir(C.Id, clienteJSON);
                //    if (F.status)
                //    {
                //        MessageBox.Show("ok" + F.mensagem, "Bytebank", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    }
                //    else
                //    {
                //        MessageBox.Show("ERRO: " + F.mensagem, "Bytebank", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    }

                //}
                //else 
                //{
                //    MessageBox.Show("ERRO: " + F.mensagem, "Bytebank", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}

                //MessageBox.Show("Deu Bom", "ByteBank", MessageBoxButtons.OK);
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
            if (Txt_Codigo.Text == "")
            {
                MessageBox.Show("Código não pode estar vazio", "ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else 
            {

                try
                {
                    Cliente.Unit C = new Cliente.Unit();
                    //C = C.BuscarFichario(Txt_Codigo.Text, "C:\\Users\\Mol\\Documents\\GitHub\\Prog\\ALURA\\C#\\WINFORM\\CursoWinForm\\Fichario");
                    //C = C.BuscarFicharioDB(Txt_Codigo.Text, "Cliente");
                    //C = C.BuscarFicharioSQL(Txt_Codigo.Text, "Cliente");
                    C = C.BuscarFicharioSQLREL(Txt_Codigo.Text);
                    EscreveFormulario(C);
                }

                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "ERRO: ByteBank", MessageBoxButtons.OK);
                }
                
                // testando CONEXÃO com FICHÁRIO
                //Fichario F = new Fichario("C:\\Users\\Mol\\Documents\\GitHub\\Prog\\ALURA\\C#\\WINFORM\\CursoWinForm\\Fichario");
                //if(F.status)
                //{
                //    // FAÇO a BUSCA
                //    string clienteJson = F.Buscar(Txt_Codigo.Text);
                //    // Verifico se a BUSCA deu certo
                //    if (F.status == true)
                //    {
                //        Cliente.Unit C = new Cliente.Unit();
                //        C = Cls_Uteis.DesSerializedClassUnit<Cliente.Unit>(clienteJson);
                //        EscreveFormulario(C);
                //    }
                //    else
                //    {
                //        MessageBox.Show("ERRO: " + F.mensagem, "Bytebank", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    }
                //}
                //else
                //{
                //    MessageBox.Show("ERRO: " + F.mensagem, "Bytebank", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
            }
        }

        private void salvarToolStripButton_Click(object sender, EventArgs e)
        {
            if (Txt_Codigo.Text == "")
            {
                MessageBox.Show("Código não pode estar vazio", "ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (Txt_Codigo.Text == "")
                {
                    MessageBox.Show("Código não pode estar vazio", "ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    try
                    {
                        Cliente.Unit C = new Cliente.Unit();
                        C = LeituraFormulario();
                        C.ValidaClasse();
                        C.ValidaComplemento();
                        //C.AlterarFichario("C:\\Users\\Mol\\Documents\\GitHub\\Prog\\ALURA\\C#\\WINFORM\\CursoWinForm\\Fichario");
                        //C.AlterarFicharioDB("Cliente");
                        //C.AlterarFicharioSQL("Cliente");
                        C.AlterarFicharioSQLREL();
                        MessageBox.Show("Cliente alterado com sucesso", "ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        AtualizaGrid();
                    }
                    catch (Exception sbrErrors)
                    {
                        MessageBox.Show("ERRO AO ALTERAR "+ sbrErrors.Message, "ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    
                    //try
                    //{
                    //    Cliente.Unit C = new Cliente.Unit();
                    //    C = LeituraFormulario();
                    //    C.Id = Txt_Codigo.Text;
                    //    C.ValidaClasse();
                    //    C.ValidaComplemento();
                    //    string clienteJSON = Cls_Uteis.SerializeObject(C);

                    //    Fichario F = new Fichario("C:\\Users\\Mol\\Documents\\GitHub\\Prog\\ALURA\\C#\\WINFORM\\CursoWinForm\\Fichario");
                    //    if (F.status)
                    //    {
                    //        F.Alterar(C.Id, clienteJSON);
                    //        if (F.status)
                    //        {
                    //            MessageBox.Show("ok" + F.mensagem, "Bytebank", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //        }
                    //        else
                    //        {
                    //            MessageBox.Show("ERRO: " + F.mensagem, "Bytebank", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //        }

                    //    }
                    //    else
                    //    {
                    //        MessageBox.Show("ERRO: " + F.mensagem, "Bytebank", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    }

                    //    //MessageBox.Show("Deu Bom", "ByteBank", MessageBoxButtons.OK);
                    //}
                    //catch (ValidationException Ex)
                    //{
                    //    MessageBox.Show(Ex.Message, "ERRO: ByteBank", MessageBoxButtons.OK);
                    //}
                }
            }
        }

        private void ApagatoolStripButton_Click(object sender, EventArgs e)
        {
            if (Txt_Codigo.Text == "")
            {
                MessageBox.Show("Código não pode estar vazio", "ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    Cliente.Unit C = new Cliente.Unit();
                    //C = C.BuscarFichario(Txt_Codigo.Text, "C:\\Users\\Mol\\Documents\\GitHub\\Prog\\ALURA\\C#\\WINFORM\\CursoWinForm\\Fichario");
                    //C = C.BuscarFicharioDB(Txt_Codigo.Text, "Cliente");
                    //C = C.BuscarFicharioSQL(Txt_Codigo.Text, "Cliente");
                    C = C.BuscarFicharioSQLREL(Txt_Codigo.Text);

                    EscreveFormulario(C);

                    Frm_Questao Db = new Frm_Questao("icons8_question_mark_961", "Tem certeza qque quer DELETAR ?!?!");
                    Db.ShowDialog();
                    if (Db.DialogResult == DialogResult.Yes)
                    {
                        //C.ApagarFichario("C:\\Users\\Mol\\Documents\\GitHub\\Prog\\ALURA\\C#\\WINFORM\\CursoWinForm\\Fichario");
                        //C.ApagarFicharioDB("Cliente");
                        //C.ApagarFicharioSQL("Cliente");
                        C.ApagarFicharioSQLREL();
                        LimparFormulario();
                        MessageBox.Show("Identificador apagado com sucesso ", "ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        AtualizaGrid();
                    }
                }
                catch
                {

                }
                //// testando CONEXÃO com FICHÁRIO
                //Fichario F = new Fichario("C:\\Users\\Mol\\Documents\\GitHub\\Prog\\ALURA\\C#\\WINFORM\\CursoWinForm\\Fichario");
                //if (F.status)
                //{
                //    // exibir dados antes de deletar
                //    string clienteJson = F.Buscar(Txt_Codigo.Text);
                //    // testando a busca
                //    if (F.status == true)
                //    {
                //        Cliente.Unit C = new Cliente.Unit();
                //        C = Cls_Uteis.DesSerializedClassUnit<Cliente.Unit>(clienteJson);
                //        EscreveFormulario(C);

                //        // QUESTIONAR se o usuario quer REALMENTE deletar
                //        Frm_Questao Db = new Frm_Questao("icons8_question_mark_961", "Tem certeza qque quer DELETAR ?!?!");
                //        Db.ShowDialog();
                //        if (Db.DialogResult == DialogResult.Yes)
                //        {
                //            F.Apagar(Txt_Codigo.Text);
                //            if (F.status)
                //            {
                //                MessageBox.Show("ok" + F.mensagem, "Bytebank", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //                LimparFormulario();
                //            }
                //            else
                //            {
                //                MessageBox.Show("ERRO: " + F.mensagem, "Bytebank", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //            }
                //        }
                //    }
                //    else
                //    {
                //        MessageBox.Show("ERRO: " + F.mensagem, "Bytebank", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    }

                //}
                //else
                //{
                //    MessageBox.Show("ERRO: " + F.mensagem, "Bytebank", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
            }
        }

        private void LimpartoolStripButton_Click(object sender, EventArgs e)
        {
            LimparFormulario();
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

        void EscreveFormulario(Cliente.Unit C)
        {
            Txt_Codigo.Text = C.Id;
            Txt_NomeCliente.Text = C.Nome;
            Txt_NomeMae.Text = C.NomeMae;

            if (C.NaoTemPai == true)
            {
                Chk_TemPai.Checked = true;
                Txt_NomePai.Text = "";
            }
            else
            {
                Chk_TemPai.Checked = false;
                Txt_NomePai.Text = C.NomePai;
            }

            if (C.Genero == 0)
            {
                Rdb_Masculino.Checked = true;
            }
            if (C.Genero == 1)
            {
                Rdb_Feminino.Checked = true;
            }
            if (C.Genero == 3)
            {
                Rdb_Indefinido.Checked = true;
            }

            Txt_CPF.Text = C.Cpf;

            Txt_CEP.Text = C.Cep;
            Txt_Logradouro.Text = C.Logradouro;
            Txt_Complemento.Text = C.Complemento;
            Txt_Cidade.Text = C.Cidade;
            Txt_Bairro.Text = C.Bairro;

            if (C.Estado == "")
            {
                Cmb_Estados.SelectedIndex = -1;
            }
            else
            {
                for (int i = 0; i <= Cmb_Estados.Items.Count - 1; i++)
                {
                    if (C.Estado == Cmb_Estados.Items[i].ToString())
                    {
                        Cmb_Estados.SelectedIndex = i;
                    }
                }
            }

            Txt_Telefone.Text = C.Telefone;
            Txt_Profissao.Text = C.Profissao;
            Txt_RendaFamiliar.Text = C.RendaFamiliar.ToString();
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

        private void Btn_Busca_Click(object sender, EventArgs e)
        {
            //Frm_Busca F = new Frm_Busca();
            //F.ShowDialog();


            try
            {
                Cliente.Unit C = new Cliente.Unit();
                List<string> list = new List<string>();
                //list = C.ListaFichario("C:\\Users\\Mol\\Documents\\GitHub\\Prog\\ALURA\\C#\\WINFORM\\CursoWinForm\\Fichario");
                //list = C.ListaFicharioDB("Cliente");
                //list = C.ListaFicharioSQL("Cliente");
                list = C.ListaFicharioSQLREL();

                if (list == null)
                {
                    MessageBox.Show("Base Vazia", "ERRO: ByteBank", MessageBoxButtons.OK);
                }
                else
                {
                    List<List<string>> ListaBusca = new List<List<string>>();
                    //for (int i = 0; i <= list.Count - 1; i++)
                    //{
                    //C = Cls_Uteis.DesSerializedClassUnit<Cliente.Unit>(list[i]);
                    //ListaBusca.Add(new List<string> { C.Id, C.Nome });
                    //}
                    //Frm_Busca F_form = new Frm_Busca(ListaBusca);

                    foreach (string itemFormatado in list) // Itera sobre cada string na lista original
                    {
                        // Divide a string pelo separador " - "
                        string[] partes = itemFormatado.Split(new string[] { " - " }, StringSplitOptions.None);

                        string id = partes[0];   // A primeira parte é o Id
                        string nome = partes[1]; // A segunda parte é o Nome

                        ListaBusca.Add(new List<string> { id, nome });
                    }


                    Frm_Busca F_form = new Frm_Busca(ListaBusca);
                    F_form.ShowDialog();
                    if (F_form.DialogResult == DialogResult.OK)
                    {
                        var idSelect = F_form.idSelect;
                        //C = C.BuscarFichario(idSelect, "C:\\Users\\Mol\\Documents\\GitHub\\Prog\\ALURA\\C#\\WINFORM\\CursoWinForm\\Fichario");
                        //C = C.BuscarFicharioDB(idSelect, "Cliente");
                        //C = C.BuscarFicharioSQL(idSelect, "Cliente");
                        C = C.BuscarFicharioSQLREL(idSelect);

                        if (C == null)
                        {
                            MessageBox.Show("ID nao encontrado", "ERRO: ByteBank", MessageBoxButtons.OK);
                        }
                        else
                        {
                            EscreveFormulario(C);
                        }
                    }




                    //    Fichario F = new Fichario("C:\\Users\\Mol\\Documents\\GitHub\\Prog\\ALURA\\C#\\WINFORM\\CursoWinForm\\Fichario");
                    //    if (F.status)s
                    //    {
                    //        List<string> list = new List<string>();
                    //        list = F.BuscarTodos();

                    //        //====== Extraindo os dados
                    //        if (F.status)
                    //        {
                    //            List<List<string>> listaDadosFiltrados = new List<List<string>>();
                    //            for (int i=0; i<= list.Count-1; i++)
                    //            {
                    //                Cliente.Unit C = Cls_Uteis.DesSerializedClassUnit<Cliente.Unit>(list[i]);
                    //                listaDadosFiltrados.Add(new List<string> { C.Id, C.Nome });
                    //            }
                    //            Frm_Busca F_form = new Frm_Busca(listaDadosFiltrados);
                    //            F_form.ShowDialog();
                    //            if (F_form.DialogResult == DialogResult.OK)
                    //            {
                    //                var idSelect = F_form.idSelect;
                    //                string clienteJson = F.Buscar(idSelect);
                    //                // Verifico se a BUSCA deu certo // talvez seja desnecessário
                    //                //if (F.status == true)
                    //                //{
                    //                    Cliente.Unit C = new Cliente.Unit();
                    //                    C = Cls_Uteis.DesSerializedClassUnit<Cliente.Unit>(clienteJson);
                    //                    EscreveFormulario(C);
                    //                //}
                    //            }
                    //        }
                    //        else
                    //        {
                    //            MessageBox.Show("O CEP não pode ser nulo", "ERRO: ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //        }
                    //        //====================



                    //    }
                    //    else
                    //    {
                    //        MessageBox.Show("ERRO: " + F.mensagem, "Bytebank", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    }

                    //    //MessageBox.Show("Deu Bom", "ByteBank", MessageBoxButtons.OK);
                }
            }
            catch (ValidationException Ex)
            {
                MessageBox.Show(Ex.Message, "ERRO: ByteBank", MessageBoxButtons.OK);
            }

        }

        private void AtualizaGrid()
        {
            try
            {
                Cliente.Unit C = new Cliente.Unit();
                List<string> list = new List<string>();
                list = C.ListaFicharioSQLREL();

                if (list == null)
                {
                    MessageBox.Show("Base Vazia", "ERRO: ByteBank", MessageBoxButtons.OK);
                }
             
                List<List<string>> ListaBusca = new List<List<string>>();
                Dg_Clientes.Rows.Clear();
                foreach (string itemFormatado in list) // Itera sobre cada string na lista original
                {

                    string[] partes = itemFormatado.Split(new string[] { " - " }, StringSplitOptions.None);

                    string id = partes[0];
                    string nome = partes[1];

                    ListaBusca.Add(new List<string> { id, nome });

                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(Dg_Clientes);
                    row.Cells[0].Value = id;
                    row.Cells[1].Value = nome;
                    Dg_Clientes.Rows.Add(row);
                }          


            }
            catch (Exception ex)  
            {
                MessageBox.Show(ex.Message, "ERRO: ByteBank", MessageBoxButtons.OK);
            }
            
        }

        private void Dg_Clientes_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow row = new DataGridViewRow();
                row = Dg_Clientes.SelectedRows[0];
                string Id = row.Cells[0].Value.ToString();

                try
                {
                    Cliente.Unit C = new Cliente.Unit();
                    //C = C.BuscarFichario(Txt_Codigo.Text, "C:\\Users\\Mol\\Documents\\GitHub\\Prog\\ALURA\\C#\\WINFORM\\CursoWinForm\\Fichario");
                    //C = C.BuscarFicharioDB(Txt_Codigo.Text, "Cliente");
                    //C = C.BuscarFicharioSQL(Txt_Codigo.Text, "Cliente");
                    C = C.BuscarFicharioSQLREL(Id);
                    EscreveFormulario(C);
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "ERRO: ByteBank", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO: ByteBank", MessageBoxButtons.OK);
            }
        }
    }
}
