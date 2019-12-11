using System;
using System.Collections.Generic;

namespace Swimming.Data.Entities
{
    public partial class SwimCategories
    {
        public SwimCategories()
        {
            SwimSubCategories = new HashSet<SwimSubCategories>();
        }

        public int SwimCategoryId { get; set; }
        public string SwimCategory { get; set; }
        public string Description { get; set; }
        public bool? IsActive { get; set; }
        public int? AddedBy { get; set; }
        public DateTime? AddedDate { get; set; }
        public int? LastModBy { get; set; }
        public DateTime? LastModDate { get; set; }

        public virtual Users AddedByNavigation { get; set; }
        public virtual Users LastModByNavigation { get; set; }
        public virtual ICollection<SwimSubCategories> SwimSubCategories { get; set; }
    }
}
