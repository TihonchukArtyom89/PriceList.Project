using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PriceList.WebApplication.Models;

public class PriceListProduct
{
    [Required]
    public long? PriceListLineID { get; set; }
    [Required]
    public long? PriceListID { get; set; }
    [Required]
    public long? ProductID { get; set; }
}
