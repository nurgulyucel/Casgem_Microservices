﻿using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace CasgemMicroservices.Catalog.Dtos.ProductDtos
{
    public class UpdateProductDto
    {
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
       
        public decimal Price { get; set; }
        public string CategoryID { get; set; }
      

    }
}
