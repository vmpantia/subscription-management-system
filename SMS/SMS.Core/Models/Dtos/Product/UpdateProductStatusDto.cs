using SMS.Domain.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace SMS.Core.Models.Dtos.Product
{
    public class UpdateProductStatusDto
    {
        [Required]
        public CommonStatus NewStatus { get; set; }
    }
}
