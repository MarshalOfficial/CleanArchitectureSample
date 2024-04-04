using CleanArchitectureSample.Domain;

namespace CleanArchitectureSample.Application.Contracts.Persistence
{
    public interface IMemberRepository : IGenericRepository<Member>
    {
        Task<bool> IsMemberUnique(Member entiry);
    }
}
