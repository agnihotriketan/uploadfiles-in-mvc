using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;

namespace GallaryManager.Models
{
    public class ImageResult
    {
        public bool Success { get; set; }
        public string ImageName { get; set; }
        public string ErrorMessage { get; set; }
    }

    public class ImageUpload
    {
        public int Width { get; set; }

        public int Height { get; set; }

        private string UploadPath = "~/Images/ketan";

        public ImageResult RenameUploadFile(HttpPostedFileBase file, Int32 counter = 0)
        {
            var fileName = Path.GetFileName(file.FileName);

            string prepend = "item_";
            string finalFileName = prepend + ((counter).ToString()) + "_" + fileName;
            if (System.IO.File.Exists(HttpContext.Current.Request.MapPath(UploadPath + finalFileName)))
                return RenameUploadFile(file, ++counter);

            if (!System.IO.Directory.Exists(HttpContext.Current.Server.MapPath(UploadPath)))
                System.IO.Directory.CreateDirectory(HttpContext.Current.Server.MapPath(UploadPath));

            return UploadFile(file, finalFileName);
        }

        private ImageResult UploadFile(HttpPostedFileBase file, string fileName)
        {
            ImageResult imageResult = new ImageResult { Success = true, ErrorMessage = null };

            var path = Path.Combine(HttpContext.Current.Request.MapPath(UploadPath), fileName);
            string extension = Path.GetExtension(file.FileName);
            if (!ValidateExtension(extension))
            {
                imageResult.Success = false;
                imageResult.ErrorMessage = "Invalid Extension";
                return imageResult;
            }

            try
            {
                file.SaveAs(path);
                using (Image imgOriginal = Image.FromFile(path))
                {
                    using (Image imgActual = Scale(imgOriginal))
                    {
                        imgActual.Save(path);
                        imageResult.ImageName = fileName;
                        return imageResult;
                    }
                }
            }
            catch (Exception ex)
            {
                imageResult.Success = false;
                imageResult.ErrorMessage = ex.Message;
                return imageResult;
            }
        }

        private bool ValidateExtension(string extension)
        {
            extension = extension.ToLower();
            switch (extension)
            {
                case ".jpg":
                    return true;
                case ".png":
                    return true;
                case ".gif":
                    return true;
                case ".jpeg":
                    return true;
                default:
                    return false;
            }
        }

        private Image Scale(Image imgPhoto)
        {
            float sourceWidth = imgPhoto.Width;
            float sourceHeight = imgPhoto.Height;
            float destHeight = 0;
            float destWidth = 0;
            int sourceX = 0;
            int sourceY = 0;
            int destX = 0;
            int destY = 0;

            if (Width != 0 && Height != 0)
            {
                destWidth = Width;
                destHeight = Height;
            }
            else if (Height != 0)
            {
                destWidth = (float)(Height * sourceWidth) / sourceHeight;
                destHeight = Height;
            }
            else
            {
                destWidth = Width;
                destHeight = (float)(sourceHeight * Width / sourceWidth);
            }

            Bitmap bmPhoto = new Bitmap((int)destWidth, (int)destHeight, PixelFormat.Format32bppPArgb);
            bmPhoto.SetResolution(imgPhoto.HorizontalResolution, imgPhoto.VerticalResolution);
            using (Graphics grPhoto = Graphics.FromImage(bmPhoto))
            {
                grPhoto.InterpolationMode = InterpolationMode.HighQualityBicubic;
                grPhoto.DrawImage(imgPhoto, new Rectangle(destX, destY, (int)destWidth, (int)destHeight), new Rectangle(sourceX, sourceY, (int)sourceWidth, (int)sourceHeight), GraphicsUnit.Pixel);
            }

            return bmPhoto;
        }
    }
}