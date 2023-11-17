using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using RetailStore.Api.Models.Domain;
using System.Xml.Linq;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace RetailStore.Api.Models
{
    [Table("ItemList")]
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int ReOrderLevel { get; set; }
        public int CompanyId { get; set; }
        public Company? Company { get; set; }
        public Item(int id, string name, int quantity, int reOrderLevel, int companyId)
        {
            Id = id;
            Name = name;
            Quantity = quantity;
            ReOrderLevel = reOrderLevel;
            CompanyId = companyId;
            
        }
    }
}
