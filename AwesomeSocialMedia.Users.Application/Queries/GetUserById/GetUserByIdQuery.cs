using AwesomeSocialMedia.Users.Application.Models;
using MediatR;

namespace AwesomeSocialMedia.Users.Application.Queries.GetUserById
{
    public class GetUserByIdQuery : IRequest<BaseResult<GetUserByIdDto>>
    {
        public GetUserByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}
