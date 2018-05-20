using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using GeometryHelper;

namespace Services
{
    public class Operation : IOperation
    {
        public List<PointF> FindPolygonIntersection(Polygons polygons)
        {
            throw new NotImplementedException();
        }

        public List<PointF> FindPolygonSubtraction(Polygons polygons)
        {
            throw new NotImplementedException();
        }

        public List<PointF> FindPolygonUnion(Polygons polygons)
        {
            // Find the lower-leftmost point in either polygon.
            int cur_pgon = 0;
            int cur_index = 0;
            PointF cur_point = polygons[cur_pgon][cur_index];
            for (int pgon = 0; pgon < 2; pgon++)
            {
                for (int index = 0; index < polygons[pgon].Count; index++)
                {
                    PointF test_point = polygons[pgon][index];
                    if ((test_point.X < cur_point.X) ||
                        ((test_point.X == cur_point.X) &&
                         (test_point.Y > cur_point.Y)))
                    {
                        cur_pgon = pgon;
                        cur_index = index;
                        cur_point = polygons[cur_pgon][cur_index];
                    }
                }
            }

            // Create the result polygon.
            List<PointF> union = new List<PointF>();

            // Start here.
            PointF start_point = cur_point;
            union.Add(start_point);

            // Start traversing the polygons.
            // Repeat until we return to the starting point.
            for (; ; )
            {
                // Find the next point.
                int next_index = (cur_index + 1) % polygons[cur_pgon].Count;
                PointF next_point = polygons[cur_pgon][next_index];

                // Each time through the loop:
                //      cur_pgon is the index of the polygon we're following
                //      cur_point is the last point added to the union
                //      next_point is the next point in the current polygon
                //      next_index is the index of next_point

                // See if this segment intersects
                // any of the other polygon's segments.
                int other_pgon = (cur_pgon + 1) % 2;

                // Keep track of the closest intersection.
                PointF best_intersection = new PointF(0, 0);
                int best_index1 = -1;
                float best_t = 2f;

                for (int index1 = 0; index1 < polygons[other_pgon].Count; index1++)
                {
                    // Get the index of the next point in the polygon.
                    int index2 = (index1 + 1) % polygons[other_pgon].Count;

                    // See if the segment between points index1
                    // and index2 intersect the current segment.
                    PointF point1 = polygons[other_pgon][index1];
                    PointF point2 = polygons[other_pgon][index2];
                    bool lines_intersect, segments_intersect;
                    PointF intersection, close_p1, close_p2;
                    float t1, t2;
                    Geometry.FindIntersection(cur_point, next_point, point1, point2,
                        out lines_intersect, out segments_intersect,
                        out intersection, out close_p1, out close_p2, out t1, out t2);

                    if ((segments_intersect) && // The segments intersect
                        (t1 > 0.001) &&         // Not at the previous intersection
                        (t1 < best_t))          // Better than the last intersection found
                    {
                        // See if this is an improvement.
                        if (t1 < best_t)
                        {
                            // Save this intersection.
                            best_t = t1;
                            best_index1 = index1;
                            best_intersection = intersection;
                        }
                    }
                }

                // See if we found any intersections.
                if (best_t < 2f)
                {
                    // We found an intersection. Use it.
                    union.Add(best_intersection);

                    // Prepare to search for the next point from here.
                    // Start following the other polygon.
                    cur_pgon = (cur_pgon + 1) % 2;
                    cur_point = best_intersection;
                    cur_index = best_index1;
                }
                else
                {
                    // We didn't find an intersection.
                    // Move to the next point in this polygon.
                    cur_point = next_point;
                    cur_index = next_index;

                    // If we've returned to the starting point, we're done.
                    if (cur_point == start_point) break;

                    // Add the current point to the union.
                    union.Add(cur_point);
                }
            }

            return union;
        }
    }
}
