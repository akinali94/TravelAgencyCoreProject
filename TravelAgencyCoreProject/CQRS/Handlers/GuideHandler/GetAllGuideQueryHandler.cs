using DataAccessLayer.Concrete;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TravelAgencyCoreProject.CQRS.Queries.GuideQueries;
using TravelAgencyCoreProject.CQRS.Results.GuideResults;

namespace TravelAgencyCoreProject.CQRS.Handlers.GuideHandler
{
    public class GetAllGuideQueryHandler : IRequestHandler<GetAllGuideQuery, List<GetAllGuideQueryResult>>
    {
        private readonly Context _context;
        public GetAllGuideQueryHandler(Context context)
        {
            _context = context;
        }

        public async Task<List<GetAllGuideQueryResult>> Handle(GetAllGuideQuery request, CancellationToken cancellationToken)
        {
            return await _context.Guides.Select(x => new GetAllGuideQueryResult
            {
                GuideID = x.GuideID,
                Description = x.Description,
                Image = x.Image,
                Name = x.Name
            }).AsNoTracking().ToListAsync();
        }
    }
}
