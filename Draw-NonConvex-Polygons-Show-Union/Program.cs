using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Draw_NonConvex_Polygons_Show_Union
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Bootstrapper.Init(); //initiate registration of object instances in DI container (Unity)
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Form1 form = DependencyInjector.Retrieve<Form1>();
            Application.Run(form);
        }
    }
}
