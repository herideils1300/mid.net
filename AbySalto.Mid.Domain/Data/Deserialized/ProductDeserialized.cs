using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbySalto.Mid.Domain.Data.Deserialized
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);

     public class ProductDeserialized
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public double price { get; set; }
        public double rating { get; set; }
        public int stock { get; set; }
    }

    public class Root
    {
        public List<ProductDeserialized> products { get; set; }
        public int total { get; set; }
        public int skip { get; set; }
        public int limit { get; set; }
    }


    


}
