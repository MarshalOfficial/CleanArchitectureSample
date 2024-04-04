using CleanArchitectureSample.Application.Contracts.Persistence;
using CleanArchitectureSample.Domain;
using CleanArchitectureSample.Persistence.Contexts;

namespace CleanArchitectureSample.Persistence.Repositories
{
    public class MemberRepository : GenericRepository<Member>, IMemberRepository
    {
        public MemberRepository(CleanArchitectureDbContext context) : base(context)
        {

        }
    }
}