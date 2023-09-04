using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("/todoitems")]
public class TodoController : ControllerBase
{
    private readonly ITodoService _todoService;

    public TodoController(ITodoService todoService)
    {
        _todoService = todoService;
    }

    [HttpGet]
    public async Task<IResult> GetAllTodosAsync()
    {
        var result = await _todoService.GetAllTodosAsync();
        return result;
    }

    [HttpGet("complete")]
    public async Task<IResult> GetCompleteTodosAsync()
    {
        var result = await _todoService.GetCompleteTodosAsync();
        return result;
    }

    [HttpGet("{id}")]
    public async Task<IResult> GetTodoAsync(int id)
    {
        var result = await _todoService.GetTodoAsync(id);
        return result;
    }

    [HttpPost]
    public async Task<IResult> CreateTodoAsync([FromBody] TodoItemDTO todoItemDTO)
    {
        var result = await _todoService.CreateTodoAsync(todoItemDTO);
        return result;
    }

    [HttpPut("{id}")]
    public async Task<IResult> UpdateTodoAsync(int id, [FromBody] TodoItemDTO todoItemDTO)
    {
        var result = await _todoService.UpdateTodoAsync(id, todoItemDTO);
        
        return TypedResults.NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IResult> DeleteTodoAsync(int id)
    {
        var result = await _todoService.DeleteTodoAsync(id);
        return TypedResults.NoContent();
    }
}
