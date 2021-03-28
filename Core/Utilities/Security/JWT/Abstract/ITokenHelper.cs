using Core.Entities.Concrete;
using Core.Utilities.Security.JWT.Concrete;
using System.Collections.Generic;

namespace Core.Utilities.Security.JWT.Abstract
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
    }
}
