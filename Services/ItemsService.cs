using TodoAPIexercise.Models;

namespace TodoAPIexercise.Services
{
    public class ItemsService
    {
        private readonly List<TodoItem> _items = new();
        private int _nextId = 1;

        //Get all
        public List<TodoItem> GetAll() => _items;

        //Get by id
        public TodoItem? GetById(int id)
        {
             return _items.FirstOrDefault(x => x.Id == id);
        }

        //Create
        public TodoItem Create (TodoItem newItem)
        {
            newItem.Id = _nextId++;
            _items.Add(newItem);
            return newItem;
        }

        //Update
        public bool Update(int id, TodoItem updatedItem)
        {
            var existing = GetById(id);
            if (existing == null) return false;

            existing.Title = updatedItem.Title;
            existing.IsCompleted = updatedItem.IsCompleted;
            return true;
        }

        //Delete
        public bool Delete(int id)
        {
            var item = GetById(id);
            if (item == null) return false;

            _items.Remove(item);
            return true;
        }
    }
}
