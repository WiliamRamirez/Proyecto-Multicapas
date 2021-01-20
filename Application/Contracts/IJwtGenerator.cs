using System.Collections.Generic;
using Domain.Entities;

namespace Application.Contracts
{
    public interface IJwtGenerator
    {
        string CreateToken(Usuario usuario, List<string> roles);
    }
}