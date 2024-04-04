using CleanArchitectureSample.Application.Contracts.Persistence;
using CleanArchitectureSample.Application.Exceptions;
using MediatR;

namespace CleanArchitectureSample.Application.Features.Member.Commands.CreateMember
{
    public class CreateMemberRequestHandler : IRequestHandler<CreateMemberRequest, int>
    {
        private readonly IMemberRepository repository;

        public CreateMemberRequestHandler(IMemberRepository repository)
        {
            this.repository = repository;
        }

        public async Task<int> Handle(CreateMemberRequest request, CancellationToken cancellationToken)
        {
            //validating the incoming data
            var validator = new CreateMemberRequestValidator();
            var validationResult = validator.Validate(request);
            if (validationResult.IsValid == false)
            {
                throw new BadRequestException("something went wrong.", validationResult.ToDictionary());
            }

            //convert data to domain entity
            var itemToAdd = new Domain.Member
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Phone = request.Phone,
                Email = request.Email,
                PostalCode = request.PostalCode,
                DateOfBirth = request.DateOfBirth,
            };

            //add to database
            await repository.CreateAsync(itemToAdd);

            //return value
            return itemToAdd.Id;
        }
    }
}
