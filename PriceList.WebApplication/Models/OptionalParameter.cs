using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportsStore.Models;
//класс для формирования справочной таблицы для необязательных параметров (ид,тип, название)
public class OptionalParameter
{
    [Required]
    public long? OptionalParameterID { get; set; }//ид необязательного параметра для прайс листа//уникальный,первичный ключ
    [Required(ErrorMessage = "Type is required.")]
    public string OptionalParameterType { get; set; } = string.Empty;//тип необязательного параметра для прайс листа
    [Required(ErrorMessage = "Name of optional parameter is required.")]
    public string OptionalParameterName { get; set; } = string.Empty;//название  необязательного параметра для прайс листа
}
