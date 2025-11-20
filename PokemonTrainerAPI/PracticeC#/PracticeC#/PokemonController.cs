using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace PracticeC_
{
    public class PokemonController : Controller
    {
        private readonly IMediator mediator;

        public PokemonController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {

            await mediator.Send(new AddPokemonCommand { Name = "Charmander" });
            var list = await mediator.Send(new GetAllPokemonQuery());

            return Ok(list);
        }
    }
}
