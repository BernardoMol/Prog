using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CursoWindowsForms;
using CursoWinForm.Formulários_Curso_1;
using CursoWindowsFormsBiblioteca;

namespace CursoWinForm
{
    public partial class Frm_Principal_Menu_UC : Form
    {
        int ControleHelloWorld = 0;
        int ControleCadastroClientes = 0;
        public Frm_Principal_Menu_UC()
        {
            InitializeComponent();
            novoToolStripMenuItem.Enabled = false;
            apagarAbaToolStripMenuItem.Enabled = false;
            abrirImagemToolStripMenuItem.Enabled = false;
            desconectarToolStripMenuItem.Enabled = false;
            cadastrosToolStripMenuItem.Enabled = false;
            
        }
        private void demonstraçãoKeyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // EM MEMÓRIA
            Frm_DemkonstracaoKey_UC U = new Frm_DemkonstracaoKey_UC();
            U.Dock = DockStyle.Fill;
            TabPage TB = new TabPage();
            TB.Name = "Demonstração Key ";
            TB.Text = "Demonstração Key UC ";
            TB.Controls.Add(U);
            TB.ImageIndex = 0;
            // EM TELA
            Tbc_Aplicacoes.TabPages.Add(TB);
        }

        private void helloWorldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ControleHelloWorld += 1;
            // EM MEMÓRIA
            Frm_HelloWorld_UC U = new Frm_HelloWorld_UC();
            U.Dock = DockStyle.Fill;
            TabPage TB = new TabPage();
            TB.Name = "Hello World " + ControleHelloWorld;
            TB.Text = "Hello World UC " + ControleHelloWorld;
            TB.Controls.Add(U);
            TB.ImageIndex = 1;
            // EM TELA
            Tbc_Aplicacoes.TabPages.Add(TB);

        }

        private void mascaraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Mascara_UC U = new Frm_Mascara_UC();
            U.Dock = DockStyle.Fill;
            TabPage TB = new TabPage();
            TB.Name = "Máscara ";
            TB.Text = "Máscara UC ";
            TB.Controls.Add(U);
            Tbc_Aplicacoes.TabPages.Add(TB);
        }

        private void validaCPFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_ValidaCPF_UC U = new Frm_ValidaCPF_UC();
            U.Dock = DockStyle.Fill;
            TabPage TB = new TabPage();
            TB.Name = "Valida CPF ";
            TB.Text = "Valída CPF UC";
            TB.ImageIndex = 3;
            TB.Controls.Add(U);
            Tbc_Aplicacoes.TabPages.Add(TB);
        }

        private void validaCPF2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_ValidaCPF2_UC U = new Frm_ValidaCPF2_UC();
            U.Dock = DockStyle.Fill;
            TabPage TB = new TabPage();
            TB.Name = "Valida CPF2 ";
            TB.Text = "Valída CPF2 UC";
            TB.ImageIndex = 4;
            TB.Controls.Add(U);
            Tbc_Aplicacoes.TabPages.Add(TB);
        }

        private void validaSenhaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_ValidaSenha_UC U = new Frm_ValidaSenha_UC();
            U.Dock = DockStyle.Fill;
            TabPage TB = new TabPage();
            TB.Name = "Valida Senha ";
            TB.Text = "Valída Senha ";
            TB.ImageIndex = 5;
            TB.Controls.Add(U);
            Tbc_Aplicacoes.TabPages.Add(TB);
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void apagarAbaToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if ( ! (Tbc_Aplicacoes.SelectedTab == null) ) 
            {
                //Tbc_Aplicacoes.TabPages.Remove(Tbc_Aplicacoes.SelectedTab);
                ApagaAba(Tbc_Aplicacoes.SelectedTab);
            }
            
        }

        private void abrirImagemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog Db = new OpenFileDialog();
            Db.InitialDirectory = "C:\\Users\\Mol\\Documents\\GitHub\\Prog\\ALURA\\C#\\WINFORM\\CursoWinForm\\CursoWinForm\\Imagens\\";
            Db.Filter = "PNG|*.PNG";
            Db.Title = "Escolha a imagem";

            if(Db.ShowDialog() == DialogResult.OK) 
            {
                string nomeArquivo = Db.FileName;

                Frm_ArquivoImagem_UC U = new Frm_ArquivoImagem_UC(nomeArquivo);
                U.Dock = DockStyle.Fill;
                TabPage TB = new TabPage();
                TB.Name = "Arquivo Imagem ";
                TB.Text = "Arquivo Imagem";
                TB.ImageIndex = 6;
                TB.Controls.Add(U);
                Tbc_Aplicacoes.TabPages.Add(TB);
            }
        }

        private void conectarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Login F = new Frm_Login();
            F.ShowDialog();

            if (F.DialogResult == DialogResult.OK) 
            {
                string login = F.login;
                string senha = F.senha;
                

                if(Cls_Uteis.validaSenhaLogin(senha) == true)
                {
                    desconectarToolStripMenuItem.Enabled = true;
                    novoToolStripMenuItem.Enabled = true;
                    apagarAbaToolStripMenuItem.Enabled = true;
                    abrirImagemToolStripMenuItem.Enabled = true;
                    cadastrosToolStripMenuItem.Enabled = true;

                    conectarToolStripMenuItem.Enabled = false;

                    MessageBox.Show("Bem Vindo " + login + " !", "Mensagem",MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Login/Senha errado(s)", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void desconectarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Questao Db = new Frm_Questao("icons8_question_mark_961","Deseja mesmo se desconectar ?");
            Db.ShowDialog();

            if (Db.DialogResult == DialogResult.Yes)
            {

                //Fechando abas
                for(int i= Tbc_Aplicacoes.TabPages.Count-1; i>=0; i--)
                {
                    Tbc_Aplicacoes.TabPages.Remove(Tbc_Aplicacoes.TabPages[i]);
                }
                
                // Desativando os menus
                desconectarToolStripMenuItem.Enabled = false;
                novoToolStripMenuItem.Enabled = false;
                apagarAbaToolStripMenuItem.Enabled = false;
                abrirImagemToolStripMenuItem.Enabled = false;
                cadastrosToolStripMenuItem.Enabled = false;

                conectarToolStripMenuItem.Enabled = true;
            }
        }

        private void Tbc_Aplicacoes_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {

                // context é o menu todo e o tooltip é um dos itens (tipo arquivo, açoes ou windows)
                var contextMenu = new ContextMenuStrip(); // instanciei o MENU

                var vToolTip001 = DesenhaItemMenu("Apagar a Aba", "DeleteTab"); // instanciei O ITEM do menu de outra forma
                var vToolTip002 = DesenhaItemMenu("Apagar todas a esquerda", "DeleteLeft"); 
                var vToolTip003 = DesenhaItemMenu("Apagar todas a direita", "DeleteRight"); 
                var vToolTip004= DesenhaItemMenu("Apagar todas menos esta", "DeleteAll"); 

                contextMenu.Items.Add(vToolTip001); // Associei um ao outro, mas ainda esta na memoria
                contextMenu.Items.Add(vToolTip002); 
                contextMenu.Items.Add(vToolTip003); 
                contextMenu.Items.Add(vToolTip004); 

                contextMenu.Show(this, new Point(e.X, e.Y)); // Exibi o menu que estava na memória

                // Criando o evento de INTERAÇÃO forma dinamica
                vToolTip001.Click += new System.EventHandler(vToolTip001_Click); // CRIANDO o evento de click
                vToolTip002.Click += new System.EventHandler(vToolTip002_Click);
                vToolTip003.Click += new System.EventHandler(vToolTip003_Click);
                vToolTip004.Click += new System.EventHandler(vToolTip004_Click);

            }
        }
        void vToolTip001_Click(object sender1, EventArgs e1)
        {
            if (!(Tbc_Aplicacoes.SelectedTab == null))
            {
                //Tbc_Aplicacoes.TabPages.Remove(Tbc_Aplicacoes.SelectedTab);
                ApagaAba(Tbc_Aplicacoes.SelectedTab);
            }
        }

        void vToolTip002_Click(object sender2, EventArgs e2)
        {
            if (!(Tbc_Aplicacoes.SelectedTab == null))
            {
                ApagaEsquerda(Tbc_Aplicacoes.SelectedIndex);
            }
        }

        void vToolTip003_Click(object sender3, EventArgs e3)
        {
            if (!(Tbc_Aplicacoes.SelectedTab == null))
            {
                ApagaDireita(Tbc_Aplicacoes.SelectedIndex);
            }
        }

        void vToolTip004_Click(object sender4, EventArgs e4)
        {
            if (!(Tbc_Aplicacoes.SelectedTab == null))
            {
                ApagaEsquerda(Tbc_Aplicacoes.SelectedIndex);
                ApagaDireita(Tbc_Aplicacoes.SelectedIndex);
            }
        }

        void ApagaEsquerda(int ItemSelecionado)
        {            
            for (int i = ItemSelecionado - 1; i >= 0; i += -1)
            {
                //Tbc_Aplicacoes.TabPages.Remove(Tbc_Aplicacoes.TabPages[i]);
                ApagaAba(Tbc_Aplicacoes.TabPages[i]);
            }
        }
        void ApagaDireita(int ItemSelecionado)
        {
            
            for (int i = Tbc_Aplicacoes.TabPages.Count - 1; i > ItemSelecionado; i--)
            {
                //Tbc_Aplicacoes.TabPages.Remove(Tbc_Aplicacoes.TabPages[i]);
                ApagaAba(Tbc_Aplicacoes.TabPages[i]);
            }
            
        }


        ToolStripMenuItem DesenhaItemMenu(string text, string nomeImagem)
        {
            // Cria item
            var vToolTip = new ToolStripMenuItem();
            vToolTip.Text = text;

            // Associa Imagem (PARA ARQUIVO INTERNO)
            Image myImage = (Image)global::CursoWinForm.Properties.Resources.ResourceManager.GetObject(nomeImagem);
            vToolTip.Image = myImage;

            return vToolTip;
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if (ControleCadastroClientes == 0)
            {
                ControleCadastroClientes++; 
                Frm_CadastroCliente_UC U = new Frm_CadastroCliente_UC();
                U.Dock = DockStyle.Fill;
                TabPage TB = new TabPage();
                TB.Name = "Cadastro Cliente";
                TB.Text = "Cadastro Cliente";
                TB.ImageIndex = 10;
                TB.Controls.Add(U);
                Tbc_Aplicacoes.TabPages.Add(TB);
            }
            else
            {
                MessageBox.Show("Já exite um cadastro em abarto","Mensagem",MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        void ApagaAba(TabPage TB)
        {
            if (TB.Name == "Cadastro Cliente")
            {
                ControleCadastroClientes = 0;
            }
            Tbc_Aplicacoes.TabPages.Remove(TB);
        }
    }
}