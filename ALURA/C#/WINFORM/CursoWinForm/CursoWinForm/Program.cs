using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CursoWindowsForms;

namespace CursoWinForm
{
    internal static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Frm_HelloWorld());
            //Application.Run(new Frm_DemkonstracaoKey());
            //Application.Run(new Frm_ValidaSenha());
            //Application.Run(new Frm_ValidaCPF2());
            //Application.Run(new Frm_Principal());
            //Application.Run(new Frm_Principal_Menu_MDI());
            Application.Run(new Frm_Principal_Menu_UC());
            //Application.Run(new Frm_MouseEventos());
            //Application.Run(new Frm_MouseCaptura());
            //Application.Run(new Frm_MouseCursor());
            //Application.Run(new Frm_MenuFlutuante());

        }
    }
}
