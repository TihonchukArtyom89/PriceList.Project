using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PriceList.WebApplication.Models;
//класс для формирования таблицы в бд посвящённой товарам
public class Product
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Required]
    public long? ProductID { get; set; } //ИД товара//уникальный,первичный ключ
    [DisplayName("Название продукта")]
    [Required(ErrorMessage ="Name of product is required.")]
    public string ProductName { get; set; } = string.Empty; //название товара
    [DisplayName("Описание продукта")]
    [Required(ErrorMessage = "Description of product is required.")]
    public string ProductDescription { get; set; } = string.Empty; //описание товара
    [DisplayName("Категория продукта")]
    [Required(ErrorMessage = "Category of product is required.")]
    public string ProductCategory { get; set; } = string.Empty; //категория товара//сделать отдельную справочную таблицу для категорий
    [DisplayName("Цена продукта")]
    [Required(ErrorMessage = "Price of product is required.")]
    [Range(0.01,double.MaxValue,ErrorMessage ="Enter a positive price")]
    [Column(TypeName ="decimal(8,2)")]
    public decimal ProductPrice { get; set; } //цена товара
    public List<PriceListProduct> PriceListProducts { get; set; } = new();//навигационное св-во на таблицу продуктов прайс листа
}
