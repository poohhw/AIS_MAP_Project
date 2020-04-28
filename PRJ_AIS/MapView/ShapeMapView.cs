using Catfood.Shapefile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace MapView
{
    public struct customPenStyle
    {
        public const int PS_SOLID = 0;
        public const int PS_DASH = 1;
        public const int PS_DOT = 2;
        public const int PS_DASHDOT = 3;
        public const int NULL_BRUSH = 5;
    }



    public class ShapeMapView : UserControl
    {
        public string FilePath;
        //다시 그리기 변수 true : 다시 그리기, false : 다시 그리기 아님.
        public bool reDraw = true;
        private Shapefile _shapeFile;
        /*Client Screen Value*/
        private double _ClientWidth;
        private double _ClientHeight;
        private PointD _ClientCenter;
        /*Shape File Value*/
        private double _GisWidth;
        private double _GisHeight;
        private PointD _GisCenter;

        private Double _Ratio; // Screen 값과 Shp 파일의 비율
        private Double _ZoomFactor = 1; // 확대 축소 배율 값. 기본 = 1



        //MouseMove 이벤트를 통한 이동값을 저장하는 변수.
        Point movePoint = new Point(0, 0);
        //Client Center Position 으로 부터 변동된 값을 저장하는 변수.
        Point lastPoint = new Point(0, 0);

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            reDraw = true;
            if (e.Delta > 0) _ZoomFactor = _ZoomFactor * 1.2;
            else _ZoomFactor = _ZoomFactor / 1.2;
            Invalidate(true);
            //this.Refresh();
        }

        public Shapefile shapeFile
        {
            set { _shapeFile = value; }
        }
        public ShapeMapView()
        {
            InitializeComponent();
        }


        private void shapeView_Load(object sender, EventArgs e)
        {
            //Shapefile shp = new Shapefile(Path.Combine(Application.StartupPath, "CTPRVN_201905", "TL_SCCO_CTPRVN.shp"));
            //this.shapeFile = shp;
            //this.DrawMap();
            //this.SetStyle(ControlStyles.DoubleBuffer, true);
            //this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            //this.SetStyle(ControlStyles.UserPaint, true);
            //this.UpdateStyles();
        }

        private Bitmap bmp = null;
        private List<ShapePolygon> lstPolygon;
        public void DrawMap()
        {
            if (string.IsNullOrEmpty(FilePath)) return;


            if (reDraw)
            {
                _ClientWidth = this.Width;    //컨트롤 가로
                _ClientHeight = this.Height;  //컨트롤 세로
                _ClientCenter = new PointD(_ClientWidth / 2.0 + lastPoint.X, _ClientHeight / 2.0 + lastPoint.Y);  //스크린 센터 좌표

                if (lstPolygon == null)
                {
                    lstPolygon = new List<ShapePolygon>();
                    shapeFile = new Shapefile(FilePath);

                    _GisWidth = _shapeFile.BoundingBox.Right - _shapeFile.BoundingBox.Left;   //SHAPE 파일 가로
                    _GisHeight = _shapeFile.BoundingBox.Bottom - _shapeFile.BoundingBox.Top;  //SHPAE 파일 세로

                    _GisCenter = new PointD(_GisWidth / 2.0 + _shapeFile.BoundingBox.Left, _GisHeight / 2.0 + _shapeFile.BoundingBox.Top);  //SHAPE 파일 센터 좌표.

                    //비율 구하기
                    double RatioX = _ClientWidth / _GisWidth;
                    double RatioY = _ClientHeight / _GisHeight;

                    if (RatioX < RatioY)
                    {
                        _Ratio = RatioX;
                    }
                    else
                    {
                        _Ratio = RatioY;

                    }

                    foreach (Shape shape in _shapeFile)
                    {
                        switch (shape.Type)
                        {
                            case ShapeType.Polygon:
                                ShapePolygon shapePolygon = shape as ShapePolygon;
                                lstPolygon.Add(shapePolygon);
                                break;
                            default:
                                break;
                        }
                    }
                }


                // if (_shapeFile == null) return;


            }

            using (Graphics g = this.CreateGraphics())
            {
                //LoadView(g);
                LoadView2(g);
                //LodeViewBufferGraphics();
            }

        }
        protected override void OnPaintBackground(PaintEventArgs e)
        {
        }

        /// <summary>
        /// 버퍼에 그리고 완성된 후 뷰.
        /// </summary>
        private void LodeViewBufferGraphics(Graphics g)
        {
            using (BufferedGraphics bufferedGraphics = BufferedGraphicsManager.Current.Allocate(g, ClientRectangle))
            {
                bufferedGraphics.Graphics.Clear(Color.White);
                bufferedGraphics.Graphics.InterpolationMode = InterpolationMode.High;
                bufferedGraphics.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                bufferedGraphics.Graphics.TranslateTransform
                (
                    AutoScrollPosition.X,
                    AutoScrollPosition.Y
                );
                //Pen pen = new Pen(Color.FromArgb(111, 91, 160), 3);
                //bufferedGraphics.Graphics.DrawLine(pen, 0, 0, 100, 100);
                //pen.Dispose();
                foreach (var shape in _shapeFile)
                {
                    switch (shape.Type)
                    {
                        case ShapeType.Polygon:
                            ShapePolygon shapePolygon = shape as ShapePolygon;
                            foreach (var part in shapePolygon.Parts)
                            {
                                List<PointF> points = new List<PointF>();
                                foreach (var point in part)
                                {
                                    float screenX = Convert.ToSingle(GetGisToScreen(point).X);
                                    float screenY = Convert.ToSingle(GetGisToScreen(point).Y);
                                    points.Add(new PointF(screenX, screenY));
                                }
                                bufferedGraphics.Graphics.DrawPolygon(Pens.Black, points.ToArray());
                                //gOff.FillPolygon(Brushes.YellowGreen, points.ToArray());
                                //bufferedgraphic.Graphics.DrawPolygon(Pens.Black, points.ToArray());
                            }
                            break;
                        default:
                            break;
                    }
                }
                bufferedGraphics.Render(g);
                bufferedGraphics.Dispose();
            }
        }

        /// <summary>
        /// BitMap 위에 그래픽 객체를 만들어서 화면에 보여줌.
        /// </summary>

        private void LoadView(Graphics g)
        {
            if (reDraw)
            {
                bmp = new Bitmap((int)_ClientWidth, (int)_ClientHeight);
                using (Graphics gOff = Graphics.FromImage(bmp))
                {
                    gOff.FillRectangle(new SolidBrush(Color.FromArgb(255,178,209,255)), 0, 0, bmp.Width, bmp.Height);
                    gOff.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    gOff.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;

                    foreach (ShapePolygon item in lstPolygon)
                    {
                        foreach (PointD[] polygon in item.Parts)
                        {
                            List<PointF> points = new List<PointF>();
                            foreach (PointD point in polygon)
                            {
                                float screenX = Convert.ToSingle(GetGisToScreen(point).X);
                                float screenY = Convert.ToSingle(GetGisToScreen(point).Y);

                                points.Add(new PointF(screenX, screenY));
                            }
                            PointF[] pointscoord = points.ToArray();
                            gOff.DrawPolygon(new Pen(Color.FromArgb(247,184,95)), pointscoord);
                            gOff.FillPolygon(new SolidBrush(Color.FromArgb(242, 237, 231)), pointscoord);
                        }
                    }

                    g.DrawImage(bmp, 0, 0);

                }
            }
            else
            {
                g.Clear(Color.FromArgb(255, 178, 209, 255));
                g.DrawImage(bmp, movePoint.X, movePoint.Y);

                //reDraw = false;
            }
            g.Dispose();
        }

        protected static int ColorToGDIColor(Color c)
        {
            int color = 0;
            color = c.B & 0xff;
            color = (color << 8) | (c.G & 0xff);
            color = (color << 8) | (c.R & 0xff);
            return color;
        }

        private void LoadView2(Graphics g)
        {
            IntPtr dc = IntPtr.Zero;
            IntPtr selectPen = IntPtr.Zero;
            IntPtr selectBrush = IntPtr.Zero;

            if (reDraw)
            {
                //펜 색
                selectPen = NativeGDI.CreatePen(customPenStyle.PS_SOLID, 1, ColorToGDIColor(Color.FromArgb(165,165,165)));
                //배경 색
                selectBrush = NativeGDI.CreateSolidBrush(ColorToGDIColor(Color.FromArgb(255,178,125)));

                bmp = new Bitmap((int)_ClientWidth, (int)_ClientHeight);
                using (Graphics gOff = Graphics.FromImage(bmp))
                {
                    gOff.FillRectangle(new SolidBrush(Color.FromArgb(255, 178, 209, 255)), 0, 0, bmp.Width, bmp.Height);
                    gOff.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    gOff.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;

                    dc = gOff.GetHdc();

                    NativeGDI.SelectObject(dc, selectPen);
                    NativeGDI.SelectObject(dc, selectBrush);


                    foreach (ShapePolygon item in lstPolygon)
                    {
                        foreach (PointD[] polygon in item.Parts)
                        {
                            List<Point> points = new List<Point>();
                            foreach (PointD point in polygon)
                            {
                                int screenX = Convert.ToInt32(GetGisToScreen(point).X);
                                int screenY = Convert.ToInt32(GetGisToScreen(point).Y);

                                points.Add(new Point(screenX, screenY));
                            }
                            Point[] pointscoord = points.ToArray();

                            NativeGDI.DrawPolygon(dc, pointscoord, pointscoord.Length);
                        }
                    }

                    
                    reDraw = false;
                    NativeGDI.DeleteDC(dc);
                    NativeGDI.DeleteDC(selectPen);
                    NativeGDI.DeleteDC(selectBrush);
                    Invalidate();

                }
            }
            else
            {
                g.Clear(Color.FromArgb(255, 178, 209, 255));
                g.DrawImage(bmp, movePoint.X, movePoint.Y);
              
            }
           
            //g.Dispose();
        }

        /// <summary>
        /// Shape 파일 좌표 - > Screen 좌표.
        /// </summary>
        /// <param name="pGisPoint">Shp 좌표</param>
        /// <returns></returns>
        public PointD GetGisToScreen(PointD pGisPoint)
        {
            PointD screenPoint;

            screenPoint.X = _Ratio * (pGisPoint.X - _GisCenter.X) * _ZoomFactor + _ClientCenter.X;
            screenPoint.Y = _Ratio * (_GisCenter.Y - pGisPoint.Y) * _ZoomFactor + _ClientCenter.Y;


            return screenPoint;
        }

        /// <summary>
        /// Screen좌표 - > Shape 파일 좌표.
        /// </summary>
        /// <param name="pScreenPoint">화면 좌표</param>
        /// <returns></returns>
        public PointD GetScreenToGis(Point pScreenPoint)
        {
            PointD GisPoint;

            GisPoint.X = _GisCenter.X + (pScreenPoint.X - _ClientCenter.X) / (_ZoomFactor * _Ratio);
            GisPoint.Y = _GisCenter.Y - (pScreenPoint.Y - _ClientCenter.Y) / (_ZoomFactor * _Ratio);

            return GisPoint;
        }

        public PointD ConvertCRS(PointD pPoint)
        {
            PointD CRSPoint;

            double[] xy = CrazyCRS.CrazyCRS.ConvertCRS(pPoint.X, pPoint.Y, CrazyCRS.CrazyCRS.PROJ4.TMERC, CrazyCRS.CrazyCRS.PROJ4.LONGLAT); 
            
            CRSPoint.X = xy[0];
            CRSPoint.Y = xy[1];
            
            return CRSPoint;
        }

        public PointD ConvertLongLatToScreen(PointD pPoint)
        {
            PointD CRSPoint;

            double[] xy = CrazyCRS.CrazyCRS.ConvertCRS(pPoint.X, pPoint.Y, CrazyCRS.CrazyCRS.PROJ4.LONGLAT, CrazyCRS.CrazyCRS.PROJ4.TMERC);

            CRSPoint.X = xy[0];
            CRSPoint.Y = xy[1];

            return GetGisToScreen(CRSPoint);
        }




        private bool isMouseDown = false;
        private Point clickPoint;
        private void shapeView_MouseDown(object sender, MouseEventArgs e)
        {
            isMouseDown = true;
            clickPoint = new Point(e.X, e.Y);

        }


        private void shapeView_MouseUp(object sender, MouseEventArgs e)
        {

            isMouseDown = false;

            lastPoint.X += movePoint.X;
            lastPoint.Y += movePoint.Y;

            movePoint.X = 0;
            movePoint.Y = 0;

            //마우스 드래그 드롭 이벤트가 끝나면 맵을 다시 그린다.
            reDraw = true;
            Invalidate();
        }


        private void shapeView_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                reDraw = false;               
                movePoint = new Point((e.X - clickPoint.X), (e.Y - clickPoint.Y));
                Invalidate();
             
            }
            else
            {
                PointD coord = GetScreenToGis(e.Location);
            }
        }

        private void shapeView_Paint(object sender, PaintEventArgs e)
        {
            this.DrawMap();
        }

        /// <summary>
        /// 더블 버퍼링 대신 사용하는, 화면 깜박임 방지.
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // ShapeMapView
            //         

            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.Name = "ShapeMapView";
            this.Size = new System.Drawing.Size(476, 353);
            this.Load += new System.EventHandler(this.shapeView_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.shapeView_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.shapeView_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.shapeView_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.shapeView_MouseUp);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

