using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OutreachOperations.Api.Domain.Security
{
    public interface FindUserQuery
    {
        User Execute(string userName);
    }

}
