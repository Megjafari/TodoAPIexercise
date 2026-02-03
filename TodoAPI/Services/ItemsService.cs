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
        public void Update(int id, TodoItem updatedItem)
        {
            var item = _items.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                item.Title = updatedItem.Title;
                item.IsCompleted = updatedItem.IsCompleted;  // <-- uppdatera done-status
            }
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
