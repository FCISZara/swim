using System;
using System.Collections.Generic;

namespace Swimming.Data.Entities
{
    public partial class Mizu
    {
        public int MizuId { get; set; }
        public int? GrandId { get; set; }
        public string MizuName { get; set; }
        public DateTime? FromD { get; set; }
        public DateTime? ToD { get; set; }
        public double? SwimLoad { get; set; }
        public bool? IsActive { get; set; }
        public int? AddedBy { get; set; }
        public DateTime? AddedDate { get; set; }
        public int? LastModBy { get; set; }
        public DateTime? LastModDate { get; set; }

        public virtual Users AddedByNavigation { get; set; }
        public virtual Grand Grand { get; set; }
        public virtual Users LastModByNavigation { get; set; }
    }
}
