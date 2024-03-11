using CA.RoadReady.Application.Vehicles.SearchVehicles;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CA.RoadReady.Api.Controllers.Vehicles
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly ISender _sender;

        public VehiclesController(ISender sender)
        {
            _sender = sender;
        }


        [HttpGet()]
        public async Task<IActionResult> SearchVehicles(DateOnly startDate, DateOnly endDate, CancellationToken cancellationToken)
        {
            var query = new SearchVehiclesQuery(startDate, endDate);
            var result = await _sender.Send(query, cancellationToken);
            return Ok(result);
        }



    }
}
