using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PriceList.WebApplication.Models;
//класс для формирования таблицы с обязательными значениями для прайс листов (ид позиции прайс листа, ид прайс листа, ид товара) 
public class PriceListProduct
{
    [Key]
    [Required]
    public long? PriceListLineID { get; set; }//ид определённой позиции прайс листа для указанного товара//уникальный,первичный ключ
    [Required]
    public long? PriceListID { get; set; }//ид прайс листа
    [Required]
    public long? ProductID { get; set; }//ид товара в прайс листе
}
