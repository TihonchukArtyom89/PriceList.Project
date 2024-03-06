using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Dynamic;

namespace PriceList.WebApplication.Models;
//класс для формирования таблицы в бд посвящённой прайс-листам товаров
public class PriceList 
{
    public long? PriceListID { get; set; } //ИД прайс листа//уникальный,первичный ключ
    public string PriceListName { get; set; } = String.Empty; //название прайс листа
    public DateTime PriceListDateCreation { get; set; }  //дата создания прайс листа
    public DateTime PriceListDateModyfycation { get; set; } //дата изменения прайс листа

    //поле для списка товаров в этом прайс листе //коллекция или что то там в этом роде (обязательные параметры прайс листа это ид товара и его название)

    //поле для коллекции-словаря необязательных параметров (ид ключ необязательного параметра - название необязательного параметра)

}
