using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserOperationsClaim.Dtos
{
    public class UpdatedUserOperationClaimDto
    {
        public int Id { get; set; }
        public string OperationClaimName { get; set; }
        public string UserName { get; set; }
    }
}
