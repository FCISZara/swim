using System;
using System.Collections.Generic;

namespace Swimming.Data.Entities
{
    public partial class Teams
    {
        public Teams()
        {
            Activates = new HashSet<Activates>();
            Grand = new HashSet<Grand>();
            TeamLoads = new HashSet<TeamLoads>();
            UserTeam = new HashSet<UserTeam>();
        }

        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public string TeamDesc { get; set; }
        public int? TeamCoachId { get; set; }
        public bool? IsActive { get; set; }
        public int AddedBy { get; set; }
        public DateTime AddedDate { get; set; }
        public int? LastModBy { get; set; }
        public DateTime? LastModDate { get; set; }

        public virtual Users AddedByNavigation { get; set; }
        public virtual Users LastModByNavigation { get; set; }
        public virtual Users TeamCoach { get; set; }
        public virtual ICollection<Activates> Activates { get; set; }
        public virtual ICollection<Grand> Grand { get; set; }
        public virtual ICollection<TeamLoads> TeamLoads { get; set; }
        public virtual ICollection<UserTeam> UserTeam { get; set; }
    }
}
