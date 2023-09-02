namespace TravelAgencyCoreProject.CQRS.Results.DestinationResults
{
    public class GetAllDestinationQueryResult
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Daynight { get; set; }
        public double Price { get; set; }
        public int Capacity { get; set; }
    }
}
