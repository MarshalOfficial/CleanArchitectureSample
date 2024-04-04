using AutoMapper;
using CleanArchitectureSample.Application.Contracts.Persistence;
using MediatR;

namespace CleanArchitectureSample.Application.Features.Member.Queries.GetMemberDetails
{
    public class GetMemberDetailsRequestHandler : IRequestHandler<GetMemberDetailsRequest, MemberDetailsDto>
    {

        private readonly IMapper _mapper;
        private readonly IMemberRepository _repository;

        public GetMemberDetailsRequestHandler(IMapper mapper, IMemberRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<MemberDetailsDto> Handle(GetMemberDetailsRequest request, CancellationToken cancellationToken)
        {
            // Query the database
            var members = await _repository.GetByIdAsync(request.Id);

            // convert to DTO objects
            var result = _mapper.Map<MemberDetailsDto>(members);

            // return value
            return result;
        }
    }
}
