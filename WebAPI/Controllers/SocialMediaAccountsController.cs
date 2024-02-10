﻿using Application.Features.SocialMediaAccounts.Commands.CreateSocialMediaAccount;
using Application.Features.SocialMediaAccounts.Commands.DeleteSocialMediaAccount;
using Application.Features.SocialMediaAccounts.Commands.UpdateSocialMediaAccount;
using Application.Features.SocialMediaAccounts.Dtos;
using Application.Features.SocialMediaAccounts.Models;
using Application.Features.SocialMediaAccounts.Queries.GetListSocialMediaAccount;
using Core.Application.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaAccountsController : BaseController
    {
        [HttpPost("[action]")]
        public async Task<IActionResult> Add([FromBody] CreateSocialMediaAccountCommand createSocialMediaAccountListModelCommand)
        {
            CreatedSocialMediaAccountDto createdSocialMediaAccountListModelDto = await Mediator!.Send(createSocialMediaAccountListModelCommand);
            return Created("", createdSocialMediaAccountListModelDto);
        }


        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] UpdateSocialMediaAccountCommand UpdateSocialMediaAccountCommand)
        {
            UpdatedSocialMediaAccountDto updatedSocialMediaAccountListModelDto = await Mediator!.Send(UpdateSocialMediaAccountCommand);
            return Created("", updatedSocialMediaAccountListModelDto);
        }
        [HttpDelete("[action]")]
        public async Task<IActionResult> Delete([FromBody] DeleteSocialMediaAccountCommand deleteSocialMediaAccountCommand)
        {
            DeletedSocialMediaAccountDto deletedSocialMediaAccountDto = await Mediator!.Send(deleteSocialMediaAccountCommand);
            return Created("", deletedSocialMediaAccountDto);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListSocialMediaAccountQuery getListSocialMediaAccountQuery = new() { PageRequest = pageRequest };
            SocialMediaAccountListModel result = await Mediator!.Send(getListSocialMediaAccountQuery);
            return Ok(result);
        }
    }
}