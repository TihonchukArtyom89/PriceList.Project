using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportsStore.Models;

public class TypePriceListOptionalParameter
{
    [Required]
    public long? OptionalParameterTypeID { get; set; }
    [Required(ErrorMessage = "Name of type is required.")]
    public string OptionalParameterTypeName { get; set; } = string.Empty;
}
