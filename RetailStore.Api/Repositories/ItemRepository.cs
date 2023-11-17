using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using RetailStore.Api.Models.ViewModel;
using RetailStore.Api.Models;
using RetailStore.Api.Models.Domain;

namespace RetailStore.Api.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly ApplicationDbContext _context;

        public ItemRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddItem(ItemViewModel item)
        {
            _context.Database.ExecuteSqlRaw("EXEC CreateItem @Name, @Quantity, @ReOrderLevel, @CompanyId",
                new SqlParameter("@Name", item.Name),
                new SqlParameter("@Quantity", item.Quantity),
                new SqlParameter("@ReOrderLevel", item.ReOrderLevel),
                new SqlParameter("@CompanyId", item.CompanyId));
        }

        public void UpdateItem(int id, ItemViewModel item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));
            Item _entity = new Item(id, item.Name, item.Quantity, item.ReOrderLevel, item.CompanyId);

            //_context.ItemList.Update(_entity);
            //_context.SaveChanges();


            _context.Database.ExecuteSqlRaw("EXEC EditItem @Id, @Name, @Quantity, @ReOrderLevel, @CompanyId",
                new SqlParameter("@Id", _entity.Id),
                new SqlParameter("@Name", _entity.Name),
                new SqlParameter("@Quantity", _entity.Quantity),
                new SqlParameter("@ReOrderLevel", _entity.ReOrderLevel),
                new SqlParameter("@CompanyId", _entity.CompanyId));
        }

        public void DeleteItem(int id)
        {
            _context.Database.ExecuteSqlRaw("EXEC DeleteItem @Id", new SqlParameter("@Id", id));
        }


        public IEnumerable<Item> GetAllItems()
        {
            IEnumerable<Item> items = _context.ItemList.Include(x => x.Company).ToList();
            return items;
        }

            // Get a specific item by ID using a stored procedure
        public Item GetItemById(int id)
        {
            return _context.ItemList.FromSqlRaw("EXEC GetItemById @Id", new SqlParameter("@Id", id)).AsEnumerable().FirstOrDefault();
        }
    }
}
