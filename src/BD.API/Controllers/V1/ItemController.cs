using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BD.API.Helper.Search;
using BD.API.ViewModels.Item;
using BD.Business.Models;
using BD.Business.Interfaces;
using BD.API.Extensions;
using Microsoft.AspNetCore.Authorization;

namespace BD.API.Controllers.V1
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/items")]
    public class ItemController : MainController
    {
        private readonly IItemRepository _itemRepository;
        private readonly IItemService _itemService;
        private readonly IMapper _mapper;

        public ItemController(IUser appUser, INotificator notificador, IItemRepository itemRepository, IItemService itemService, IMapper mapper) : base(appUser, notificador)
        {
            _itemRepository = itemRepository;
            _itemService = itemService;
            _mapper = mapper;
        }

        [HttpGet("")]
        [ClaimsAuthorize("Item", "All")]
        public async Task<IEnumerable<ItemViewModel>> Search([FromQuery] ItemSearchViewModel itemSearch)
        {
            var serchExpression = GenerateExpressionForSearch(itemSearch);
            var items = _mapper.Map<IEnumerable<ItemViewModel>>(await _itemRepository.Find(serchExpression));
            return items;
        }

        [HttpGet("{id:int}")]
        [ClaimsAuthorize("Item", "Get")]
        public async Task<ActionResult<ItemViewModel>> Get(int id)
        {
            var item = await _itemRepository.GetById(id);

            if (item == null)
                return NotFound();

            return CustomResponse(_mapper.Map<ItemViewModel>(item));
        }

        [HttpPost("")]
        [ClaimsAuthorize("Item", "Add")]
        public async Task<ActionResult<ItemViewModel>> Add(ItemViewModel itemModel)
        {
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            var item = _mapper.Map<Item>(itemModel);
            item = await _itemService.Add(item);

            itemModel = _mapper.Map<ItemViewModel>(item);

            return CustomResponse(itemModel);
        }

        [HttpPut("{id:int}")]
        [ClaimsAuthorize("Item", "Edit")]
        public async Task<ActionResult<ItemViewModel>> Update(int id, ItemViewModel itemModel)
        {
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            var item = _mapper.Map<Item>(itemModel);

            await _itemService.Update(item);

            return CustomResponse(itemModel);
        }

        [HttpDelete("{id:int}")]
        [ClaimsAuthorize("Item", "Disable")]
        public async Task<ActionResult> Disable(int id)
        {
            await _itemService.Disable(id);
            return CustomResponse();
        }

        [HttpPatch("{id:int}")]
        [ClaimsAuthorize("Item", "Reactive")]
        public async Task<ActionResult> Reactivate(int id)
        {
            await _itemService.Reactivate(id);
            return CustomResponse();
        }

        private Expression<Func<Item, bool>> GenerateExpressionForSearch(ItemSearchViewModel itemSearch)
        {
            var searchHelper = new SearchHelper<Item>();

            if (itemSearch.MinPrice != null)
                searchHelper
                    .AddAndExpression("Price", itemSearch.MinPrice, ExpressionOperation.GreaterThanOrEqualTo);
            
            if (itemSearch.MaxPrice != null)
                searchHelper
                    .AddAndExpression("Price", itemSearch.MaxPrice, ExpressionOperation.LessThanOrEqualTo);
            
            if (itemSearch.MinQuantity != null)
                searchHelper
                    .AddAndExpression("Quantity", itemSearch.MinQuantity, ExpressionOperation.GreaterThanOrEqualTo);
            if (itemSearch.MaxQuantity != null)
                searchHelper
                    .AddAndExpression("Quantity", itemSearch.MaxQuantity, ExpressionOperation.LessThanOrEqualTo);

            if (!string.IsNullOrWhiteSpace(itemSearch.Name))
                searchHelper
                    .AddAndExpression("Name", itemSearch.Name, ExpressionOperation.Contains);

            if (!string.IsNullOrWhiteSpace(itemSearch.Description))
                searchHelper
                    .AddAndExpression("Description", itemSearch.Description, ExpressionOperation.Contains);

            if (itemSearch.Enabled != null && !(bool) itemSearch.Enabled)
                searchHelper
                    .AddAndExpression("DisabledAt", null, ExpressionOperation.NotEqualTo);
            
            if (itemSearch.Enabled != null && (bool) itemSearch.Enabled)
                searchHelper
                    .AddAndExpression("DisabledAt", null);
            
            return searchHelper.BuildExpression();
        }
    }
}
