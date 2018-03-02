using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebSite.Models;

namespace WebSite.Helpers
{
    public static class CreateHelper 
        
    {
        
        public static bool pictureNotImage1(HttpPostedFileBase image1)
        {
            return image1.ContentType.ToLower() != "image/jpg" &&
                               image1.ContentType.ToLower() != "image/jpeg" &&
                                image1.ContentType.ToLower() != "image/pjpeg" &&
                                image1.ContentType.ToLower() != "image/gif" &&
                                image1.ContentType.ToLower() != "image/x-png" &&
                                image1.ContentType.ToLower() != "image/png";
        }

     
       

        public static bool pictureNotImage(HttpPostedFileBase image1, HttpPostedFileBase image2)
        {
            return image1.ContentType.ToLower() != "image/jpg" &&
                               image1.ContentType.ToLower() != "image/jpeg" &&
                                image1.ContentType.ToLower() != "image/pjpeg" &&
                                image1.ContentType.ToLower() != "image/gif" &&
                                image1.ContentType.ToLower() != "image/x-png" &&
                                image1.ContentType.ToLower() != "image/png" ||
                                image2.ContentType.ToLower() != "image/jpg" &&
                                image2.ContentType.ToLower() != "image/jpeg" &&
                                image2.ContentType.ToLower() != "image/pjpeg" &&
                                image2.ContentType.ToLower() != "image/gif" &&
                                image2.ContentType.ToLower() != "image/x-png" &&
                                image2.ContentType.ToLower() != "image/png";
        }
    }
}