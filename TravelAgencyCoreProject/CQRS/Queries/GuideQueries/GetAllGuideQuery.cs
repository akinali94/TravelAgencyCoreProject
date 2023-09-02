using MediatR;
using TravelAgencyCoreProject.CQRS.Results.GuideResults;

namespace TravelAgencyCoreProject.CQRS.Queries.GuideQueries
{
    public class GetAllGuideQuery : IRequest<List<GetAllGuideQueryResult>>
    {

    }
}
