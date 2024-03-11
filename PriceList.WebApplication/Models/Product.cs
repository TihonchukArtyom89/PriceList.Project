using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PriceList.WebApplication.Models;
//класс для формирования таблицы в бд посвящённой товарам
public class Product
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Required]
    public long? ProductID { get; set; } //ИД товара//уникальный,первичный ключ
    [Required(ErrorMessage ="Name of product is required.")]
    public string ProductName { get; set; } = string.Empty; //название товара
    [Required(ErrorMessage = "Description of product is required.")]
    public string ProductDescription { get; set; } = string.Empty; //описание товара
    [Required(ErrorMessage = "Category of product is required.")]
    public string ProductCategory { get; set; } = string.Empty; //категория товара
    [Required(ErrorMessage = "Price of product is required.")]
    [Column(TypeName ="decimal(8,2)")]
    public decimal ProductPrice { get; set; } //цена товара
    public List<PriceListProduct> PriceListProducts { get; set; } = new();//навигационное св-во на таблицу продуктов прайс листа
}
