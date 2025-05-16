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
    public partial class Frm_MouseEventos : Form
    {
        public Frm_MouseEventos()
        {
            InitializeComponent();
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            Btn_Mouse.Text = "Mouse Enter";
        }

        private void Btn_Mouse_MouseLeave(object sender, EventArgs e)
        {
            Btn_Mouse.Text = "Mouse Leave";
        }

        private void Btn_Mouse_MouseHover(object sender, EventArgs e)
        {
            Btn_Mouse.Text = "Mouse Hover";
        }

        private void Btn_Mouse_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void Btn_Mouse_MouseUp(object sender, MouseEventArgs e)
        {

        }
    }
}
