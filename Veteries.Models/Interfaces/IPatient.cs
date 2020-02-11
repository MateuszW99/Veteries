namespace Veteries.Models.Interfaces
{
    public interface IPatient
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Species Species { get; set; }
    }
}
