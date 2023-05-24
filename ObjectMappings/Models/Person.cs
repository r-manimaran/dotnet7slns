namespace ObjectMappings.Models
{
    public class Person
    {
        public string Title { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime? DOB { get; set; }
        public Address? Address { get; set; }
    }
}
