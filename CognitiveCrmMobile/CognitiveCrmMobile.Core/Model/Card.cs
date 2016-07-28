using Android.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Java.IO;

namespace CognitiveCrmMobile.Core.Model
{
    public class Card
    {
        public int id { get; set; }
        public bool isFavorite { get; set; }
        public string name { get; set; }
        public string phoneNumber1 { get; set; }
        public string phoneNumber2 { get; set; }
        public string companyName { get; set; }
        public string addressLine1 { get; set; }
        public string addressLine2 { get; set; }
        public string addressLine3 { get; set; }
        public string emailAddress1 { get; set; }
        public string emailAddress2 { get; set; }
        public string webSite { get; set; }
        public string designation { get; set; }
        public string ignoreText { get; set; }
        public string nameDesignation { get; set; }
        public string phoneNumber1PhoneNumber2 { get; set; }
        public int height { get; set; }
        public int width { get; set; }
        public string filePath { get; set; }
        public Bitmap bitmap { get; set; }
        public File file { get; set; }

    }
}
