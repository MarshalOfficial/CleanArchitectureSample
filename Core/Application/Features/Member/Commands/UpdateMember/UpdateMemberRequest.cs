using CleanArchitectureSample.Application.Features.Member.Commands._Share;
using MediatR;

namespace CleanArchitectureSample.Application.Features.Member.Commands.UpdateMember
{
    public class UpdateMemberRequest : BaseMemberRequest, IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
