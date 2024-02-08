using Application.Features.UserOperationsClaim.Dtos;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserOperationsClaim.Models
{
    public class UserOperationClaimListModel : BasePageableModel
    {
        public IList<UserOperationClaimListDto> Items { get; set; }
    }
}
