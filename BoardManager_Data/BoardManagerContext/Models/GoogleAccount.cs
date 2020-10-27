using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoardManager_Data.BoardManagerContext.Models
{
    [Table("Google_Account")]
    public partial class GoogleAccount
    {
        [Key]
        [Column("User_Profile_Id")]
        public int UserProfileId { get; set; }
        [Key]
        [Column("Google_Id")]
        public int GoogleId { get; set; }

        [ForeignKey(nameof(UserProfileId))]
        [InverseProperty("GoogleAccount")]
        public virtual UserProfile UserProfile { get; set; }
    }
}
