using MediatR;

namespace CleanArchitectureSample.Application.Features.Member.Queries.GetMemberDetails
{
    public record GetMemberDetailsRequest(int Id) : IRequest<MemberDetailsDto>;
}
