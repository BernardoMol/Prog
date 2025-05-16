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
    public partial class Frm_MenuFlutuante : Form
    {
        public Frm_MenuFlutuante()
        {
            InitializeComponent();
        }

        private void Frm_MenuFlutuante_MouseDown(object sender, MouseEventArgs e)
        {
            //string str1 = e.Button.ToString();
            //if (str1 == "Right")
            //{
            //    MessageBox.Show(str1);
            //}
            
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                var posicaoX = e.X;
                var posicaoY = e.Y;
                //============================================================================================================
                //============================================================================================================

                //MessageBox.Show("Clicou c o da direita");
                //MessageBox.Show("Posicção relaxiva X = " + posicaoX + "Posicção relaxiva Y = " + posicaoY);
                //MessageBox.Show("Posicção relaxiva X = " + e.X + "Posicção relaxiva Y = " + e.Y); // Ambos funcionam

                //============================================================================================================
                //============================================================================================================


                //============================================================================================================
                //============================================================================================================

                // context é o menu todo e o tooltip é um dos itens (tipo arquivo, açoes ou windows)
                var contextMenu = new ContextMenuStrip(); // instanciei o MENU

                //var vToolTip001 = new ToolStripMenuItem(); // instanciei O ITEM do menu
                //vToolTip001.Text = "Item 1 do Menu ";
                //contextMenu.Items.Add(vToolTip001); // Associei um ao outro, mas ainda esta na memoria

                //var vToolTip002 = new ToolStripMenuItem(); // instanciei O ITEM do menu
                //vToolTip002.Text = "Item 2 do Menu ";
                //contextMenu.Items.Add(vToolTip002); // Associei um ao outro, mas ainda esta na memoria


                var vToolTip001 = DesenhaItemMenu("Item 1", "key"); // instanciei O ITEM do menu de outra forma
                var vToolTip002 = DesenhaItemMenu("Item 2", "Frm_ValidaSenha"); // instanciei O ITEM do menu de outra forma

                contextMenu.Items.Add(vToolTip001); // Associei um ao outro, mas ainda esta na memoria
                contextMenu.Items.Add(vToolTip002); // Associei um ao outro, mas ainda esta na memoria

                contextMenu.Show(this, new Point(e.X, e.Y)); // Exibi o menu que estava na memória



                // Criando o evento de INTERAÇÃO forma dinamica
                vToolTip001.Click += new System.EventHandler(vToolTip001_Click); // CRIANDO o evento de click
                vToolTip002.Click += new System.EventHandler(vToolTip002_Click); // CRIANDO o evento de click

                //============================================================================================================
                //============================================================================================================
            }
        }

        // Criando o evento de INTERAÇÃO forma dinamica
        //this . < nome da variavel item>.Click += new System.EventHandler(this . < nome da variavel_Click ) ;
        //private void <nome da variavel item>_Click(object sender, EventArgs e)
        //{
            // Codigo
        //}

        void vToolTip001_Click(object sender1, EventArgs e1)
        {
            MessageBox.Show("Escolhi menu 1");
        }

        void vToolTip002_Click(object sender2, EventArgs e2)
        {
            MessageBox.Show("Escolhi menu 2");
        }

        ToolStripMenuItem DesenhaItemMenu(string text, string nomeImagem)
        {
            // Cria item
            var vToolTip = new ToolStripMenuItem();
            vToolTip.Text = text;

            // Cria SUB-item
            var subitem1 = new ToolStripMenuItem();
            subitem1.Text = ("Sub1");
            vToolTip.DropDownItems.Add(subitem1);

            // Associa Imagem (PARA ARQUIVO INTERNO)
            Image myImage = (Image)global::CursoWinForm.Properties.Resources.ResourceManager.GetObject(nomeImagem);
            vToolTip.Image = myImage;

            // Associa Imagem (PARA ARQUIVO EXTERNO)
            //Image MyImage = Image.FromFile("C:\FIGURA");
            //vToolTip.Image = MyImage;

            return vToolTip;
        }
    }
}
