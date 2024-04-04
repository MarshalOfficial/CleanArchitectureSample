using CleanArchitectureSample.Domain.Common;

namespace CleanArchitectureSample.Domain
{
    public class Member : BaseEntity
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
    }
}