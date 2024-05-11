using ToDoWebClient.Models;

namespace ToDoWebClient.Services;

public interface ITodoService
{
    Task<List<TodoItem>> GetAll();
    Task<TodoItem> GetById(int id);
}
