using System;
using System.Collections.Generic;
using System.Text;

namespace SneakersStore.DataAccess.Entites
{
    public class SneakersEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Img { get; set; } = string.Empty;
    }
}
