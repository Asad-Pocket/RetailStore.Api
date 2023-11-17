using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RetailStore.Api.Models;
using RetailStore.Api.Models.ViewModel;
using RetailStore.Api.Repositories;

namespace RetailStore.Api.Controllers
{
    [Route("api/items")]
    [ApiController]
    [Authorize]
    public class ItemController : ControllerBase
    {
        private readonly IItemRepository _itemRepository;

        public ItemController(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        [HttpGet]
        public ActionResult<List<Item>> GetAllItems()
        {
            var items = _itemRepository.GetAllItems();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public ActionResult<Item> GetItemById(int id)
        {
            var item = _itemRepository.GetItemById(id);

            if (item == null)
                return NotFound();

            return Ok(item);
        }

        [HttpPost]
        public ActionResult AddItem(ItemViewModel item)
        {
            if (item == null)
                return BadRequest();

            _itemRepository.AddItem(item);
            return Ok(item);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateItem(int id,ItemViewModel item)
        {
            if (item == null || id != item.Id)
                return BadRequest();

            _itemRepository.UpdateItem(id,item);
            return Ok(item);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteItem(int id)
        {
            var existingItem = _itemRepository.GetItemById(id);

            if (existingItem == null)
                return NotFound();

            _itemRepository.DeleteItem(id);
            return Ok();
        }
        [HttpGet("DawonloadCSV")]
        public FileContentResult DownloadCsv()
        {
            List<Item> items = _itemRepository.GetAllItems().ToList();  // Retrieve items from the database here

            StringBuilder Csv = new StringBuilder();
            Csv.AppendLine("Id,Name,Quantity,ReOrderLevel,Company"); // Add headers

            foreach (var item in items)
            {
                Csv.AppendLine($"{item.Id},{item.Name},{item.Quantity},{item.ReOrderLevel},{item.Company.Name}");
            }

            byte[] data = Encoding.UTF8.GetBytes(Csv.ToString());
            return File(data, "text/csv", "itemlist.csv");
        }
    }
}
