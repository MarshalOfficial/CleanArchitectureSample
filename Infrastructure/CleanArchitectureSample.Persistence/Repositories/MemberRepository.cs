using CleanArchitectureSample.Application.Contracts.Persistence;
using CleanArchitectureSample.Domain;
using CleanArchitectureSample.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureSample.Persistence.Repositories
{
    public class MemberRepository : GenericRepository<Member>, IMemberRepository
    {
        public MemberRepository(CleanArchitectureDbContext context) : base(context)
        {
        }

        public async Task<bool> IsMemberUnique(Member entity)
        {
            return await _dbSet.AnyAsync(t =>
                t.FirstName == entity.FirstName &&
                t.LastName == entity.LastName &&
                t.Email == entity.Email &&
                t.DateOfBirth == entity.DateOfBirth
                ) == false;
        }
    }
}