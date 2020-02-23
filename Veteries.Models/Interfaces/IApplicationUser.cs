namespace Veteries.Models.Interfaces
{
    public interface IApplicationUser
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string FullName { get; }
    }
}
