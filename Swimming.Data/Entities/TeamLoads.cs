using System;
using System.Collections.Generic;

namespace Swimming.Data.Entities
{
    public partial class TeamLoads
    {
        public int TeamLoadId { get; set; }
        public int? TeamId { get; set; }
        public int? SwimLoad { get; set; }
        public int? LandLoad { get; set; }
        public bool? IsActive { get; set; }
        public int? AddedBy { get; set; }
        public DateTime? AddedDate { get; set; }
        public int? LastModBy { get; set; }
        public DateTime? LastModDate { get; set; }

        public virtual Users AddedByNavigation { get; set; }
        public virtual Users LastModByNavigation { get; set; }
        public virtual Teams Team { get; set; }
    }
}
