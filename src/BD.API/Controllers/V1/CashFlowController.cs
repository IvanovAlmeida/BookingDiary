using AutoMapper;
using BD.API.Extensions;
using BD.API.ViewModels;
using BD.API.ViewModels.CashFlow;
using BD.Business.Interfaces;
using BD.Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BD.API.Controllers.V1
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/cash-flow")]
    public class CashFlowController : MainController
    {
        private readonly ICashFlowRespository _cashFlowRespository;
        private readonly IMapper _mapper;
        public CashFlowController(IUser appUser, INotificator notificator, ICashFlowRespository cashFlowRespository, IMapper mapper) : base(appUser, notificator)
        {
            _cashFlowRespository = cashFlowRespository;
            _mapper = mapper;
        }

        [HttpGet("")]
        [ClaimsAuthorize("CashFlow", "All")]
        public async Task<IEnumerable<CashFlowViewModel>> Search(CashFlowSearchViewModel cashFlowSearchViewModel)
        {
            var cashFlows = await _cashFlowRespository.GetAll();

            return _mapper.Map<List<CashFlowViewModel>>(cashFlows);
        }

        [HttpGet("{id:int}")]
        [ClaimsAuthorize("CashFlow", "All")]
        public async Task<ActionResult> Get(int id)
        {
            var cashFlow = await _cashFlowRespository.GetById(id);

            if (cashFlow == null)
                return NotFound();

            return CustomResponse(cashFlow);
        }

        [HttpPost("")]
        [ClaimsAuthorize("CashFlow", "Add")]
        public async Task<ActionResult> Add(CashFlowViewModel cashFlowView)
        {
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            var cashFlow = await _cashFlowRespository.Add(_mapper.Map<CashFlow>(cashFlowView));

            return CustomResponse(cashFlow);
        }

        [HttpPut("{id:int}")]
        [ClaimsAuthorize("CashFlow", "Edit")]
        public async Task<ActionResult> Edit(int id, CashFlowViewModel cashFlowView)
        {
            if (id != cashFlowView.Id)
            {
                NotifyError("O id informado não é o mesmo que foi passado na query");
                return CustomResponse(cashFlowView);
            }

            if (!ModelState.IsValid) 
                return CustomResponse(ModelState);

            await _cashFlowRespository.Update(_mapper.Map<CashFlow>(cashFlowView));

            return CustomResponse(cashFlowView);
        }

        [HttpDelete("{id:int}")]
        [ClaimsAuthorize("CashFlow", "Disable")]
        public async Task<ActionResult> Desable(int id)
        {
            var cashFlow = await _cashFlowRespository.GetById(id);

            if (cashFlow == null)
                return NotFound();

            await _cashFlowRespository.Disable(id);

            return CustomResponse();
        }

        [HttpPatch("{id:int}")]
        [ClaimsAuthorize("CashFlow", "Reactive")]
        public async Task<ActionResult> Reactivate(int id)
        {
            var cashFlow = await _cashFlowRespository.GetById(id);

            if (cashFlow == null)
                return NotFound();

            await _cashFlowRespository.Reactivate(id);
            return CustomResponse();
        }
    }
}
