using DataAccessLayer.Concrete;
using TravelAgencyCoreProject.CQRS.Commands.DestinationCommands;

namespace TravelAgencyCoreProject.CQRS.Handlers.DestinationHandler
{
    public class RemoveDestinationCommandHandler
    {
        private readonly Context _context;
        public RemoveDestinationCommandHandler(Context context)
        {
            _context = context;
        }

        public void Handle(RemoveDestinationCommand command)
        {
            var values = _context.Destinations.Find(command.Id);
            _context.Destinations.Remove(values);
            _context.SaveChanges();
        }
    }
}
