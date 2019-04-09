using EPM.Models;
using JMAInsurance.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JMAInsurance.Entity.Security
{
    [SoftDelete]
    [Table("Security.Users")]
    public class User : IdentityUser<int, UserLogin, UserRole, UserClaim>
    {
        public new int Id { get { return UserId; } }
        [Key]
        public int UserId
        {
            get { return base.Id; }
            set { base.Id = value; }
        }
        //public string UserName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string DistinguishedName { get; set; }
        public string JobTitle { get; set; }
        public string PhoneNumber { get; set; }

       

        public string PhotoSrcBase64
        {
            get
            {
                if (Photo == null || Photo.Length == 0)
                    return string.Empty;

                var base64 = Convert.ToBase64String(Photo);
                var imgSrc = string.Format("data:image/gif;base64,{0}", base64);

                return imgSrc;
            }
        }
        public string ADDepartment { get; set; }
        public string PhoneExtention { get; set; }
        //public string Email { get; set; }
        public bool IsActive { get; set; }
        public bool IsAdmin { get; set; }
        public bool? NeedUpdatePermissions { get; set; }
        public bool? IsSettingUpdated { get; set; }
        public bool IsSystemUser { get; set; }
        [InverseProperty("ToUser")]
        public virtual ICollection<Delegation> DelegatedTo { get; set; }
        public bool IsFormsAuthenticationUser { get; set; }
       
        public List<UserPermission> UserPermissions { get; set; }

        [InverseProperty("User")]
       


        public byte[] Photo { get; set; }
        [ForeignKey("ModifiedBy")]
        public int? ModifiedById { get; set; }

        public DateTime ModifiedOn { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool IsDeleted { get; set; }

        [ForeignKey("ModifiedById")]
        public virtual User ModifiedBy { get; set; }

      
    }

    #region Identity Configuration 
    [Table("Security.UserRole")]
    public class UserRole : IdentityUserRole<int>
    {
        [Key]
        public int UserRoleId { get; set; }
    }

    [Table("Security.UserClaims")]
    public class UserClaim : IdentityUserClaim<int>
    {
        [Key]
        public int UserClaimId { get; set; }
    }

    [Table("Security.UserLogins")]
    public class UserLogin : IdentityUserLogin<int>
    {
        [Key]
        public int UserLoginId { get; set; }
    }

    [Table("Security.Roles")]
    public class Role : IdentityRole<int, UserRole>
    {
        [Key]
        public int UserId { get; set; }
        public Role() { }
        public Role(string name) { Name = name; }
    }

    public class UserStore : UserStore<User, Role, int,
        UserLogin, UserRole, UserClaim>
    {
        public UserStore(JMAInsuranceContext context) : base(context)
        {
        }
    }

    public class RoleStore : RoleStore<Role, int, UserRole>
    {
        public RoleStore(JMAInsuranceContext context) : base(context)
        {
        }
    }

    #endregion
}
