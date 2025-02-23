using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.models
{
    [Table("Comments")] // aula 25 --> nao e necessario mas ajuda
    public class Comment
    {
        public int? StockId { get; set; } // é assim que Stock e Comment estão linkados o core do ".net" faz a relação pra gente        
        // Propriedade de navegação
        public Stock? Stock { get; set; }
        public string? AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        // Propriedades do Comments
        public int Id { get; set; }
        public string? Title { get; set; } = string.Empty;
        public string? Content { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; } = DateTime.Now;

        
    }

}