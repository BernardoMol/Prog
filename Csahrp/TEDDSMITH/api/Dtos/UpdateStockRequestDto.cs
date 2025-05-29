using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos
{
    public class UpdateStockRequestDto
    {
        [Required]
        [MaxLength(10, ErrorMessage = "Simbolo não pode ter mais de 10 caracteres")]
        public string Symbol { get; set; } = string.Empty;
        [Required]
        [MaxLength(80, ErrorMessage = "Nome da empresa não pode ter mais de 80 caracteres")]
        public string CompanyName { get; set; } = string.Empty;
        [Required]
        [Range(1, 1000000)]
        public decimal Purchase { get; set; }
        public decimal LastDiv { get; set; }
        public string Industry { get; set; } = string.Empty;
        public long MarketCap { get; set; }
    }
}