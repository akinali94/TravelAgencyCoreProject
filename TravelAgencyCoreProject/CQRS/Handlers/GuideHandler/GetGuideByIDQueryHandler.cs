using DataAccessLayer.Concrete;
using MediatR;
using TravelAgencyCoreProject.CQRS.Queries.GuideQueries;
using TravelAgencyCoreProject.CQRS.Results.GuideResults;

namespace TravelAgencyCoreProject.CQRS.Handlers.GuideHandler
{
    public class GetGuideByIDQueryHandler : IRequestHandler<GetGuideByIDQuery, GetGuideByIDQueryResult>
    {
        private readonly Context _context;

        public GetGuideByIDQueryHandler(Context context)
        {
            _context = context;
        }

        public async Task<GetGuideByIDQueryResult> Handle(GetGuideByIDQuery request, CancellationToken cancellationToken)
        {
            var values = await _context.Guides.FindAsync(request.Id);
            return new GetGuideByIDQueryResult
            {
                GuideID = values.GuideID,
                Description = values.Description,
                Name = values.Name
            };
        }
    }
}
