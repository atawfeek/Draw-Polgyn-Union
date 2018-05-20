using Domain;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IOperation
    {
        List<PointF> FindPolygonUnion(Polygons polygons);

        List<PointF> FindPolygonIntersection(Polygons polygons);

        List<PointF> FindPolygonSubtraction(Polygons polygons);
    }
}
