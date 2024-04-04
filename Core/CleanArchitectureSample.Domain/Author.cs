using CleanArchitectureSample.Domain.Common;

namespace CleanArchitectureSample.Domain
{
    public class Author : BaseEntity
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
    }
}
