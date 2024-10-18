using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManager.Management.Application.Contracts.Persistence;
using TicketManager.Management.Application.Exeptions;
using TicketManager.Management.Domain.Entities;

namespace TicketManager.Management.Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CreateCategoryCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncBaseRepository<Category> _categoryRepository;

        public CreateCategoryCommandHandler(IMapper mapper, IAsyncBaseRepository<Category> categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        public async Task<CreateCategoryCommandResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            CreateCategoryCommandResponse createCategoryCommandResponse = new();

            var validator = new CreateCategoryCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                createCategoryCommandResponse.Success = false;
                throw new ValidationException(validationResult);
            }

            if (createCategoryCommandResponse.Success)
            {
                Category category = new() { Name = request.Name };
                category = await _categoryRepository.AddAsync(category);
                createCategoryCommandResponse.Category = _mapper.Map<CreateCategoryDto>(category);
            }

            return createCategoryCommandResponse;

        }
    }
}
