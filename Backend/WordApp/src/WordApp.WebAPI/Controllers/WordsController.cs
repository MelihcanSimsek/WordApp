
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WordApp.Application.Features.Words.Commands.AddWord;
using WordApp.Application.Features.Words.Commands.DeleteWord;
using WordApp.Application.Features.Words.Commands.UpdateWordCheckedTime;
using WordApp.Application.Features.Words.Commands.UpdateWordToKnown;
using WordApp.Application.Features.Words.Queries.GetAllDailyWords;
using WordApp.Application.Features.Words.Queries.GetAllKnownWords;

namespace WordApp.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class WordsController : ControllerBase
    {
        private readonly IMediator mediator;

        public WordsController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddWordCommandRequest request)
        {
            var response = await mediator.Send(request);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] Guid id)
        {
            var response = await mediator.Send(new DeleteWordCommandRequest(id));
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateWordChecked([FromQuery] Guid id)
        {
            var response = await mediator.Send(new UpdateWordCheckedTimeCommandRequest(id));
            return Ok();
        }


        [HttpPut]
        public async Task<IActionResult> UpdateWordToKnown([FromQuery] Guid id)
        {
            var response = await mediator.Send(new UpdateWordToKnownCommandRequest(id));
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDailyWords()
        {
            var response = await mediator.Send(new GetAllDailyWordsQueryRequest());
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllKnownWords()
        {
            var response = await mediator.Send(new GetAllKnownWordsQueryRequest());
            return Ok(response);
        }
    }
}
