using DataAccessLayer.Concrete;
using TravelAgencyCoreProject.CQRS.Commands.DestinationCommands;

namespace TravelAgencyCoreProject.CQRS.Handlers.DestinationHandler
{
    public class UpdateDestinationCommandHandler
    {
        private readonly Context _context;
        public UpdateDestinationCommandHandler(Context context)
        {
            _context = context;
        }
        public void Handle(UpdateDestinationCommand command)
        {
            var values = _context.Destinations.Find(command.DestinationID);
            values.City = command.City;
            values.DayNight = command.DayNight;
            values.Price = command.Price;
            _context.SaveChanges();
        }
    }
}
