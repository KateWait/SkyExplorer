using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SkyExplorer1.Models
{
    public class Attachment
    {
        public int AttachmentID { get; set; }
        public string Name { get; set; }
        public byte[] Byte { get; set; }
        public string FileType { get; set; }
        public DateTime Created { get; set; }
        public DateTime? LastModified { get; set; }
    }
}