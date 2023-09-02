namespace TravelAgencyCoreProject.CQRS.Results.DestinationResults
{
    public class GetDestinationQueryByIdResult
    {
        public int DestinationID { get; set; }
        public string City { get; set; }
        public string DayNight { get; set; }
        public double Price { get; set; }
    }
}
