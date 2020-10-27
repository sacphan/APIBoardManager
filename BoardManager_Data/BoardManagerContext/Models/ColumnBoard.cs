using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoardManager_Data.BoardManagerContext.Models
{
    [Table("Column_Board")]
    public partial class ColumnBoard
    {
        public ColumnBoard()
        {
            BoardDetail = new HashSet<BoardDetail>();
            ColumnMappingBoard = new HashSet<ColumnMappingBoard>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(1000)]
        public string Name { get; set; }

        [InverseProperty("Column")]
        public virtual ICollection<BoardDetail> BoardDetail { get; set; }
        [InverseProperty("ColumnBoard")]
        public virtual ICollection<ColumnMappingBoard> ColumnMappingBoard { get; set; }
    }
}
