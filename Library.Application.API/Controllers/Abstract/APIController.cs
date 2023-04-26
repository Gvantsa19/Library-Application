using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Library.Application.API.Controllers.Abstract
{
    [ApiController]
    public class APIController : Controller
    {
        private IMediator _mediator;
        protected IMediator Mediator
        {
            get
            {
                if (_mediator is null)
                    _mediator = HttpContext.RequestServices.GetService<IMediator>();

                return _mediator!;
            }
        }
    }
}
