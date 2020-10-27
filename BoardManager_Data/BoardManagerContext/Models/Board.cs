using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoardManager_Data.BoardManagerContext.Models
{
    public partial class Board
    {
        public Board()
        {
            BoardDetail = new HashSet<BoardDetail>();
            ColumnMappingBoard = new HashSet<ColumnMappingBoard>();
        }

        [Key]
        public int Id { get; set; }
        [Column("User_Profile_Id")]
        public int? UserProfileId { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(500)]
        public string LinkShare { get; set; }

        [ForeignKey(nameof(UserProfileId))]
        [InverseProperty("Board")]
        public virtual UserProfile UserProfile { get; set; }
        [InverseProperty("Board")]
        public virtual ICollection<BoardDetail> BoardDetail { get; set; }
        [InverseProperty("Board")]
        public virtual ICollection<ColumnMappingBoard> ColumnMappingBoard { get; set; }
    }
}
