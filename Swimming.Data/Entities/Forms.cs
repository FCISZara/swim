using System;
using System.Collections.Generic;

namespace Swimming.Data.Entities
{
    public partial class Forms
    {
        public int FormId { get; set; }
        public int? SwimId { get; set; }
        public int? CoachId { get; set; }
        public DateTime? Date { get; set; }
        public string Pluse { get; set; }
        public string Strength { get; set; }
        public string Weight { get; set; }
        public string Sleep { get; set; }
        public string Sweeting { get; set; }
        public string Mood { get; set; }
        public string Train { get; set; }
        public string Pain { get; set; }
        public string Illness { get; set; }
        public string Scomments { get; set; }
        public string Ccomment { get; set; }
        public int? Approved { get; set; }
        public bool? IsActive { get; set; }
        public int? AddedBy { get; set; }
        public DateTime? AddedDate { get; set; }
        public int? LastModBy { get; set; }
        public DateTime? LastModDate { get; set; }

        public virtual Users AddedByNavigation { get; set; }
        public virtual Users Coach { get; set; }
        public virtual Users LastModByNavigation { get; set; }
        public virtual Users Swim { get; set; }
    }
}
