using DataAccessLayer.Concrete;
using MediatR;
using TravelAgencyCoreProject.CQRS.Commands.DestinationCommands;
using TravelAgencyCoreProject.CQRS.Commands.GuideCommands;
using TravelAgencyCoreProject.CQRS.Handlers.DestinationHandler;

namespace TravelAgencyCoreProject.CQRS.Handlers.GuideHandler
{
    public class RemoveGuideCommandHandler :IRequestHandler<RemoveGuideCommand>
    {
        private readonly Context _context;

        public RemoveGuideCommandHandler(Context context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(RemoveGuideCommand command, CancellationToken cancellationToken)
        {
            var values = await _context.Guides.FindAsync(command.Id);

            _context.Guides.Remove(values);
            _context.SaveChangesAsync();
            return Unit.Value;
        }
    }
}