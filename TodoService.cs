using System.Collections.Generic;

namespace TodoApp
{
    public class TodoService
    {
        private readonly TodoRepository _repository = new();

        public List<Todo> GetAll() => _repository.GetTodos();

        public Todo AddTodo(string title) => _repository.CreateTodo(title);

        public bool DeleteTodo(int id) => _repository.DeleteTodo(id);

        public bool ToggleTodo(int id) => _repository.ToggleTodo(id);

        public bool UpdateTodo(int id, string title) =>
            _repository.UpdateTodo(id, title);
    }
}
