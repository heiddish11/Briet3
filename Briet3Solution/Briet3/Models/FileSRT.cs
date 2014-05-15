using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Briet3.Models
{
    public class FileSRT
    {
        public int? FileSRTID { get; set; }
        public int TitleID { get; set; }
        public string FileSRTName { get; set; }
        public string Data { get; set; }
        public string ContentType { get; set;}
        public int? ContentLength { get; set; }

        public FileSRT()
        {
            FileSRTID = 0;
            FileSRTName = "New .srt File";
            Data ="";
            ContentType = "";
            ContentLength = 0;
     
        }
    }
}