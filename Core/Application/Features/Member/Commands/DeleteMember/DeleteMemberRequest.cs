using MediatR;

namespace CleanArchitectureSample.Application.Features.Member.Commands.DeleteMember
{
    public record DeleteMemberRequest(int Id) : IRequest<Unit>;
}
