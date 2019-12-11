using System;
using System.Collections.Generic;

namespace Swimming.Data.Entities
{
    public partial class Attachments
    {
        public int AttachmentId { get; set; }
        public int? UserId { get; set; }
        public string AttachmentName { get; set; }
        public string ContentType { get; set; }
        public string Size { get; set; }
        public string AttachmentPath { get; set; }

        public virtual Users User { get; set; }
    }
}
