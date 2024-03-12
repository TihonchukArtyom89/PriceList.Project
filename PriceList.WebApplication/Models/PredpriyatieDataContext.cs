using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace PriceList.WebApplication.Models;

public class PredpriyatieDataContext:DataContext
{
    public PredpriyatieDataContext(string connectionString) :base(connectionString)
    {

    }
}
