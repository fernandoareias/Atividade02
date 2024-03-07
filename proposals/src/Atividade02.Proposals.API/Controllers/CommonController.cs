using System;
using Atividade02.Core.Common.CQRS;
using Atividade02.Core.Common.Enums;
using Atividade02.Core.Common.Validators.Interfaces;
using Atividade02.Core.Mediator.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Atividade02.Proposals.API.Controllers
{
    public class CommonController : ControllerBase
    {
        public CommonController(
            IMediatorHandler mediatorHandler,
            IValidatorServices validatorServices)
        {
            _mediatorHandler = mediatorHandler;
            _validatorServices = validatorServices;
        }

        protected readonly IValidatorServices _validatorServices;
        protected readonly IMediatorHandler _mediatorHandler;


        protected virtual bool ErroNoProcessamento => _validatorServices.ValidationResult.Errors.Any();


        #region 2xxx

        public IActionResult RetornaOk<T>() where T : View
        => new OkObjectResult(new BaseResponse<T>(System.Net.HttpStatusCode.OK, $"Operation carried out successfully."));

        public IActionResult RetornaOk<T>(T view) where T : View
         => new OkObjectResult(new BaseResponse<T>(System.Net.HttpStatusCode.OK, $"Operation carried out successfully.", view));


        public IActionResult RetornaOkComLista<T>(List<T> view) where T : View
            => new OkObjectResult(new BaseListResponse<T>(System.Net.HttpStatusCode.OK, "Operation carried out successfully.", view!));

        public IActionResult RetornaOkComListaVazia<T>() where T : View
           => new OkObjectResult(new BaseListResponse<T>(System.Net.HttpStatusCode.OK, "Operation carried out successfully."));

        public IActionResult ReturnNotFound<T>(string message) where T : View
            => new NotFoundObjectResult(new BaseResponse<T>(System.Net.HttpStatusCode.NotFound, message));
        #endregion

        #region 4xx

        public IActionResult ReturnBadRequestComErros<T>(string codigo, string grupoErro) where T : View
            => new BadRequestObjectResult(new BaseResponse<T>(System.Net.HttpStatusCode.BadRequest, _validatorServices.ValidationResult.Errors.Select(c => new ResponseErroView(codigo, grupoErro, c.ErrorMessage)).ToList()));


        public IActionResult ReturnBadRequestComErros<T>() where T : View
             => new BadRequestObjectResult(new BaseResponse<T>(System.Net.HttpStatusCode.BadRequest, _validatorServices.ValidationResult.Errors.Select(c => new ResponseErroView(EBaseErro.INVALID_FIELD.ToString(), "BAD_REQUEST", c.ErrorMessage)).ToList()));

        #endregion
    }
}

