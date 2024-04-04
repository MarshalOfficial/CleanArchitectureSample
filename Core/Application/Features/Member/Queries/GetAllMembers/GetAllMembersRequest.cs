using MediatR;

namespace CleanArchitectureSample.Application.Features.Member.Queries.GetAllMembers
{
    public record GetAllMembersRequest : IRequest<List<MemberDto>>;
}
