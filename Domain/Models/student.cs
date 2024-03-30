namespace schoolmanagement.Domain.Models
{
    public class student:BaseEntity
    {
        public int StudentID { get; set; }
        public string? Name { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? Address { get; set; }
        public string? Mobile { get; set; }
        public string? Email { get; set; }
        public DateTime? Year { get; set; }
        public string? SchoolCollege { get; set; }
        public string? Percentage { get; set; }
        public string? GuardianName { get; set; }
        public string? GuardianType { get; set; }
    }
}
