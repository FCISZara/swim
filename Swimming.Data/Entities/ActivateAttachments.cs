using System;
using System.Collections.Generic;

namespace Swimming.Data.Entities
{
    public partial class ActivateAttachments
    {
        public int ActivateAttachmentId { get; set; }
        public int? ActivateId { get; set; }
        public string ActivateAttachmentName { get; set; }
        public string ContentType { get; set; }
        public string Size { get; set; }
        public string ActivateAttachmentPath { get; set; }

        public virtual Users Activate { get; set; }
    }
}
