using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoardManager_Data.BoardManagerContext.Models
{
    [Table("Column_Mapping_Board")]
    public partial class ColumnMappingBoard
    {
        [Key]
        public int Id { get; set; }
        [Column("Column_Board_Id")]
        public int ColumnBoardId { get; set; }
        [Column("Board_Id")]
        public int BoardId { get; set; }

        [ForeignKey(nameof(BoardId))]
        [InverseProperty("ColumnMappingBoard")]
        public virtual Board Board { get; set; }
        [ForeignKey(nameof(ColumnBoardId))]
        [InverseProperty("ColumnMappingBoard")]
        public virtual ColumnBoard ColumnBoard { get; set; }
    }
}
