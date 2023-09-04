public interface ITodoService
{
    Task<IResult> GetAllTodosAsync();
    Task<IResult> GetCompleteTodosAsync();
    Task<IResult> GetTodoAsync(int id);
    Task<IResult> CreateTodoAsync(TodoItemDTO todoItemDTO);
    Task<IResult> UpdateTodoAsync(int id, TodoItemDTO todoItemDTO);
    Task<IResult> DeleteTodoAsync(int id);
}