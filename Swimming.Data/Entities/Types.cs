using System;
using System.Collections.Generic;

namespace Swimming.Data.Entities
{
    public partial class Types
    {
        public Types()
        {
            Activates = new HashSet<Activates>();
        }

        public int TypeId { get; set; }
        public string TypeName { get; set; }
        public string TypeDesc { get; set; }
        public bool? IsActive { get; set; }
        public int AddedBy { get; set; }
        public DateTime AddedDate { get; set; }
        public int? LastModBy { get; set; }
        public DateTime? LastModDate { get; set; }

        public virtual Users AddedByNavigation { get; set; }
        public virtual Users LastModByNavigation { get; set; }
        public virtual ICollection<Activates> Activates { get; set; }
    }
}
