using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos
{
    public class UpdateRequestCommentDto
    {   
        [Required]
        [MinLength(5, ErrorMessage = "Title precisa de pelo menos 5 caracteres")]
        [MaxLength(80, ErrorMessage = "Title não pode ter mais de 80 caracteres")]
        public string? Title { get; set; } = string.Empty;
        [Required]
        [MinLength(5, ErrorMessage = "Comentario precisa de pelo menos 5 caracteres")]
        [MaxLength(300, ErrorMessage = "Coimentario não pode ter mais de 80 caracteres")]
        public string? Content { get; set; } = string.Empty;
    }
}