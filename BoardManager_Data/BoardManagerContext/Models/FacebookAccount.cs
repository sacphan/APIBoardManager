using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoardManager_Data.BoardManagerContext.Models
{
    [Table("Facebook_Account")]
    public partial class FacebookAccount
    {
        [Key]
        [Column("User_Profile_Id")]
        public int UserProfileId { get; set; }
        [Key]
        [Column("Facebook_Id")]
        public int FacebookId { get; set; }

        [ForeignKey(nameof(UserProfileId))]
        [InverseProperty("FacebookAccount")]
        public virtual UserProfile UserProfile { get; set; }
    }
}
