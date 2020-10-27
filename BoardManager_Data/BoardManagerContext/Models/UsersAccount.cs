using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoardManager_Data.BoardManagerContext.Models
{
    [Table("Users_Account")]
    public partial class UsersAccount
    {
        [Key]
        public int Id { get; set; }
        [Column("User_Profile_Id")]
        public int UserProfileId { get; set; }
        [StringLength(100)]
        public string UserName { get; set; }
        [StringLength(100)]
        public string PassWord { get; set; }

        [ForeignKey(nameof(UserProfileId))]
        [InverseProperty("UsersAccount")]
        public virtual UserProfile UserProfile { get; set; }
    }
}
