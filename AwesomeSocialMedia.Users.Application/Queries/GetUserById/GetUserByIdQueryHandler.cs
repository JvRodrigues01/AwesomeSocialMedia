using AwesomeSocialMedia.Users.Application.Models;
using AwesomeSocialMedia.Users.Core.Repositories;
using MediatR;

namespace AwesomeSocialMedia.Users.Application.Queries.GetUserById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, BaseResult<GetUserByIdDto>>
    {
        private readonly IUserRepository _repository;
        public GetUserByIdQueryHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseResult<GetUserByIdDto>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetByIdAsync(request.Id);

            var dto = new GetUserByIdDto(user);

            return new BaseResult<GetUserByIdDto>(dto);
        }
    }
}
