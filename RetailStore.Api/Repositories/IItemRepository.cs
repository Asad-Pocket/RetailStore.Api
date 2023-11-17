
using RetailStore.Api.Models;
using RetailStore.Api.Models.ViewModel;

namespace RetailStore.Api.Repositories
{
    public interface IItemRepository 
    {
        public IEnumerable<Item> GetAllItems();
        public Item GetItemById(int id);
        public void AddItem(ItemViewModel item);
        public void UpdateItem(int id,ItemViewModel item);
        public void DeleteItem(int id);
    }

}
