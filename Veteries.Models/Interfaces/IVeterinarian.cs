namespace Veteries.Models.Interfaces
{
    public interface IVeterinarian : IPerson
    {
        public string OfficeName { get; set; }
        //public string WorkingHours { get; set; }
        // TODO: add Schedule prop
        public string PaymentRange { get; set; }
    }
}
