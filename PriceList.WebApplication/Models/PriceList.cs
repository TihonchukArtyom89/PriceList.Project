using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PriceList.WebApplication.Models;

public class PriceList
{
    public long? PriceListID { get; set; }
    public string PriceListName { get; set; } = String.Empty;
    public DateTime PriceListDateCreation { get; set; }
    public DateTime PriceListDateModyfycation { get; set; }
    //public long[] PriceListProductIDs { get; set; } = Array.Empty<long>();//массив ид продуктов в этом прайс листе
    /*добавление новых столбцов с разными типами данных реализовать через метод массив? список? коллекция?*/
}
