using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoardManager_Data.BoardManagerContext.Models
{
    public partial class GoogleAccount
    {
        [Key]
        public int Id { get; set; }
        [Column("User_Profile_Id")]
        public int? UserProfileId { get; set; }
        [Column("Google_Id")]
        [StringLength(100)]
        public string GoogleId { get; set; }
        [StringLength(100)]
        public string UserName { get; set; }

        [ForeignKey(nameof(UserProfileId))]
        [InverseProperty("GoogleAccount")]
        public virtual UserProfile UserProfile { get; set; }
    }
}
