using AutoMapper;
using BD.API.Filter;
using BD.API.Helper.Search;
using BD.API.ViewModels;
using BD.Business.Interfaces;
using BD.Business.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BD.API.ViewModels.Reserve;
using Microsoft.AspNetCore.Authorization;
using BD.API.Extensions;

namespace BD.API.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/reserves")]
    public class ReserveController : MainController
    {
        private readonly IReserveRepository _reserveRepository;
        private readonly IReserveService _reserveService;
        private readonly IMapper _mapper;

        public ReserveController(IUser appUser, INotificator notificador, IReserveRepository reserveRepository, IReserveService reserveService, IMapper mapper) : base(appUser, notificador)
        {
            _mapper = mapper;
            _reserveService = reserveService;
            _reserveRepository = reserveRepository;
        }

        [HttpGet("")]
        [ClaimsAuthorize("Reserve", "All")]
        public async Task<IEnumerable<ReserveViewModel>> Search([FromQuery] PaginationFilter paginationFilter, [FromQuery] ReserveSearchViewModel reserveSearch)
        {            
            var exp = GenerateExpressionForSearch(reserveSearch);
            var reserves = _mapper.Map<IEnumerable<ReserveViewModel>>(
                    await _reserveRepository.FindWithItemsAndPagination(exp, paginationFilter.PageNumber, paginationFilter.PageSize)
                );

            return reserves;
        }


        [HttpGet("{id:int}")]
        [ClaimsAuthorize("Reserve", "Get")]
        public async Task<ActionResult<ReserveViewModel>> Get(int id)
        {
            var reserve = await _reserveRepository.GetByIdWithItems(id);

            if (reserve == null)
                return NotFound();

            return CustomResponse(_mapper.Map<ReserveViewModel>(reserve));
        }

        [HttpPost("")]
        [ClaimsAuthorize("Reserve", "Add")]
        public async Task<ActionResult<ReserveViewModel>> Add(ReserveViewModel reserveModel)
        {
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            var reserve = _mapper.Map<ReserveViewModel, Reserve>(reserveModel);
            reserve = await _reserveService.Add(reserve);

            reserveModel = _mapper.Map<ReserveViewModel>(reserve);

            return CustomResponse(reserveModel);
        }

        [HttpPut("{id:int}")]
        [ClaimsAuthorize("Reserve", "Edit")]
        public async Task<ActionResult<ReserveViewModel>> Update(int id, ReserveViewModel reserveModel)
        {
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            var reserve = _mapper.Map<Reserve>(reserveModel);

            await _reserveService.Update(reserve);

            return CustomResponse(reserveModel);
        }

        [HttpDelete("{id:int}")]
        [ClaimsAuthorize("Reserve", "Disable")]
        public async Task<ActionResult> Disable(int id)
        {
            await _reserveService.Disable(id);
            return CustomResponse();
        }

        [HttpPatch("{id:int}")]
        [ClaimsAuthorize("Reserve", "Reactive")]
        public async Task<ActionResult> Reactivate(int id)
        {
            await _reserveService.Reactivate(id);
            return CustomResponse();
        }
    
        private Expression<Func<Reserve, bool>> GenerateExpressionForSearch(ReserveSearchViewModel reserveSearch)
        {
            var searchHelper = new SearchHelper<Reserve>();

            if(reserveSearch.MinPrice != null)
                searchHelper
                    .AddAndExpression("Price", reserveSearch.MinPrice, ExpressionOperation.GreaterThanOrEqualTo);

            if (reserveSearch.MaxPrice != null)
                searchHelper
                    .AddAndExpression("Price", reserveSearch.MaxPrice, ExpressionOperation.LessThanOrEqualTo);

            if (reserveSearch.MinEntry != null)
                searchHelper
                    .AddAndExpression("Entry", reserveSearch.MinEntry, ExpressionOperation.GreaterThanOrEqualTo);

            if (reserveSearch.MaxEntry != null)
                searchHelper
                    .AddAndExpression("Entry", reserveSearch.MaxEntry, ExpressionOperation.LessThanOrEqualTo);

            if (reserveSearch.MinDateStart != null)
                searchHelper
                    .AddAndExpression("DateStart", reserveSearch.MinDateStart, ExpressionOperation.GreaterThanOrEqualTo);
            
            if (reserveSearch.MaxDateStart != null)
                searchHelper
                    .AddAndExpression("DateStart", reserveSearch.MaxDateStart, ExpressionOperation.LessThanOrEqualTo);

            if (reserveSearch.Enabled != null && !(bool) reserveSearch.Enabled)
                searchHelper
                    .AddAndExpression("DisabledAt", null, ExpressionOperation.NotEqualTo);
            
            if (reserveSearch.Enabled != null && (bool) reserveSearch.Enabled)
                searchHelper
                    .AddAndExpression("DisabledAt", null);
            
            return searchHelper.BuildExpression();
        }
    }
}
