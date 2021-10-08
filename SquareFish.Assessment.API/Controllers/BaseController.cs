using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using SquareFish.Assessment.Application.Interfaces;

namespace SquareFish.Assessment.API.Controllers
{
    public class BaseController : Controller
    {
        protected readonly ILoggedInUserContext _loggedInUserContext;
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        

        public BaseController(ILoggedInUserContext loggedInUserContext)
        {
            _loggedInUserContext = loggedInUserContext;
        }
    }
}