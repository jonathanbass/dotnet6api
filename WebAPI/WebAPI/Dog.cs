namespace WebAPI
{
    public class Dog
    {
        public string? Id { get; set; }
        public string Name { get; set; }
        public bool IsTrained { get; set; }
        public Genders Gender { get; set; }
        public decimal Height { get; set; }
        public decimal Length { get; set; }
        public decimal Weight { get; set; }
        public IEnumerable<string> Owners { get; set; }
        public int Age { get; set; }
    }
}
