using System;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace Hugate.DataHelper
{
    public abstract class AbsObject
    {
        private PKDataContext _PKData = null;
        public PKDataContext PKData
        {
            get
            {
                if (_PKData == null) _PKData = new PKDataContext();
                return _PKData;
            }
        }
        public static string pathFrontImage = @"D:\ImageParking\Front\";
        public static string pathBackImage = @"D:\ImageParking\Back\";
        public static Bitmap pubBitmap;
    }
}
