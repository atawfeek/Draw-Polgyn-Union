using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw_NonConvex_Polygons_Show_Union
{
    public static class Bootstrapper
    {
        public static void Init()
        {
            DependencyInjector.Register<IOperation, Operation>();
        }
    }
}
