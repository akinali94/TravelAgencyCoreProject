using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using MediatR;
using TravelAgencyCoreProject.CQRS.Commands.GuideCommands;

namespace TravelAgencyCoreProject.CQRS.Handlers.GuideHandler
{
    public class CreateGuideCommanHandler : IRequestHandler<CreateGuideCommand>
    {
        private readonly Context _context;
        public CreateGuideCommanHandler(Context context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(CreateGuideCommand request, CancellationToken cancellationToken)
        {
            _context.Guides.Add(new Guide
            {
                Name = request.Name,
                Description = request.Description,
                Image = request.Image,
                TwitterUrl = request.TwitterUrl,
                InstagramUrl = request.InstaUrl,
                Status = true
            });
            await _context.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
