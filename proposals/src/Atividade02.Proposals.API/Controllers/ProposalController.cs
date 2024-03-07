using System;
using Atividade02.Core.Common.Validators.Interfaces;
using Atividade02.Core.Mediator.Interfaces;
using Atividade02.Proposals.API.DTOs.Requests;
using Atividade02.Proposals.Application.Proposals.Commands;
using Microsoft.AspNetCore.Mvc;

namespace Atividade02.Proposals.API.Controllers
{
    [Route("proposals")]
    [ApiController]
    public class ProposalController : CommonController
    {
        public ProposalController(
            IMediatorHandler mediatorHandler,
            IValidatorServices validatorServices
        )
        : base(mediatorHandler, validatorServices)
        {
        }




        /// <summary>
        /// Get all proposals from cpf + cnpj
        /// </summary>
        /// <param name="cnpj"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string cpf, [FromQuery] string cnpj)
        {
            return Ok(null);
        }

        /// <summary>
        /// Get detail proposal
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        [HttpGet("{code}")]
        public async Task<IActionResult> GetById(string code)
        {
            return Ok(null);
        }

        /// <summary>
        /// Create credit proposal
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProposalRequest request)
        {
            var response = await _mediatorHandler.Send<CreateProposalCommand>(new CreateProposalCommand(
                request.Name,
                request.CPF,
                request.CNPJ,
                request.DDD,
                request.Cellphone
            ));

            

            return Ok(null);
        }


    }
}

