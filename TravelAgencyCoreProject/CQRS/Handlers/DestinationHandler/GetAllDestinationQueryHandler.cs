using DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using TravelAgencyCoreProject.CQRS.Queries.DestinationQueries;
using TravelAgencyCoreProject.CQRS.Results.DestinationResults;

namespace TravelAgencyCoreProject.CQRS.Handlers.DestinationHandler
{
    public class GetAllDestinationQueryHandler
    {
        private readonly Context _context;
        public GetAllDestinationQueryHandler(Context context)
        {
            _context = context;
        }

        public List<GetAllDestinationQueryResult> Handle()
        {
            var values = _context.Destinations.Select(x => new GetAllDestinationQueryResult
            {
                Id = x.DestinationID,
                Capacity = x.Capacity,
                City = x.City,
                Daynight = x.DayNight,
                Price = x.Price
            }).AsNoTracking().ToList();
            return values;
        }
    }
}
