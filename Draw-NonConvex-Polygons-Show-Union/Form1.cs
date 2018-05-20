using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Drawing2D;
using Domain;
using Services;
using GeometryHelper;

namespace Draw_NonConvex_Polygons_Show_Union
{
    public partial class Form1 : Form
    {
        private readonly IOperation _IOperation;

        public Form1(IOperation IOperation)  //Dependency Injection
        {
            _IOperation = IOperation;

            InitializeComponent();
            polygons = new Polygons();

            //Create initial instances of two polygons
            polygons.Add(Factory.Factory.Instance());
            polygons.Add(Factory.Factory.Instance());
        }

        // The two polygons' points.
        private Polygons polygons;


        // The polygons' colors.
        private Color[] PolygonColors =
        {
            Color.Blue,
            Color.Green,
        };

        // The current mouse position while drawing a polygon.
        private PointF CurrentLocation;

        // The number of the polyon we are building if any.
        private int MakingIndex = -1;

        // The polygon checkboxes.
        private CheckBox[] PolygonCheckboxes;

        // Make two test polygons.
        private void Form1_Load(object sender, EventArgs e)
        {
            PolygonCheckboxes = new CheckBox[]
            {
                chkPolygon1,
                chkPolygon2,
            };

            //1st polygon
            polygons[0] = Factory.Factory.Instance();

            polygons[0].Add(new PointF(136, 75));
            polygons[0].Add(new PointF(64, 125));
            polygons[0].Add(new PointF(171, 181));
            polygons[0].Add(new PointF(140, 97));
            polygons[0].Add(new PointF(199, 102));
            polygons[0].Add(new PointF(183, 158));
            polygons[0].Add(new PointF(242, 127));
            polygons[0].Add(new PointF(184, 44));
            polygons[0].Add(new PointF(60, 59));

            //2nd polygon
            polygons[1] = Factory.Factory.Instance();

            polygons[1].Add(new PointF(115, 34));
            polygons[1].Add(new PointF(146, 198));
            polygons[1].Add(new PointF(181, 114));
            polygons[1].Add(new PointF(217, 162));
            polygons[1].Add(new PointF(249, 73));
            polygons[1].Add(new PointF(179, 20));
            polygons[1].Add(new PointF(146, 69));
        }

        // Start or continue defining a polygon.
        private void picCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (MakingIndex < 0)
            {
                // Start a new polygon.
                if (e.Button == MouseButtons.Left) MakingIndex = 0;
                else MakingIndex = 1;

                polygons[MakingIndex] = Factory.Factory.Instance();
                polygons[MakingIndex].Add(e.Location);
                CurrentLocation = e.Location;
            }
            else
            {
                // Add a new point to the current new polygon.
                if (polygons[MakingIndex][polygons[MakingIndex].Count - 1] != e.Location)
                    polygons[MakingIndex].Add(e.Location);
                CurrentLocation = e.Location;
            }

            // Redraw to show changes.
            picCanvas.Refresh();
        }

        // Continue defining a polygon.
        private void picCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (MakingIndex < 0) return;
            CurrentLocation = e.Location;
            picCanvas.Refresh();
        }

        // Finish defining this polygon.
        private void picCanvas_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // See if we have a polygon.
            if (polygons[MakingIndex].Count < 3)
            {
                // Discard this polygon.
                polygons[MakingIndex] = Factory.Factory.Instance();
            }
            else
            {
                // Make sure the polygon is oriented
                // counter clockwise.
                Geometry.OrientPolygonCounterclockwise(polygons[MakingIndex]);
            }

            // We're no longer making a polygon.
            MakingIndex = -1;
            picCanvas.Refresh();
        }

        // Draw the polygons and their union.
        private void picCanvas_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(picCanvas.BackColor);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // If we have both polygons, draw the union.
            if ((MakingIndex < 0) &&
                (polygons[0].Count > 2) &&
                (polygons[1].Count > 2) &&
                (chkUnion.Checked))
            {
                // Find the union.
                List<PointF> union = _IOperation.FindPolygonUnion(polygons);

                // Draw it.
                using (Pen pen = new Pen(Color.Black, 10))
                {
                    e.Graphics.DrawPolygon(pen, union.ToArray());
                }
            }

            // Draw the polygons.
            for (int i = 0; i < 2; i++)
            {
                if (PolygonCheckboxes[i].Checked)
                {
                    // See if we are making this polygon.
                    if (i == MakingIndex)
                    {
                        // We are. Draw the segments so far.
                        if (polygons[i].Count > 1)
                            using (Pen pen = new Pen(PolygonColors[i], 3))
                            {
                                e.Graphics.DrawLines(pen,
                                    polygons[i].ToArray());
                            }

                        // Draw to the mouse's current location.
                        if (polygons[i].Count > 0)
                        {
                            PointF point1 = polygons[i][polygons[i].Count - 1];
                            e.Graphics.DrawLine(Pens.Green,
                                point1.X, point1.Y,
                                CurrentLocation.X, CurrentLocation.Y);
                        }
                    }
                    else
                    {
                        // We're not making this polygon. Draw it.
                        if (polygons[i].Count > 2)
                        {
                            Color fill_color = Color.FromArgb(128, PolygonColors[i]);
                            using (Brush brush = new SolidBrush(fill_color))
                            {
                                e.Graphics.FillPolygon(brush,
                                    polygons[i].ToArray());
                            }
                            using (Pen pen = new Pen(PolygonColors[i], 3))
                            {
                                e.Graphics.DrawPolygon(pen,
                                    polygons[i].ToArray());
                            }
                        }
                    }
                }
            }
        }

        // Draw a polygon or a partial polygon.
        private void DrawPolygon(List<PointF> polygon, Color color)
        {
        }

        // Display the polygon's points so we can recreate it later.
        private void ShowPolygon(List<PointF> polygon)
        {
            Console.WriteLine("            polygon = new List<PointF>(new PointF[]");
            Console.WriteLine("                {");
            foreach (PointF point in polygon)
            {
                Console.WriteLine("                    new PointF(" +
                    point.X.ToString("0") + ", " +
                    point.Y.ToString("0") + "),");
            }
            Console.WriteLine("                });");
        }

        // Redraw to show the selected polygons.
        private void chk_CheckedChanged(object sender, EventArgs e)
        {
            picCanvas.Refresh();
        }
    }
}
