using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MapView
{
    public class NativeGDI
    {
        public const int SRCCOPY = 0xcc0020;

        [DllImport("user32.dll")]
        public static extern IntPtr GetDC(IntPtr hWnd);
        [DllImport("user32.dll")]
        public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);
        [DllImport("gdi32.dll")]
        public static extern int GetPixel(IntPtr hDC, int x, int y);
        [DllImport("gdi32.dll")]
        public  static extern int SetPixel(IntPtr hDC, int x, int y, int color);

        [DllImport("gdi32.dll")]
        public static extern long BitBlt(IntPtr hdcDest, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, int dwRop);

        [DllImport("gdi32.dll")] public static extern IntPtr CreateCompatibleBitmap(IntPtr hDC, int nWidth, int nHeight);

        [DllImport("gdi32.dll")] public static extern IntPtr CreateCompatibleDC(IntPtr hDC);

        [DllImport("gdi32.dll")] public static extern bool DeleteDC(IntPtr hDC);

        [DllImport("gdi32.dll")] public static extern bool DeleteObject(IntPtr hObject);

        [DllImport("gdi32.dll")] public static extern IntPtr SelectObject(IntPtr hDC, IntPtr hObject);

        [DllImportAttribute("gdi32.dll")]
        public static extern IntPtr CreatePen(int fnPenStyle, int nWidth, int rgbColor);

        [DllImportAttribute("gdi32.dll")]
        public static extern IntPtr CreateSolidBrush(int rgbColor);

        [DllImportAttribute("gdi32.dll")]
        public static extern unsafe int Polygon(IntPtr hdc, Point* points, int count);

        public static unsafe void DrawPolygon(IntPtr hdc, Point[] points, int count)
        {
            fixed (Point* ptr = points)
            {
                Polygon(hdc, ptr, count);
            }
        }
    }
}
