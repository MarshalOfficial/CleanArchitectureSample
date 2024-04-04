using CleanArchitectureSample.Application.Features.Member.Commands._Share;
using MediatR;

namespace CleanArchitectureSample.Application.Features.Member.Commands.CreateMember
{
    public class CreateMemberRequest : BaseMemberRequest, IRequest<int>
    {
    }
}
