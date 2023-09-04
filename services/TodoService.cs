
using Microsoft.EntityFrameworkCore;

public class TodoService : ITodoService
{
    private readonly TodoDb _db;

    public TodoService(TodoDb db)
    {
        _db = db;
    }

    public async Task<IResult> CreateTodoAsync(TodoItemDTO todoItemDTO)
    {

        var todoItem = new Todo
        {
            IsComplete = todoItemDTO.IsComplete,
            Name = todoItemDTO.Name
        };

        _db.Todos.Add(todoItem);
        await _db.SaveChangesAsync();

        todoItemDTO = new TodoItemDTO(todoItem);

        return TypedResults.Created($"/todoitems/{todoItem.Id}", todoItemDTO);
    }

    public async Task<IResult> DeleteTodoAsync(int id)
    {
        if (await _db.Todos.FindAsync(id) is Todo todo)
        {
            _db.Todos.Remove(todo);
            await _db.SaveChangesAsync();
            return TypedResults.NoContent();
        }

        return TypedResults.NotFound();
    }

    public async Task<IResult> GetAllTodosAsync()
    {

        return TypedResults.Ok(await _db.Todos.Select(x => new TodoItemDTO(x)).ToArrayAsync());
    }

    public async Task<IResult> GetCompleteTodosAsync()
    {
        return TypedResults.Ok(await _db.Todos.Where(t => t.IsComplete).Select(x => new TodoItemDTO(x)).ToListAsync());
    }

    public async Task<IResult> GetTodoAsync(int id)
    {
        return await _db.Todos.FindAsync(id)
            is Todo todo
                ? TypedResults.Ok(new TodoItemDTO(todo))
                : TypedResults.NotFound();
    }

    public async Task<IResult> UpdateTodoAsync(int id, TodoItemDTO todoItemDTO)
    {
        var todo = await _db.Todos.FindAsync(id);

        if (todo is null) return TypedResults.NotFound();

        todo.Name = todoItemDTO.Name;
        todo.IsComplete = todoItemDTO.IsComplete;

        await _db.SaveChangesAsync();

        return TypedResults.NoContent();
    }

}
