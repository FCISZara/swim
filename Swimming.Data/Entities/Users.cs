using System;
using System.Collections.Generic;

namespace Swimming.Data.Entities
{
    public partial class Users
    {
        public Users()
        {
            ActivateAttachments = new HashSet<ActivateAttachments>();
            ActivatesAddedByNavigation = new HashSet<Activates>();
            ActivatesApproveCoach = new HashSet<Activates>();
            ActivatesCoach = new HashSet<Activates>();
            ActivatesLastModByNavigation = new HashSet<Activates>();
            Attachments = new HashSet<Attachments>();
            FormsAddedByNavigation = new HashSet<Forms>();
            FormsCoach = new HashSet<Forms>();
            FormsLastModByNavigation = new HashSet<Forms>();
            FormsSwim = new HashSet<Forms>();
            GrandAddedByNavigation = new HashSet<Grand>();
            GrandLastModByNavigation = new HashSet<Grand>();
            InverseAddedByNavigation = new HashSet<Users>();
            InverseLastModByNavigation = new HashSet<Users>();
            MizuAddedByNavigation = new HashSet<Mizu>();
            MizuLastModByNavigation = new HashSet<Mizu>();
            RolesAddedByNavigation = new HashSet<Roles>();
            RolesLastModByNavigation = new HashSet<Roles>();
            SwimCategoriesAddedByNavigation = new HashSet<SwimCategories>();
            SwimCategoriesLastModByNavigation = new HashSet<SwimCategories>();
            SwimSubCategoriesAddedByNavigation = new HashSet<SwimSubCategories>();
            SwimSubCategoriesLastModByNavigation = new HashSet<SwimSubCategories>();
            TeamLoadsAddedByNavigation = new HashSet<TeamLoads>();
            TeamLoadsLastModByNavigation = new HashSet<TeamLoads>();
            TeamsAddedByNavigation = new HashSet<Teams>();
            TeamsLastModByNavigation = new HashSet<Teams>();
            TeamsTeamCoach = new HashSet<Teams>();
            TypesAddedByNavigation = new HashSet<Types>();
            TypesLastModByNavigation = new HashSet<Types>();
            UserCategoriesAddedByNavigation = new HashSet<UserCategories>();
            UserCategoriesLastModByNavigation = new HashSet<UserCategories>();
            UserTeamAddedByNavigation = new HashSet<UserTeam>();
            UserTeamLastModByNavigation = new HashSet<UserTeam>();
            UserTeamRoleAddedByNavigation = new HashSet<UserTeamRole>();
            UserTeamRoleLastModByNavigation = new HashSet<UserTeamRole>();
            UserTeamUser = new HashSet<UserTeam>();
        }

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserFullName { get; set; }
        public string Email { get; set; }
        public string Identification { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Nationality { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string LocalAddress { get; set; }
        public string ImagePath { get; set; }
        public int? UserCategoryId { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? InsertedDate { get; set; }
        public int? AddedBy { get; set; }
        public int? LastModBy { get; set; }
        public DateTime? LastModDate { get; set; }
        public int? AuthUserId { get; set; }

        public virtual Users AddedByNavigation { get; set; }
        public virtual Users LastModByNavigation { get; set; }
        public virtual UserCategories UserCategory { get; set; }
        public virtual ICollection<ActivateAttachments> ActivateAttachments { get; set; }
        public virtual ICollection<Activates> ActivatesAddedByNavigation { get; set; }
        public virtual ICollection<Activates> ActivatesApproveCoach { get; set; }
        public virtual ICollection<Activates> ActivatesCoach { get; set; }
        public virtual ICollection<Activates> ActivatesLastModByNavigation { get; set; }
        public virtual ICollection<Attachments> Attachments { get; set; }
        public virtual ICollection<Forms> FormsAddedByNavigation { get; set; }
        public virtual ICollection<Forms> FormsCoach { get; set; }
        public virtual ICollection<Forms> FormsLastModByNavigation { get; set; }
        public virtual ICollection<Forms> FormsSwim { get; set; }
        public virtual ICollection<Grand> GrandAddedByNavigation { get; set; }
        public virtual ICollection<Grand> GrandLastModByNavigation { get; set; }
        public virtual ICollection<Users> InverseAddedByNavigation { get; set; }
        public virtual ICollection<Users> InverseLastModByNavigation { get; set; }
        public virtual ICollection<Mizu> MizuAddedByNavigation { get; set; }
        public virtual ICollection<Mizu> MizuLastModByNavigation { get; set; }
        public virtual ICollection<Roles> RolesAddedByNavigation { get; set; }
        public virtual ICollection<Roles> RolesLastModByNavigation { get; set; }
        public virtual ICollection<SwimCategories> SwimCategoriesAddedByNavigation { get; set; }
        public virtual ICollection<SwimCategories> SwimCategoriesLastModByNavigation { get; set; }
        public virtual ICollection<SwimSubCategories> SwimSubCategoriesAddedByNavigation { get; set; }
        public virtual ICollection<SwimSubCategories> SwimSubCategoriesLastModByNavigation { get; set; }
        public virtual ICollection<TeamLoads> TeamLoadsAddedByNavigation { get; set; }
        public virtual ICollection<TeamLoads> TeamLoadsLastModByNavigation { get; set; }
        public virtual ICollection<Teams> TeamsAddedByNavigation { get; set; }
        public virtual ICollection<Teams> TeamsLastModByNavigation { get; set; }
        public virtual ICollection<Teams> TeamsTeamCoach { get; set; }
        public virtual ICollection<Types> TypesAddedByNavigation { get; set; }
        public virtual ICollection<Types> TypesLastModByNavigation { get; set; }
        public virtual ICollection<UserCategories> UserCategoriesAddedByNavigation { get; set; }
        public virtual ICollection<UserCategories> UserCategoriesLastModByNavigation { get; set; }
        public virtual ICollection<UserTeam> UserTeamAddedByNavigation { get; set; }
        public virtual ICollection<UserTeam> UserTeamLastModByNavigation { get; set; }
        public virtual ICollection<UserTeamRole> UserTeamRoleAddedByNavigation { get; set; }
        public virtual ICollection<UserTeamRole> UserTeamRoleLastModByNavigation { get; set; }
        public virtual ICollection<UserTeam> UserTeamUser { get; set; }
    }
}
