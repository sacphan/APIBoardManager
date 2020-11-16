using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoardManager_Data.BoardManagerContext.Models
{
    [Table("User_Profile")]
    public partial class UserProfile
    {
        public UserProfile()
        {
            Board = new HashSet<Board>();
            FacebookAccount = new HashSet<FacebookAccount>();
            GoogleAccount = new HashSet<GoogleAccount>();
            UsersAccount = new HashSet<UsersAccount>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string Firstname { get; set; }
        [StringLength(100)]
        public string LastName { get; set; }
        [StringLength(100)]
        public string Email { get; set; }

        [InverseProperty("UserProfile")]
        public virtual ICollection<Board> Board { get; set; }
        [InverseProperty("UserProfile")]
        public virtual ICollection<FacebookAccount> FacebookAccount { get; set; }
        [InverseProperty("UserProfile")]
        public virtual ICollection<GoogleAccount> GoogleAccount { get; set; }
        [InverseProperty("UserProfile")]
        public virtual ICollection<UsersAccount> UsersAccount { get; set; }
    }
}
