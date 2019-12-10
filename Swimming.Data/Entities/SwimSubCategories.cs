using System;
using System.Collections.Generic;

namespace Swimming.Data.Entities
{
    public partial class SwimSubCategories
    {
        public int SwimSubCategoryId { get; set; }
        public int SwimCategoryId { get; set; }
        public string SwimSubCategory { get; set; }
        public string Description { get; set; }
        public bool? IsActive { get; set; }
        public int? AddedBy { get; set; }
        public DateTime? AddedDate { get; set; }
        public int? LastModBy { get; set; }
        public DateTime? LastModDate { get; set; }

        public virtual Users AddedByNavigation { get; set; }
        public virtual Users LastModByNavigation { get; set; }
        public virtual SwimCategories SwimCategory { get; set; }
    }
}
