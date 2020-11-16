using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoardManager_Data.BoardManagerContext.Models
{
    public partial class FacebookAccount
    {
        [Key]
        public int Id { get; set; }
        [Column("User_Profile_Id")]
        public int? UserProfileId { get; set; }
        [Column("Facebook_Id")]
        [StringLength(100)]
        public string FacebookId { get; set; }
        [StringLength(100)]
        public string UserName { get; set; }

        [ForeignKey(nameof(UserProfileId))]
        [InverseProperty("FacebookAccount")]
        public virtual UserProfile UserProfile { get; set; }
    }
}
