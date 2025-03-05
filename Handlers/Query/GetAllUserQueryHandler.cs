using MediatorR.Dtos;
using MediatorR.Queries;
using MediatorR.Repository.Interface;
using MediatR;

namespace MediatorR.Handlers.Query
{
    public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQuery,List<UserDto>>
    {
        private readonly IUserRepository _userRepository;

        public GetAllUserQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<UserDto>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            return await _userRepository.GetAllUser();
        }

    }
}
