using ToDoWebClient.Models;

namespace ToDoWebClient.Services;

public class TodoService : ITodoService
{
    private readonly ToDoIt.ToDoItClient _client;
    private ILogger<TodoService> _logger;

    public TodoService(ILogger<TodoService> logger, ToDoIt.ToDoItClient client)
    {
        _logger = logger;
        _client = client;
    }

    public async Task<List<TodoItem>> GetAll()
    {
        var request = new GetAllRequest();
        List<TodoItem> list = new();
        var response = await _client.ListToDoAsync(request);
        if (response is not null && response.ToDo is not null)
            foreach (var todo in response.ToDo)
                list.Add(new TodoItem()
                {
                    Id = todo.Id,
                    Title = todo.Title,
                    Description = todo.Description,
                    ToDoStatus = todo.ToDoStatus
                });

        return list;
    }

    public async Task<TodoItem> GetById(int id)
    {
        var request = new ReadToDoRequest() { Id = id };
        TodoItem item = new();
        var response = await _client.ReadToDoAsync(request);
        if (response is not null)
            item = new TodoItem()
            {
                Id = response.Id,
                Title = response.Title,
                Description = response.Description,
                ToDoStatus = response.ToDoStatus
            };
        return item;
    }
}
