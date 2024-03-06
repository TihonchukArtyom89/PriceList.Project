using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PriceList.WebApplication.Models;
//класс для формирования таблицы в бд посвящённой товарам
public class Product
{
    public long? ProductID { get; set; } //ИД товара//уникальный,первичный ключ
    public string ProductName { get; set; } = string.Empty; //название товара
    public string ProductDescription { get; set; } = string.Empty; //описание товара
    public string ProductCategory { get; set; } = string.Empty; //категория товара

    [Column(TypeName ="decimal(8,2)")]
    public decimal ProductPrice { get; set; } //цена товара

}
