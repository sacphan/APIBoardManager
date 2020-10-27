using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoardManager_Data.BoardManagerContext.Models
{
    [Table("Board_Detail")]
    public partial class BoardDetail
    {
        [Key]
        public int Id { get; set; }
        [StringLength(1000)]
        public string Content { get; set; }
        [Column("Column_Id")]
        public int? ColumnId { get; set; }
        [Column("Board_Id")]
        public int? BoardId { get; set; }

        [ForeignKey(nameof(BoardId))]
        [InverseProperty("BoardDetail")]
        public virtual Board Board { get; set; }
        [ForeignKey(nameof(ColumnId))]
        [InverseProperty(nameof(ColumnBoard.BoardDetail))]
        public virtual ColumnBoard Column { get; set; }
    }
}
