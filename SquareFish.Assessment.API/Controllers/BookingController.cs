using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SquareFish.Assessment.Application.CQRS.Commands;
using SquareFish.Assessment.Application.CQRS.Queries;
using SquareFish.Assessment.Application.Exceptions;
using SquareFish.Assessment.Application.Interfaces;

namespace SquareFish.Assessment.API.Controllers
{
    // [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class BookingController : BaseController
    {
        public BookingController(ILoggedInUserContext loggedInUserContext) : base(loggedInUserContext)
        {
        }

        [HttpGet]
        public async Task<IActionResult> List(int? pageNo, int? pageCount)
        {
            var query = new GetAllBookingQuery();
            if (pageCount.HasValue)
            {
                query.PageCount = pageCount.Value;
            }
            if (pageNo.HasValue)
            {
                query.PageNo = pageNo.Value;
            }
            return Ok(await Mediator.Send(query));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetBookingByIdQuery { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBookingCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateBookingCommand command)
        {
            command.Id = id;
            try
            {
                await Mediator.Send(command);
                return Ok();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await Mediator.Send(new DeleteBookingByIdCommand { Id = id });
                return Ok();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
    }
}