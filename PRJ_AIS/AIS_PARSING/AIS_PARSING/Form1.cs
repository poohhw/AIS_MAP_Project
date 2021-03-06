﻿
using Catfood.Shapefile;
using CrazyCRS;
using MapView;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace AIS_PARSING
{

    public partial class Form1 : Form
    {
        /* AIS 수신 관련 전역변수 */
        private static int[] DataLenArray = new int[] { 6, 2, 30, 4, 8, 10, 1, 28, 27, 12, 9, 6, 2, 3, 1, 19 };
        private static byte[] readBuffer;
        private StringBuilder sb = new StringBuilder();
        private Socket client;
        private JObject json;

        /* 맵 그리기 관련 전역 변호 */
        private const int MarkerWidth = 20;  //마커 사이즈
        //private EGIS.ShapeFileLib.PointD marker2 = new EGIS.ShapeFileLib.PointD(0, 0);  //#.Marker좌표.
        //private IList<PointD> listPoint = new List<PointD>();  //마커 좌표 어레이 객체

        private List<AIS_Data> lstData = new List<AIS_Data>();

        public Form1()
        {
            InitializeComponent();
            shapeMapView1.FilePath = Path.Combine(Application.StartupPath, "CTPRVN_201905", "TL_SCCO_CTPRVN.shp");
            using (StreamReader r = new StreamReader(@"AIS.json"))
            {
                string json2 = r.ReadToEnd();
                json = JObject.Parse(json2);
            }
            toolTip1.SetToolTip(label7, "설정한 분 후 도착위치를 맵에 화살표로 표시합니다.");
        }


        private void btnAIS_Click(object sender, EventArgs e)
        {
            Grid1.Rows.Clear();
            txtData.Text = string.Empty;

            client = new Socket(SocketType.Stream, ProtocolType.Tcp);
            //비동기 소켓 연결.
            client.BeginConnect("127.0.0.1", 7000, Connect, client);

            timer1.Enabled = true;
        }

        /// <summary>
        /// 연결 완료 콜백
        /// </summary>
        /// <param name="result"></param>
        private void Connect(IAsyncResult result)
        {
            readBuffer = new byte[1024];
            Socket client = (Socket)result.AsyncState;
            client.EndConnect(result);

            //byte[] byteMsg = Encoding.Default.GetBytes("1");
            //client.Send(byteMsg, 0, byteMsg.Length,SocketFlags.None);
            client.BeginReceive(readBuffer, 0, readBuffer.Length, SocketFlags.None, Receive, client);

        }
        /// <summary>
        /// 수신 완료 콜백
        /// </summary>
        /// <param name="result"></param>
        private void Receive(IAsyncResult result)
        {
            Socket client = (Socket)result.AsyncState;
            if (client.Connected)
            {
                int size = client.EndReceive(result);

                string data = Encoding.ASCII.GetString(readBuffer, 0, size);
                sb.Append(data);

                client.BeginReceive(readBuffer, 0, readBuffer.Length, SocketFlags.None, Receive, client);
            }
        }

        public string GetLastResult(string pValue, int idx, AIS_Data pData)
        {
            string vReturn = string.Empty;
            switch (idx.ToString())
            {
                case "0":  //Message Type         
                    vReturn = Convert.ToInt32(pValue, 2).ToString("00");
                    vReturn = "[" + vReturn + "]" + json["MessageType"][vReturn].ToString();
                    pData.MessageType = vReturn;
                    break;
                case "1": //Repeat Indicator
                    vReturn = Convert.ToInt32(pValue, 2).ToString("00");
                    pData.RepeatIndicator = vReturn;
                    break;
                case "2": //MMSI
                    vReturn = Convert.ToInt32(pValue, 2).ToString("00");
                    pData.MMSI = vReturn;
                    break;
                case "3": //Navigation Status        
                    vReturn = Convert.ToInt32(pValue, 2).ToString("00");
                    vReturn = "[" + vReturn + "]" + json["Navigation Status"][vReturn].ToString();
                    pData.NavigationStatus = vReturn;
                    break;
                case "4": //ROT
                    vReturn = Convert.ToInt32(pValue, 2).ToString("00");
                    double dReturn = Convert.ToDouble(vReturn);

                    if (dReturn == 128)
                    {
                        vReturn = "회전 정보 없음";
                    }
                    else
                    {
                        //부호가져오기.
                        int nSign = Math.Sign(dReturn);
                        vReturn = (Math.Pow(dReturn / 4.733, 2) * nSign).ToString();
                    }
                    pData.ROT = vReturn;
                    break;
                case "5":
                    vReturn = Convert.ToInt32(pValue, 2).ToString("00");
                    vReturn = (Convert.ToDouble(vReturn) / 10.0).ToString();
                    pData.SOG = vReturn;
                    break;
                case "6": //Position
                    vReturn = Convert.ToInt32(pValue, 2).ToString("00");
                    if (vReturn == "00")
                    {
                        vReturn = string.Format("[{0}]{1}", vReturn, "FALSE");
                    }
                    else
                    {
                        vReturn = string.Format("[{0}]{1}", vReturn, "TRUE");
                    }
                    pData.PositionAccuracy = vReturn;
                    break;
                case "7": //경도(Longitude)
                    vReturn = Convert.ToInt32(pValue, 2).ToString("00");

                    //음수 양수 구분법.(부호비트가 0 일때)
                    if (pValue.StartsWith("0"))
                    {
                        vReturn = (Math.Round((Convert.ToDouble(vReturn) / 600000.0), 5, MidpointRounding.ToEven)).ToString();
                    }
                    else
                    {
                        string vBosuBinary = ConvertBosu(pValue);
                        vReturn = (Convert.ToInt32(vBosuBinary, 2)).ToString("00");
                        vReturn = "-" + (Math.Round(Convert.ToDouble(vReturn) / 600000.0, 5, MidpointRounding.AwayFromZero)).ToString();
                    }
                    pData.Longitude = vReturn;

                    break;

                case "8": //위도(Latitude)
                    vReturn = Convert.ToInt32(pValue, 2).ToString("00");
                    //음수 양수 구분법.(부호비트가 0 일때)
                    if (pValue.StartsWith("0"))
                    {
                        vReturn = (Math.Round(Convert.ToDouble(vReturn) / 600000.0, 6, MidpointRounding.ToEven)).ToString();
                    }
                    else
                    {
                        string vBosuBinary = ConvertBosu(pValue);
                        vReturn = (Convert.ToInt32(vBosuBinary, 2) - 1).ToString("00");
                        vReturn = "-" + (Math.Round(Convert.ToDouble(vReturn) / 600000.0, 6, MidpointRounding.AwayFromZero)).ToString();
                    }

                    pData.Latitude = vReturn;
                    break;

                case "9"://COG
                    vReturn = Convert.ToInt32(pValue, 2).ToString("00");
                    vReturn = (Convert.ToDouble(vReturn) / 10.0).ToString();
                    pData.COG = vReturn;
                    break;
                case "10"://HDG
                    vReturn = Convert.ToInt32(pValue, 2).ToString("00");
                    pData.HDG = vReturn;
                    break;
                case "11": //Second of TimeStamp
                    vReturn = Convert.ToInt32(pValue, 2).ToString("00");
                    int nTimeStamp = Convert.ToInt32(vReturn);
                    if (nTimeStamp >= 60)
                    {
                        switch (nTimeStamp)
                        {
                            case 60:
                                vReturn = "time stamp is not available";
                                break;
                            case 61:
                                vReturn = "positioning system is in manual input mode";
                                break;
                            case 62:
                                vReturn = "Electronic Position Fixing System operates in estimated (dead reckoning) mode";
                                break;
                            case 63:
                                vReturn = "the positioning system is inoperative";
                                break;
                        }
                    }
                    else
                    {
                        vReturn = vReturn + "초";
                    }
                    pData.TimeStamp = vReturn;

                    break;
                case "12": //Maneuver Indicator
                    vReturn = Convert.ToInt32(pValue, 2).ToString("00");
                    pData.ManeuverIndicator = vReturn;
                    break;
                case "13": //Spare
                    vReturn = Convert.ToInt32(pValue, 2).ToString("00");
                    pData.Spare = vReturn;
                    break;
                case "14": //RAIM flag
                    vReturn = Convert.ToInt32(pValue, 2).ToString("00");
                    pData.RAIMflag = vReturn;
                    break;
                case "15": //Radio status
                    vReturn = Convert.ToInt32(pValue, 2).ToString("00");
                    pData.RadioStatus = vReturn;
                    break;
                default:
                    vReturn = Convert.ToInt32(pValue, 2).ToString("00");
                    break;

            }

            return vReturn;
        }

        public string GetASCII(string pOrigin, int pIdx, int nLength)
        {
            return pOrigin.Substring(pIdx, nLength);
        }

        public string[] GetDataPayloadBinary(string pOrigin)
        {
            IList<string> data = new List<string>();
            int nStartIndex = 0;

            foreach (int len in DataLenArray)
            {
                data.Add(pOrigin.Substring(nStartIndex, len));
                nStartIndex = nStartIndex + len;
            }

            return data.ToArray();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Parsing(txtData.Text);
        }

        private void Parsing(string pValue)
        {
            try
            {
                string[] arrValue = pValue.Split(new string[] { "," }, StringSplitOptions.None);


                if (arrValue.Length == 7)
                {
                    if (arrValue[1] != "1") return;

                    string pDataPayload = string.Empty;

                    //6개 일때 정상 데이터로 간주하고.
                    txtData.Text += pValue + Environment.NewLine;
                    //payload
                    string vPayload = arrValue[5];

                    int i = 0;
                    //문자열을 바이너리 값으로 치환.
                    foreach (char c in vPayload)
                    {
                        int charCode = Convert.ToInt32(c) - 48;

                        if (charCode > 40)
                        {
                            charCode = charCode - 8;
                        }

                        //if (RetS.Length > 0)
                        //    RetS += ",";
                        string vBinaryCode = Convert.ToInt32(Convert.ToString(charCode, 2)).ToString("000000");

                        pDataPayload += vBinaryCode;
                        i++;
                    }

                    //label1.Text = i.ToString();
                    //txtPayload.Text = pDataPayload;



                    string[] vResult = GetDataPayloadBinary(pDataPayload);

                    //4("원본:" + pDataPayload.Length.ToString());


                    int nRow = Grid1.Rows.Add();

                    AIS_Data vData = new AIS_Data();
                    for (int j = 0; j < vResult.Length; j++)
                    {
                        Grid1.Rows[nRow].Cells[j].Value = GetLastResult(vResult[j], j, vData);
                    }

                    lstData.Add(vData);

                }
            }

            catch (Exception ex)
            {
                //Console.WriteLine("ERROR: {0}:{1}", ex.Message, pValue);
                //MessageBox.Show(ex.Message);
            }
        }


        public string ConvertBosu(string pBinary)
        {
            string vReturn = string.Empty;

            string[] Reserve = new string[pBinary.Length];


            //1.1의 보수 구하기
            for (int i = 0; i < pBinary.Length; i++)
            {
                char a = pBinary[i];
                Reserve[i] = (1 - Convert.ToInt16(pBinary[i] - 48)).ToString();
            }

            //2. 2의 보수 구하기.
            Reserve = UpTO(Reserve, Reserve.Length - 1);

            vReturn = string.Join("", Reserve);
            return vReturn;
        }

        public string[] UpTO(string[] pReserve, int idx)
        {
            if (Convert.ToInt32(pReserve[idx]) + 1 > 1)
            {
                UpTO(pReserve, idx - 1);
            }
            else
            {
                pReserve[idx] = (Convert.ToInt32(pReserve[idx]) + 1).ToString();
            }

            return pReserve;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                PasingAndDraw();
            }
            catch (Exception ex)
            {
                //
            }
        }

        private void PasingAndDraw()
        {
            string strAIS = sb.ToString();
            sb.Clear();
            string[] arrAIS = strAIS.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);


            foreach (string vAIS in arrAIS)
            {
                //#.체크섬 검증.
                if (AISChecksum(vAIS))
                {
                    Parsing(vAIS);
                }
            }

            shapeMapView1.Invalidate();
        }

        private bool AISChecksum(string pData)
        {
            if (!pData.Contains("*")) return false;
            //[0] : Data  [1] : CheckSum
            string[] arrData = pData.Split(new string[] { "*" }, StringSplitOptions.None);

            int nCheckSum = 0;

            arrData[0] = arrData[0].Replace("!", string.Empty);

            foreach (char c in arrData[0])
            {
                nCheckSum ^= Convert.ToByte(c);
            }
            //수신된 체크섬 값            
            string hex = Convert.ToInt32(arrData[1], 16).ToString();

            //수신된 값과 계산한 체크섬 값을 비교해서 일치하면 true / 불일치 하면 false;
            return hex.Equals(nCheckSum.ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (client == null || !client.Connected) return;
            //소켓 종료
            client.Shutdown(SocketShutdown.Both);
            client.BeginDisconnect(true, new AsyncCallback(DisconnectCallback), client);

            timer1.Enabled = false;
        }
        private static void DisconnectCallback(IAsyncResult result)
        {
            // Complete the disconnect request.
            Socket client = (Socket)result.AsyncState;
            client.EndDisconnect(result);

            // Signal that the disconnect is complete.
            //Console.WriteLine(client.Connected.ToString());
        }


        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void shapeMapView1_MouseClick(object sender, MouseEventArgs e)
        {
            PointD GisPointD = shapeMapView1.GetScreenToGis(e.Location);
            PointD WGS8s = shapeMapView1.ConvertCRS(GisPointD);

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("[Screen]:X:{0},Y:{1} ", e.Location.X.ToString(), e.Location.Y.ToString());
            sb.AppendFormat("[Shape]:X:{0},Y:{1} ", GisPointD.X.ToString(), GisPointD.Y.ToString());
            sb.AppendFormat("[LongLat]:X:{0},Y:{1} ", WGS8s.X.ToString(), WGS8s.Y.ToString());
            label2.Text = sb.ToString();


        }

        private bool CompareColor(Color src, Color dest)
        {
            //두 색상 구조체의 ARGB 값만 비교한다.
            bool bReturn = src.ToArgb().Equals(dest.ToArgb());
            return bReturn;
        }


        private void shapeMapView1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.CompositingQuality = CompositingQuality.HighQuality;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Image img = Properties.Resources.ship3;

            if (shapeMapView1.isMouseDown) return;

            foreach (var item in lstData)
            {
                if (item.MessageType.Contains("[03]") || item.MessageType.Contains("[01]"))
                {
                    try
                    {
                        PointD point = new PointD();
                        point.X = Convert.ToDouble(item.Longitude);
                        point.Y = Convert.ToDouble(item.Latitude);
                        PointD screenPoint = shapeMapView1.ConvertLongLatToScreen(point);

                        Color bgColor = ScreenColor((int)screenPoint.X, (int)screenPoint.Y);

                        if (!CompareColor(bgColor, shapeMapView1.BGColor)) //Color.FromArgb(255, 178, 209, 255)
                        {
                            //수신 좌표가 위치가 바다가 아닐 경우 그리지 않는다.
                            continue;
                        }

                        Console.WriteLine("배경색:" + bgColor.ToString());

                        Matrix m = e.Graphics.Transform;

                        PointF p = new PointF((float)screenPoint.X, (float)screenPoint.Y);
                        Matrix matrix = new Matrix();
                        matrix.RotateAt(Convert.ToSingle(item.COG), p);
                        e.Graphics.Transform = matrix;




                        item.ScreenX = screenPoint.X.ToString();
                        item.ScreenX = screenPoint.Y.ToString();


                        Rectangle rc = new Rectangle((int)(Math.Round(screenPoint.X, 2)), (int)Math.Round(screenPoint.Y, 2), 10, 10);


                        item.rcImage = rc;


                        PointD SOGpointD = SOGConvertScreen(item.Longitude, item.Latitude, item.SOG, Convert.ToDouble(numericUpDown1.Value));

                        PointF SOGpoint = new PointF((float)SOGpointD.X, (float)SOGpointD.Y);

                        PointF screenPointF = new PointF(Convert.ToSingle(Math.Round(screenPoint.X, 2)), Convert.ToSingle(Math.Round(screenPoint.Y, 2)));



                        RectangleF SOGrect = new RectangleF(SOGpoint, new SizeF(10, 10));  //SOG 사각형.


                        RectangleF ScreenRect = new RectangleF(screenPointF, new SizeF(10, 10)); //Ship 사각형.


                        //e.Graphics.DrawRectangle(Pens.DarkGreen, SOGpoint.X, SOGpoint.Y, 10, ScreenRect.Y - SOGrect.Y + 10);
                        //e.Graphics.DrawRectangle(Pens.Red,ScreenRect.X,ScreenRect.Y,10,10);



                        //SOG 좌표랑 현재 좌표량 연결.
                        using (Pen pen = new Pen(Color.FromArgb(68, 114, 196), 1))
                        {
                            pen.EndCap = LineCap.ArrowAnchor;
                            e.Graphics.DrawLine(pen, ScreenRect.X, ScreenRect.Y, SOGpoint.X, SOGpoint.Y);
                        }
                        e.Graphics.DrawImage(img, ScreenRect.X - (ScreenRect.Width / 2), ScreenRect.Y, 10, 20);
                        //e.Graphics.DrawRectangle(Pens.Blue, rc);
                        e.Graphics.Transform = m;

                    }
                    catch (Exception ex)
                    {
                        //Console.WriteLine(item.MMSI + "," + item.Latitude + "," + item.Longitude);
                    }
                }
            }

        }

        /// <summary>
        /// SOG 노트 값으로 스크린 좌표 구하기.
        /// </summary>
        /// <param name="pLong">경도</param>
        /// <param name="pLat">위도</param>
        /// <param name="pMin">분(시간) default = 60Min</param>
        /// <returns></returns>
        private PointD SOGConvertScreen(string pLong, string pLat, string pSOG, double pMin = 60d)
        {
            //#1. Latitude(위도)값을 도분 형식으로 변경
            ConvertCoordinateUtil util = new ConvertCoordinateUtil();
            LongLat longLat = util.ConvertDoBun(pLat);
            //#2. 분 값에 노트(SOG) 값을 더함.
            LongLat longLat2 = new LongLat();
            longLat2.Degree = longLat.Degree;
            longLat2.Min = longLat.Min + ((Convert.ToDouble(pSOG) / 60) * pMin);

            //#3. 다시 도 형식으로 변경
            string vLat = util.ConvertDo(longLat2);

            //#4. SHP 좌표로 변환
            PointD point = new PointD(Convert.ToDouble(pLong), Convert.ToDouble(vLat));
            point = shapeMapView1.ConvertLongLatToScreen(point);
            //#5. 스크린 좌표로 변환 후 리턴.

            return point;
        }

        private void shapeMapView1_DoubleClick(object sender, EventArgs e)
        {

        }

        private void shapeMapView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            txtDetail.Text = string.Empty;

            StringBuilder sb = new StringBuilder();

            foreach (var item in lstData)
            {

                if (item.rcImage.Contains(e.Location))
                {
                    sb.AppendLine("----------------------");
                    sb.AppendLine("MMSI : " + item.MMSI);
                    sb.AppendLine("ROT : " + item.ROT);
                    sb.AppendLine("SOG : " + item.SOG);
                    sb.AppendLine("COG : " + item.COG);
                    sb.AppendLine("LONG : " + item.Longitude);
                    sb.AppendLine("LAT : " + item.Latitude);
                }
            }


            txtDetail.AppendText(sb.ToString());


        }



        int nSecond = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            PasingAndDraw();
            nSecond += timer1.Interval;

            if (nSecond >= 60000 * 3)
            {
                //3분마다 수신 정보 초기화.
                lstData.Clear();
                nSecond = 0;
            }

        }

        private void shapeMapView1_Resize(object sender, EventArgs e)
        {
            shapeMapView1.reDraw = true;
            shapeMapView1.Refresh();
        }

        private void label3_Click(object sender, EventArgs e)
        {

            Application.Exit();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void label5_Click_1(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
                label5.Text = "▣";
            }
            else if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
                label5.Text = "□";
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void label3_MouseHover(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            lbl.BackColor = Color.FromArgb(62, 109, 181);

        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            lbl.BackColor = Color.Transparent;
        }

        Point selectPoint = new Point(0, 0);
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                selectPoint = e.Location;
            }
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Location = new Point(this.Location.X + e.X - selectPoint.X, this.Location.Y + e.Y - selectPoint.Y);
            }
        }

        private void panel1_DoubleClick(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
                label5.Text = "▣";
            }
            else if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
                label5.Text = "□";
            }
        }

        private void shapeMapView1_MouseMove(object sender, MouseEventArgs e)
        {
            PointD GisPointD = shapeMapView1.GetScreenToGis(e.Location);

            PointD WGS8s = shapeMapView1.ConvertCRS(GisPointD);
            StringBuilder sb = new StringBuilder();
            //sb.AppendFormat("[Color]:{0}", ScreenColor(e.X, e.Y).Name);
            sb.AppendFormat("[Screen]:X:{0},Y:{1} ", e.Location.X.ToString(), e.Location.Y.ToString());
            sb.AppendFormat("[Shape]:X:{0},Y:{1} ", GisPointD.X.ToString(), GisPointD.Y.ToString());
            sb.AppendFormat("[LongLat]:X:{0},Y:{1} ", WGS8s.X.ToString(), WGS8s.Y.ToString());
            label2.Text = sb.ToString();
        }

        private Color ScreenColor(int x, int y)
        {
            Color color = Color.Empty;
            if (shapeMapView1 != null)
            {
                IntPtr hDC = NativeGDI.GetDC(shapeMapView1.Handle);
                int colorRef = NativeGDI.GetPixel(hDC, x, y);
                color = Color.FromArgb(
                    (int)(colorRef & 0x000000FF),
                    (int)(colorRef & 0x0000FF00) >> 8,
                    (int)(colorRef & 0x00FF0000) >> 16);
                NativeGDI.ReleaseDC(shapeMapView1.Handle, hDC);
            }
            return color;
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            if (lineColor.ShowDialog() == DialogResult.OK)
            {
                panel2.BackColor = lineColor.Color;
                shapeMapView1.reDraw = true;
                shapeMapView1.LineColor = lineColor.Color;
                shapeMapView1.Refresh();

            }


        }

        private void panel3_Click(object sender, EventArgs e)
        {
            if (brushColor.ShowDialog() == DialogResult.OK)
            {
                panel3.BackColor = brushColor.Color;
                shapeMapView1.reDraw = true;
                shapeMapView1.BrushColor = brushColor.Color;
                shapeMapView1.Refresh();

            }
        }

        private void panel4_Click(object sender, EventArgs e)
        {
            if (bgColor.ShowDialog() == DialogResult.OK)
            {
                panel4.BackColor = bgColor.Color;
                shapeMapView1.reDraw = true;
                shapeMapView1.BGColor = bgColor.Color;
                shapeMapView1.Refresh();

            }
        }
    }


}

