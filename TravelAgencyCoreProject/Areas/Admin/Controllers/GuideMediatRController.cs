using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TravelAgencyCoreProject.CQRS.Queries.GuideQueries;
using TravelAgencyCoreProject.CQRS.Commands.GuideCommands;

namespace TravelAgencyCoreProject.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    [Route("Admin/GuideMediatR/[action]")]

    public class GuideMediatRController : Controller
    {
        private readonly IMediator _mediator;
        public GuideMediatRController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IActionResult> Index()
        {
            var values = await _mediator.Send(new GetAllGuideQuery());
            return View(values);
        }

        [HttpGet]
        [Route("{id?}")]
        public async Task<IActionResult> GetGuides(int id)
        {
            var values = await _mediator.Send(new GetGuideByIDQuery(id));
            return View(values);
        }

        [HttpGet]
        public IActionResult AddGuide()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddGuide(CreateGuideCommand command)
        {
            await _mediator.Send(command);
            return RedirectToAction("Index");
        }

        [Route("{id?}")]
        public async Task<IActionResult> DeleteGuide(int id)
        {

            RemoveGuideCommand command = new RemoveGuideCommand(id);
            await _mediator.Send(command);
            return RedirectToAction("Index");
        }
    }
}
