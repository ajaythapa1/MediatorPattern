using MediatorR.Dtos;
using MediatR;

namespace MediatorR.Queries
{
    public class GetAllUserQuery :IRequest<List<UserDto>>
    {

    }
}
