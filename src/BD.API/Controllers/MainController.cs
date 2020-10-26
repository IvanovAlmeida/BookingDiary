using BD.API.Wrappers;
using BD.Business.Interfaces;
using BD.Business.Notifications;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq;

namespace BD.API.Controllers
{
    [ApiController]
    public abstract class MainController : ControllerBase
    {
        public readonly IUser AppUser;
        private readonly INotificator _notificator;

        protected int UserId { get; set; }
        protected bool UserIsAuthenticated { get; set; }

        protected MainController(IUser appUser, INotificator notificator)
        {
            AppUser = appUser;
            _notificator = notificator;

            if (appUser.IsAuthenticated())
            {
                UserId = appUser.GetUserId();
                UserIsAuthenticated = true;
            }
        }

        protected bool ValidOperation()
        {
            return !_notificator.HasNotification();
        }

        protected ActionResult CustomResponse(object result = null)
        {
            if (ValidOperation())
            {
                return Ok(new Response<object>(result));
            }

            return BadRequest(new Response<object> { 
                Success = false,
                Errors = _notificator.GetNotifications().Select(n => n.Message).ToArray()
            });
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            if (!modelState.IsValid) NotifyErrorInvalidModel(modelState);
            return CustomResponse();
        }

        protected void NotifyErrorInvalidModel(ModelStateDictionary modelState)
        {
            var errors = modelState.Values.SelectMany(e => e.Errors);
            foreach (var error in errors)
            {
                var errorMsg = error.Exception == null ? error.ErrorMessage : error.Exception.Message;
                NotifyError(errorMsg);
            }
        }

        protected void NotifyError(string message)
        {
            _notificator.Handle(new Notification(message));
        }
    }
}
