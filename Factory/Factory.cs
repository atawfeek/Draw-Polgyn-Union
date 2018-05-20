using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    public static class Factory
    {
        public static Polygon Instance()
        {
            return new Polygon();
        }
    }
}
