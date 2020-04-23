using EGIS.ShapeFileLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShpViewer
{
    public partial class Form1 : Form
    {
        private EGIS.ShapeFileLib.PointD marker2 = new EGIS.ShapeFileLib.PointD(0, 0);  //#.Marker좌표.
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                OpenShapefile(Application.StartupPath + "\\CTPRVN_201905\\TL_SCCO_CTPRVN.shp");
                sfMap1[0].RenderSettings.FieldName = "ROAD_NAME";
                sfMap1[0].RenderSettings.Font = new Font(this.Font.FontFamily, 8);
                //sfMap1.ZoomLevel *= 2;
                //ProcessGPSData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void OpenShapefile(string path)
        {
            // clear any shapefiles the map is currently displaying
            this.sfMap1.ClearShapeFiles();
            
            // open the shapefile passing in the path, display name of the shapefile and
            // the field name to be used when rendering the shapes (we use an empty string
            // as the field name (3rd parameter) can not be null)
            this.sfMap1.AddShapeFile(path, "ShapeFile", "");
            
            // read the shapefile dbf field names and set the shapefiles's RenderSettings
            // to use the first field to label the shapes.
            EGIS.ShapeFileLib.ShapeFile sf = this.sfMap1[0];
            sf.RenderSettings.FieldName = sf.RenderSettings.DbfReader.GetFieldNames()[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sfMap1.ZoomLevel *= 1.5;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sfMap1.ZoomLevel /= 1.5;
        }

        IList<PointD> listPoint = new List<PointD>();
        private void sfMap1_MouseClick(object sender, MouseEventArgs e)
        {
            label2.Text = sfMap1.PixelCoordToGisPoint(e.Location).ToString();

            marker2.X = sfMap1.PixelCoordToGisPoint(e.Location).X;
            marker2.Y = sfMap1.PixelCoordToGisPoint(e.Location).Y;

            listPoint.Add(marker2);

            sfMap1.Refresh();

        }

        private void sfMap1_MouseMove(object sender, MouseEventArgs e)
        {
            label3.Text = sfMap1.PixelCoordToGisPoint(e.Location).ToString();
        }

        private const int MarkerWidth = 20;
        private void DrawMarker(Graphics g, double locX, double locY)
        {
            //convert the gis location to pixel coordinates
            Point pt = sfMap1.GisPointToPixelCoord(locX, locY);

            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            //draw a marker centered at the gis location
            //alternative is to draw an image/icon
           // g.DrawLine(Pens.Aqua, pt.X, pt.Y - MarkerWidth, pt.X, pt.Y + MarkerWidth);
           //g.DrawLine(Pens.Aqua, pt.X - MarkerWidth, pt.Y, pt.X + MarkerWidth, pt.Y);
            pt.Offset(-MarkerWidth / 2, -MarkerWidth / 2);
            //g.FillEllipse(Brushes.Yellow, pt.X, pt.Y, MarkerWidth, MarkerWidth);
            //g.DrawEllipse(Pens.Aqua, pt.X, pt.Y, MarkerWidth, MarkerWidth);

            Rectangle rect = new Rectangle(pt.X, pt.Y, MarkerWidth, MarkerWidth);
            g.DrawPie(Pens.BlueViolet, rect, 90, 45);
            g.FillPie(Brushes.BlueViolet, rect, 90, 45);

        }

 
        private void sfMap1_Paint(object sender, PaintEventArgs e)
        {
            //marker2.X = 129.01875;
            //marker2.Y = 35.011777;
            //DrawMarker(e.Graphics, marker2.X, marker2.Y);
            foreach (PointD point in listPoint)
            {
                DrawMarker(e.Graphics, point.X, point.Y);
            }
        }

        private void label2_DoubleClick(object sender, EventArgs e)
        {
            Clipboard.SetText(label2.Text);
        }

        private void btnInit_Click(object sender, EventArgs e)
        {
            listPoint.Clear();
            sfMap1.Refresh();
        }
    }
}
