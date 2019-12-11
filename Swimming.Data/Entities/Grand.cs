using System;
using System.Collections.Generic;

namespace Swimming.Data.Entities
{
    public partial class Grand
    {
        public Grand()
        {
            Mizu = new HashSet<Mizu>();
        }

        public int GrandId { get; set; }
        public int? Year { get; set; }
        public int? TeamId { get; set; }
        public string GrandName { get; set; }
        public DateTime? FromD { get; set; }
        public DateTime? ToD { get; set; }
        public double? SwimLoad { get; set; }
        public bool? IsActive { get; set; }
        public int? AddedBy { get; set; }
        public DateTime? AddedDate { get; set; }
        public int? LastModBy { get; set; }
        public DateTime? LastModDate { get; set; }

        public virtual Users AddedByNavigation { get; set; }
        public virtual Users LastModByNavigation { get; set; }
        public virtual Teams Team { get; set; }
        public virtual ICollection<Mizu> Mizu { get; set; }
    }
}
