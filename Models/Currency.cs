namespace OwlApp.Models
{
    public class Currency
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public bool Enabled { get; set; } = true;
    }
}