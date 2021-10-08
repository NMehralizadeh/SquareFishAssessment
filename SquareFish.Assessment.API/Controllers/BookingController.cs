using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SquareFish.Assessment.Application.Bookings.Commands;
using SquareFish.Assessment.Application.Bookings.Queries;
using SquareFish.Assessment.Application.Bookings.Queries.GetBookingDetails;
using SquareFish.Assessment.Application.Interfaces;
using SquareFish.Assessment.Domain.Entities;

namespace SquareFish.Assessment.API.Controllers
{
    // [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class BookingController : BaseController
    {
        public BookingController(ILoggedInUserContext loggedInUserContext) : base(loggedInUserContext)
        {
        }

        [HttpGet]
        public async Task<List<BookingDto>> List(int? pageNo)
        {
            return await Mediator.Send(
                new GetBookingListQuery
                {
                    PageCount = 10,
                    PageNo = pageNo.HasValue ? pageNo.Value : 0
                }).ConfigureAwait(false);
        }

        [HttpGet("{id:int}")]
        public async Task<BookingDto> Detail(int id)
        {
            return await Mediator.Send(
                new GetBookingDetailsQuery
                {
                    BookingId = id
                }).ConfigureAwait(false);
        }

        [HttpPost]
        public async Task<int> Create(string name,
                                      DateTime startDate,
                                      double price,
                                      BookingStatus status)
        {
            return await Mediator.Send(
                new CreateCommand
                {
                    Name = name,
                    StartDate = startDate,
                    price = price,
                    Status = status
                }
            ).ConfigureAwait(false);
        }

        [HttpPut]
        public async Task<int> Update(int id,
                                                     string name,
                                                     DateTime startDate,
                                                     double price,
                                                     BookingStatus status)
        {
            return await Mediator.Send(
                new UpdateCommand
                {
                    Id = id,
                    Name = name,
                    StartDate = startDate,
                    price = price,
                    Status = status
                }
            ).ConfigureAwait(false);
        }

        [HttpDelete]
        public async Task<int> Delete(int id)
        {
            return await Mediator.Send(
                new DeleteCommand
                {
                    Id = id
                }
            ).ConfigureAwait(false);
        }
    }
}