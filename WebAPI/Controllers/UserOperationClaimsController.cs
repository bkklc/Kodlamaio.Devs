using Application.Features.UserOperationsClaim.Commands.CreateUserOperationsClaim;
using Application.Features.UserOperationsClaim.Commands.DeleteUserOperationsClaim;
using Application.Features.UserOperationsClaim.Commands.UpdateUserOperationsClaim;
using Application.Features.UserOperationsClaim.Dtos;
using Application.Features.UserOperationsClaim.Models;
using Application.Features.UserOperationsClaim.Queries;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserOperationClaimsController : BaseController
    {
        [HttpPost("[action]")]
        public async Task<IActionResult> Add([FromBody] CreateUserOperationClaimCommand createUserOperationClaimCommand)
        {
            CreatedUserOperationClaimDto result = await Mediator.Send(createUserOperationClaimCommand);
            return Created("", result);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update(
            [FromBody] UpdateUserOperationClaimCommand updateUserOperationClaimCommand)
        {
            UpdatedUserOperationClaimDto result = await Mediator.Send(updateUserOperationClaimCommand);
            return Created("", result);
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> Delete(
            [FromBody] DeleteUserOperationClaimCommand deleteUserOperationClaimCommand)
        {
            DeletedUserOperationClaimDto result = await Mediator.Send(deleteUserOperationClaimCommand);
            return Created("", result);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListUserOperationClaimQuery getListUserOperationClaimQuery = new() { PageRequest = pageRequest };
            UserOperationClaimListModel result = await Mediator.Send(getListUserOperationClaimQuery);
            return Created("", result);
        }
    }
}
