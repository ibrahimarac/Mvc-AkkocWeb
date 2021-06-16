using ImageResizer;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Akkoc.Utils
{
    public static class ImageExtensions
    {
        public static Image CropImage(this HttpPostedFileBase fileBase, NameValueCollection form)
        {
            Image src = Image.FromStream(fileBase.InputStream);

            if (string.IsNullOrEmpty(form["width"]))
            {
                return src;
            }

            //kırpma alanının bilgileri
            var left = Convert.ToDouble(form["left"].Replace(".", ","));
            var top = Convert.ToDouble(form["top"].Replace(".", ","));
            var width = Convert.ToDouble(form["width"].Replace(".", ","));
            var height = Convert.ToDouble(form["height"].Replace(".", ","));
            var ratio = Convert.ToDouble(form["ratio"].Replace(".", ","));
            Rectangle cropRec = new Rectangle((int)(left * ratio), (int)(top * ratio), (int)(width * ratio), (int)(height * ratio));

            Bitmap resultImg = new Bitmap(cropRec.Width, cropRec.Height);

            using (Graphics g = Graphics.FromImage(resultImg))
            {
                g.DrawImage(src, new Rectangle(0, 0, resultImg.Width, resultImg.Height),
                                 cropRec,
                                 GraphicsUnit.Pixel);
            }

            return resultImg;
        }

        public static string GenerateFileName(this HttpPostedFileBase fileBase)
        {
            //resim1.jpg
            string fileExtension = fileBase.FileName.Substring(fileBase.FileName.LastIndexOf(".") + 1);
            DateTime date = DateTime.Now;
            string fileName = string.Format("{0}_{1}_{2}_{3}_{4}_{5}_{6}", date.Day, date.Month, date.Year, date.Hour, date.Minute, date.Second, date.Millisecond);
            string fullName = string.Format("{0}.{1}", fileName, fileExtension);
            return fullName;
        }

        public static string GetPhysicalPath(this string fileName, string folderName)
        {
            return HttpContext.Current.Server.MapPath("/Content/images/" + System.IO.Path.Combine(folderName, fileName));
        }

        //Resmi belli nir yüzde pranında küçültebilen metod
        public static Image ScaleByPercent(this Image imgPhoto, int percent)
        {
            float nPercent = ((float)percent / 100);
            int sourceWidth = imgPhoto.Width;
            int sourceHeight = imgPhoto.Height;
            int sourceX = 0;
            int sourceY = 0;

            int destX = 0;
            int destY = 0;
            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);

            Bitmap bmPhoto = new Bitmap(destWidth, destHeight, PixelFormat.Format24bppRgb);
            bmPhoto.SetResolution(imgPhoto.HorizontalResolution, imgPhoto.VerticalResolution);

            Graphics grPhoto = Graphics.FromImage(bmPhoto);
            grPhoto.InterpolationMode = InterpolationMode.HighQualityBicubic;
            grPhoto.DrawImage(imgPhoto, new Rectangle(destX, destY, destWidth, destHeight), new Rectangle(sourceX,
            sourceY, sourceWidth, sourceHeight), GraphicsUnit.Pixel);

            grPhoto.Dispose();

            return bmPhoto;
        }

        //Resmi istenen genişlik ve yüksekliğe sığacak şekilde küçülten metod
        public static Image FixedSize(this Image imgPhoto, int Width, int Height)
        {
            int sourceWidth = imgPhoto.Width;
            int sourceHeight = imgPhoto.Height;
            int sourceX = 0;
            int sourceY = 0;
            int destX = 0;
            int destY = 0;

            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;

            nPercentW = ((float)Width / (float)sourceWidth);
            nPercentH = ((float)Height / (float)sourceHeight);
            if (nPercentH < nPercentW)
            {
                nPercent = nPercentH;
                destX = System.Convert.ToInt16((Width - (sourceWidth * nPercent)) / 2);
            }
            else
            {
                nPercent = nPercentW;
                destY = System.Convert.ToInt16((Height - (sourceHeight * nPercent)) / 2);
            }

            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);

            Bitmap bmPhoto = new Bitmap(Width, Height, PixelFormat.Format24bppRgb);
            bmPhoto.SetResolution(imgPhoto.HorizontalResolution, imgPhoto.VerticalResolution);

            Graphics grPhoto = Graphics.FromImage(bmPhoto);
            grPhoto.Clear(Color.White);
            grPhoto.InterpolationMode = InterpolationMode.HighQualityBicubic;
            grPhoto.DrawImage(imgPhoto, new Rectangle(destX, destY, destWidth, destHeight), new Rectangle(sourceX,
            sourceY, sourceWidth, sourceHeight), GraphicsUnit.Pixel);
            grPhoto.Dispose();

            return bmPhoto;
        }
    }

}

