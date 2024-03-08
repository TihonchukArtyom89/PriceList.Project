using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PriceList.WebApplication.Models;
//класс для формирования таблицы в бд посвящённой необязательным параметрам прайс-листа товаров(EAV модель данных)
public class PriceListOptionalParameter
{
    [Required]
    public long? OptionalParameterID { get; set; }
    public string OptionalParameterName { get; set; } = string.Empty;//сделать ещё одну справочную таблицу под необязательные параметры наподобие справочной таблицы типов
    [Required]
    public long? OptionalParameterTypeID { get; set; }
    public string OptionalParameterValue { get; set; } = string.Empty;
    [Required]
    public long? PriceListLineID { get; set; }
}
