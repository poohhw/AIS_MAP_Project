using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIS_PARSING
{
    public class AIS_Data
    {
        public string MessageType { get; set; }
        public string RepeatIndicator { get; set; }
        public string MMSI { get; set; }
        public string NavigationStatus { get; set; }
        public string ROT { get; set; }
        public string SOG { get; set; }
        public string PositionAccuracy { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public string COG { get; set; }
        public string HDG { get; set; }
        public string TimeStamp { get; set; }
        public string ManeuverIndicator { get; set; }
        public string Spare { get; set; }
        public string RAIMflag { get; set; }
        public string RadioStatus { get; set; }

        public string ScreenX { get; set; }
        public string ScreenY { get; set; }

        public RectangleF rcImage { get; set; }
    }
}