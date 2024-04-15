using AutoMapper;
using CleanArchitectureSample.Application.Contracts.Email;
using CleanArchitectureSample.Application.Contracts.Persistence;
using CleanArchitectureSample.Application.Exceptions;
using MediatR;

namespace CleanArchitectureSample.Application.Features.Member.Commands.CreateMember
{
    public class CreateMemberRequestHandler : IRequestHandler<CreateMemberRequest, int>
    {
        private readonly IMapper mapper;
        private readonly IMemberRepository repository;
        private readonly IEmailSender emailSender;

        public CreateMemberRequestHandler(IMapper mapper, IMemberRepository repository, IEmailSender emailSender)
        {
            this.mapper = mapper;
            this.repository = repository;
            this.emailSender = emailSender;
        }

        public async Task<int> Handle(CreateMemberRequest request, CancellationToken cancellationToken)
        {
            // validating incoming data
            var validator = new CreateMemberRequestValidator(mapper, repository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.IsValid == false)
            {
                throw new BadRequestException("Something went wrong.", validationResult.ToDictionary());
            }

            // convert to domain entity data
            var itemToAdd = mapper.Map<Domain.Member>(request);

            // add to database
            await repository.CreateAsync(itemToAdd);

            try
            {
                await emailSender.SendEmail(new Models.Email.EmailMessage
                {
                    To = itemToAdd.Email,
                    Subject = "Welcome to the library",
                    Body = $"Hello {itemToAdd.FirstName} {itemToAdd.LastName}, welcome to the library."
                });
            }
            catch (Exception ex)
            {
                new SmtpServerException(ex, itemToAdd.Email, "welcome message");
            }

            // return value
            return itemToAdd.Id;
        }
    }
}
