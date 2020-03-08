using Veteries.Models;

namespace Veteries.Utility.UtilityModels.Interfaces
{
    public interface IAddress
    {
        string Street { get; set; }
        string ZipCode { get; set; }
        City City { get; set; }       
    }
}
