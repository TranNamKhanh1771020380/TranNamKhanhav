using System;
using System.Collections.Generic;

namespace TodoApp
{
    public class TodoUI
    {
        private readonly TodoService _service;

        public TodoUI()
        {
            _service = new TodoService();
        }

        public void ShowTodos()
        {
            var todos = _service.GetAll();
            Console.WriteLine("=====DANH SÁCH CÔNG VIỆC=====");

            foreach (var todo in todos)
            {
                Console.WriteLine(todo.ToString());
            }

            if (todos.Count <= 0)
            {
                Console.WriteLine("Chưa có công việc!");
            }
        }
        public void ShowMenu()
        {
            Console.WriteLine("\nChức năng");
            Console.WriteLine("1. Thêm công việc");
            Console.WriteLine("2. Đánh dấu hoàn thành");
            Console.WriteLine("3. Sửa công việc");
            Console.WriteLine("4. Xóa công việc");
            Console.WriteLine("5. Thoát");  
        }

        private void AddTodo()
        {
            Console.Write("Nhập nội dung công việc: ");
            var input = Console.ReadLine();
            _service.AddTodo(input);
        }
        private void DeleteTodo()
        {
            Console.Write("Nhập ID công việc cần xóa: ");
            if (int.TryParse(Console.ReadLine(), out var id))
                _service.DeleteTodo(id);
            else
                Console.WriteLine("ID không hợp lệ.");
        }
        private void ToggleTodo()
        {
            Console.Write("Nhập ID công việc cần đánh dấu hoàn thành: ");
            if (int.TryParse(Console.ReadLine(), out var id))
                _service.ToggleTodo(id);
            else
                Console.WriteLine("ID không hợp lệ.");
        }
        private void UpdateTodo()
        {
            Console.Write("Nhập ID công việc cần sửa: ");
            if (!int.TryParse(Console.ReadLine(), out var id))
            {
                Console.WriteLine("ID không hợp lệ.");
                return;
            }
            Console.Write("Nhập nội dung mới: ");
            var title = Console.ReadLine();
            _service.UpdateTodo(id, title);
        }
        public void Run()
        {
            while (true)
            {
                Console.clear();
                ShowTodos();
                ShowMenu(); 
                Console.Write("Chọn: ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        AddTodo();
                        break;
                    case "2":
                        ToggleTodo();
                        break;
                    case "3":
                        UpdateTodo();
                        break;
                    case "4":
                        DeleteTodo();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ.");
                        break;
                }

                Console.WriteLine("\nNhấn Enter bất kỳ để tiếp tục...");
                Console.ReadLine();
            }
        }
    }
}
