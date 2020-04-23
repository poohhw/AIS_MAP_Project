using DotSpatial.Projections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyCRS
{
    public class CrazyCRS
    {
        private static ProjectionInfo src;
        private static ProjectionInfo trg;

        public struct PROJ4
        {
            public const string TMERC = @"+proj=tmerc +lat_0=38 +lon_0=127.5 +k=0.9996 +x_0=1000000 +y_0=2000000 +ellps=GRS80 +units=m +no_defs +type=crs";
            public const string LONGLAT = @"+proj=longlat +datum=WGS84 +no_defs";
        }
      

        /// <summary>
        /// 좌표계 변환.
        /// </summary>
        /// <param name="pX">X좌표계</param>
        /// <param name="pY">Y좌표계</param>
        /// <param name="source">원본 좌표계 prj</param>
        /// <param name="target">변환 좌표계 prj</param>
        /// <returns></returns>
        public static double[] ConvertCRS(double pX,double pY,string source,string target)
        {
            double[] xy = new double[2];
            double[] z = new double[1];

            xy[0] = pX;
            xy[1] = pY;
            z[0] = 0;

            src = ProjectionInfo.FromProj4String(source);
            trg = DotSpatial.Projections.ProjectionInfo.FromProj4String(target);
            Reproject.ReprojectPoints(xy, z, src, trg, 0, 1);

            return xy;
        }
    }
}
