using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos
{
    public class CommentDto
    {
        public int? StockId { get; set; } // é assim que Stock e Comment estão linkados o core do ".net" faz a relação pra gente        
        // Propriedades do Comments
        public int Id { get; set; }
        public string? Title { get; set; } = string.Empty;
        public string? Content { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public string CreatedBy { get; set; } = string.Empty; // serve para colocar quem fez o comentario
    }
}