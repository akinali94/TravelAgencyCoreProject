using DataAccessLayer.Concrete;
using TravelAgencyCoreProject.CQRS.Queries.DestinationQueries;
using TravelAgencyCoreProject.CQRS.Results.DestinationResults;

namespace TravelAgencyCoreProject.CQRS.Handlers.DestinationHandler
{
    public class GetAllDestinationByIdQueryHandler
    {
        private readonly Context _context;
        public GetAllDestinationByIdQueryHandler(Context context)
        {
            _context = context;
        }

        public GetDestinationQueryByIdResult Handle(GetDestinationByIDQuery query)
        {
            var values = _context.Destinations.Find(query.id);
            return new GetDestinationQueryByIdResult
            {
                DestinationID = values.DestinationID,
                City = values.City,
                DayNight = values.DayNight,
                Price = values.Price
            };
        }
    }
}
