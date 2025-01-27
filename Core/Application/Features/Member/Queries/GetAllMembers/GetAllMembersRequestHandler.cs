﻿using AutoMapper;
using CleanArchitectureSample.Application.Contracts.Persistence;
using MediatR;

namespace CleanArchitectureSample.Application.Features.Member.Queries.GetAllMembers
{
    public class GetAllMembersRequestHandler : IRequestHandler<GetAllMembersRequest, List<MemberDto>>
    {
        private readonly IMapper _mapper;
        private readonly IMemberRepository _repository;

        public GetAllMembersRequestHandler(IMapper mapper, IMemberRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<List<MemberDto>> Handle(GetAllMembersRequest request, CancellationToken cancellationToken)
        {
            // Query the database
            var members = await _repository.GetAllAsync();

            // convert to DTO objects
            var result = _mapper.Map<List<MemberDto>>(members);

            // return value
            return result;
        }
    }
}
