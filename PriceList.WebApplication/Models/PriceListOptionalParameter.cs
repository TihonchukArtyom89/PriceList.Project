﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PriceList.WebApplication.Models;
//класс для формирования таблицы в бд посвящённой необязательным параметрам прайс-листа товаров(EAV модель данных)
public class PriceListOptionalParameter
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Required]
    public long? OptionalParameterEntryID { get; set; }//ид сущности необязательного параметра для конкретного товара в определённом прайс листе//уникальный,первичный ключ
    [Required]
    public long? OptionalParameterID { get; set; }//ид необязательного параметра для конкретного товара в определённом прайс листе
    public string OptionalParameterValue { get; set; } = string.Empty;//значение необязательного параметра для конкретного товара в определённом прайс листе
    [Required]
    public long? PriceListLineID { get; set; }//ид позиции в определённом прайс листе для конкретного товара
}
