using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Application.Activities.Queries;
using Application.Activities.Commands;

namespace API.Controllers;

public class ActivitiesController : BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<List<Activity>>> GetActivities()
    {
        return await Mediator.Send(new GetActivityList.Query());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Activity>> GetActivityDetail(string id)
    {
        return await Mediator.Send(new GetActivityDetails.Query { Id = id });
    }

    [HttpPost]
    public async Task<ActionResult<string>> CreateActivity(Activity activity, CancellationToken cancellationToken)
    {
        return await Mediator.Send(new CreateActivity.Command { Activity = activity }, cancellationToken);
    }

    [HttpPut]
    public async Task<ActionResult> EditActivity(Activity activity)
    {
        await Mediator.Send(new EditActivity.Command{Activity = activity});

        return NoContent();
    }

    [HttpDelete]
    public async Task<ActionResult> DeleteActivity(string Id, CancellationToken cancellationToken)
    {
        await Mediator.Send(new DeleteActivity.Command { Id = Id }, cancellationToken);
        return Ok();
    }
}
