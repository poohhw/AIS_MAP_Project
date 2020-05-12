using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyCRS
{
    public class ConvertCoordinateUtil
    {
        //도 형식을 도분 형식으로 변경.
        public LongLat ConvertDoBun(string pData)
        {
            double vData = Convert.ToDouble(pData);

            double num = Math.Truncate(vData);
            double point = vData - num;

            double min = Math.Round(point * 60, 4);

            //Console.WriteLine($"정수:{num},소수:{point},분:{min}");

            LongLat longLat = new LongLat()
            {
                Degree = num,
                Min = min,
                Sec = 0
            };

            return longLat;

        }

        //도분 형식을 도 로 변환.
        public string ConvertDo(LongLat pData)
        {
            double min = Math.Round(pData.Min / 60, 5);

            double value = pData.Degree + min;

            return value.ToString();


        }
    }
    public class LongLat
    {
        public double Degree;
        public double Min;
        public double Sec;
    }
}
