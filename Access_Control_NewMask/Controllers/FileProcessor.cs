using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Access_Control_NewMask.Controllers
{
    public class FileProcessor
    {
        public static string GetMemberImageRelativeFilePath(string fileName)
        {
            try
            {

                if (!string.IsNullOrWhiteSpace(fileName))
                {
                    string fullImagePath2 = MembersPhotosFolder + "\\" + fileName;
                    if (File.Exists(fullImagePath2))
                    {
                        return string.Format("/UserImages/Member/{0}", fileName);

                        //string file = Convert.ToBase64String(File.ReadAllBytes(fullImagePath2));
                        //return string.IsNullOrWhiteSpace(file) ? null : "data:image/png;base64," + file;
                    }
                }
            }
            catch (Exception ex)
            {
            }

            return null;

        }

        public static string GetVisitorImageRelativeFilePath(string fileName)
        {
            try
            {

                if (!string.IsNullOrWhiteSpace(fileName))
                {
                    string fullImagePath2 = VisitorsPhotosFolder + "\\" + fileName;
                    if (File.Exists(fullImagePath2))
                    {
                        return string.Format("/UserImages/Visitor/{0}", fileName);

                        //string file = Convert.ToBase64String(File.ReadAllBytes(fullImagePath2));
                        //return string.IsNullOrWhiteSpace(file) ? null : "data:image/png;base64," + file;
                    }
                }
            }
            catch (Exception ex)
            {
            }

            return null;

        }

        public static string GetPersonalImageFile(string fileName)
        {
            try
            {

                if (!string.IsNullOrWhiteSpace(fileName))
                {
                    string fullImagePath2 = PersPhotosFolder + "\\" + fileName;
                    if (File.Exists(fullImagePath2))
                    {
                        return string.Format("/UserImages/Personal/{0}", fileName);

                        //string file = Convert.ToBase64String(File.ReadAllBytes(fullImagePath2));
                        //return string.IsNullOrWhiteSpace(file) ? null : "data:image/png;base64," + file;
                    }
                }
            }
            catch (Exception ex)
            {
            }

            return null;

        }

        public static string SaveImageFile(string hexString, string fileName)
        {
            try
            {
                string[] data = hexString.Split(',');
                if (data.Length == 2 && !string.IsNullOrWhiteSpace(data[1]) && !string.IsNullOrWhiteSpace(fileName))
                {
                    string newFileName = string.Format("{0}.png", fileName);
                    string fullImagePath2 = PersPhotosFolder + "\\" + newFileName;
                    File.WriteAllBytes(fullImagePath2, Convert.FromBase64String(data[1]));
                    return newFileName;
                }
            }
            catch (Exception ex)
            {

            }

            return null;

        }

        public static string GetVisitorImageFileNameFromRelativePath(string relativePath)
        {
            if (string.IsNullOrWhiteSpace(relativePath))
            {
                return string.Empty;
            }
            return relativePath.Replace(@"/UserImages/Visitor/", "");
        }

        public static string GetImageFileNameFromRelativePath(string relativePath)
        {
            if (string.IsNullOrWhiteSpace(relativePath))
            {
                return string.Empty;
            }

            return relativePath.Replace(@"/UserImages/Personal/", "");
        }

        public static string GetImageMemberFileNameFromRelativePath(string relativePath)
        {
            if (string.IsNullOrWhiteSpace(relativePath))
            {
                return string.Empty;
            }

            return relativePath.Replace(@"/UserImages/Member/", "");
        }


        public static string SaveVisitorImageFile(string hexString, string fileName)
        {
            try
            {
                string[] data = hexString.Split(',');
                if (data.Length == 2 && !string.IsNullOrWhiteSpace(data[1]) && !string.IsNullOrWhiteSpace(fileName))
                {
                    string newFileName = string.Format("{0}.png", fileName);
                    string fullImagePath2 = VisitorsPhotosFolder + "\\" + newFileName;
                    File.WriteAllBytes(fullImagePath2, Convert.FromBase64String(data[1]));
                    return newFileName;
                }
            }
            catch (Exception ex)
            {

            }

            return null;

        }
        public static string SaveMemberPhoto(string hexString, string fileName)
        {
            try
            {
                string[] data = hexString.Split(',');
                if (data.Length == 2 && !string.IsNullOrWhiteSpace(data[1]) && !string.IsNullOrWhiteSpace(fileName))
                {
                    string newFileName = string.Format("{0}.png", fileName);
                    string fullImagePath2 = MembersPhotosFolder + "\\" + newFileName;
                    File.WriteAllBytes(fullImagePath2, Convert.FromBase64String(data[1]));
                    return newFileName;
                }
            }
            catch (Exception ex)
            {

            }

            return null;

        }
        public static string GetImageFile(string fileName)
        {
            try
            {

                if (!string.IsNullOrWhiteSpace(fileName))
                {
                    string fullImagePath2 = PersPhotosFolder + "\\" + fileName;
                    if (File.Exists(fullImagePath2))
                    {
                        string file = Convert.ToBase64String(File.ReadAllBytes(fullImagePath2));
                        return string.IsNullOrWhiteSpace(file) ? null : "data:image/png;base64," + file;
                    }
                }
            }
            catch (Exception ex)
            {
            }

            return null;

        }
        public static string GetVisitorImageFile(string fileName)
        {
            try
            {

                if (!string.IsNullOrWhiteSpace(fileName))
                {
                    string fullImagePath2 = VisitorsPhotosFolder + "\\" + fileName;
                    if (File.Exists(fullImagePath2))
                    {
                        return "data:image/png;base64," + Convert.ToBase64String(File.ReadAllBytes(fullImagePath2));
                    }
                }
            }
            catch (Exception ex)
            {
            }

            return null;

        }

        //public static string GetInActivePersonalImageFile(string fileName)
        //{
        //    try
        //    {
        //        if (!string.IsNullOrWhiteSpace(fileName))
        //        {
        //            string fullImagePath2 = MembersPhotosFolder + "\\" + fileName;
        //            if (File.Exists(fullImagePath2))
        //            {
        //                return string.Format("/UserImages/Member/{0}", fileName);
        //                //string file = Convert.ToBase64String(File.ReadAllBytes(fullImagePath2));
        //                //return string.IsNullOrWhiteSpace(file) ? null : "data:image/png;base64," + file;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //    }

        //    return null;

        //}

        public static string GetMemberImageFile(string fileName)
        {
            try
            {

                if (!string.IsNullOrWhiteSpace(fileName))
                {
                    string fullImagePath2 = MembersPhotosFolder + "\\" + fileName;
                    if (File.Exists(fullImagePath2))
                    {
                        string file = Convert.ToBase64String(File.ReadAllBytes(fullImagePath2));
                        return string.IsNullOrWhiteSpace(file) ? null : "data:image/png;base64," + file;
                    }
                }
            }
            catch (Exception ex)
            {
            }

            return null;

        }

        public static bool DeleteImageFile(string fileName, string folderPath)
        {
            try
            {

                if (!string.IsNullOrWhiteSpace(fileName))
                {
                    string fullImagePath2 = folderPath + fileName;
                    if (File.Exists(fullImagePath2))
                    {
                        File.Delete(fullImagePath2);
                        return File.Exists(fullImagePath2);
                    }
                }
            }
            catch (Exception ex)
            {
            }

            return false;

        }

        internal static string PersPhotosFolder
        { get; set; }
        internal static string VisitorsPhotosFolder
        { get; set; }
        internal static string MembersPhotosFolder
        { get; set; }
        
    }
}