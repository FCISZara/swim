using System;
using System.Collections.Generic;

namespace Swimming.Data.Entities
{
    public partial class Activates
    {
        public int ActivateId { get; set; }
        public int? TeamId { get; set; }
        public int? CoachId { get; set; }
        public int? TypeId { get; set; }
        public DateTime ActivateDate { get; set; }
        public string ActivateDetails { get; set; }
        public int? ApproveCoachId { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsApproved { get; set; }
        public int AddedBy { get; set; }
        public DateTime AddedDate { get; set; }
        public int? LastModBy { get; set; }
        public DateTime? LastModDate { get; set; }

        public virtual Users AddedByNavigation { get; set; }
        public virtual Users ApproveCoach { get; set; }
        public virtual Users Coach { get; set; }
        public virtual Users LastModByNavigation { get; set; }
        public virtual Teams Team { get; set; }
        public virtual Types Type { get; set; }
    }
}
