using MediatR;
using TravelAgencyCoreProject.CQRS.Results.GuideResults;

namespace TravelAgencyCoreProject.CQRS.Queries.GuideQueries
{
    public class GetGuideByIDQuery : IRequest<GetGuideByIDQueryResult>
    {
        public GetGuideByIDQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
