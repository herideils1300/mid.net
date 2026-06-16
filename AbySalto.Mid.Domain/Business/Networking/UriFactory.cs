using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AbySalto.Mid.Domain.Abstraction.Networking;


public enum Sort
{
    Asc,
    Desc
}

namespace AbySalto.Mid.Domain.Business.Networking
{
    public class UriFactory
    {
        private readonly IUriBuilder uriBuilder;

        public UriFactory(string root, string path)
        {
            this.uriBuilder = new UriBuilderImpl();
            this.uriBuilder.BuildProtocol(true);
            this.uriBuilder.BuildRoot(root);
            
        }

        public string GetUriForPaginationAndSorting(int page, string sortBy, Sort sort)
        {
            this.uriBuilder.BuildPath("/products");

            int numOfItemsPerPage = 10;
            KeyValuePair<string, string>[] args = [
                    KeyValuePair.Create("limit", $"{numOfItemsPerPage}"),
                    KeyValuePair.Create("skip", $"{numOfItemsPerPage * page}"),
                    KeyValuePair.Create("sortBY", sortBy),
                    KeyValuePair.Create("order", (sort == Sort.Asc) ? "asc" : "desc")
                ];

            this.uriBuilder.BuildArgs(args);

            return this.uriBuilder.ReturnFullUri();
        }

        public string GetUriForSearch(string searchValue)
        {
            this.uriBuilder.BuildPath("/products/search");
            this.uriBuilder.BuildArgs(KeyValuePair.Create("q", searchValue));

            return this.uriBuilder.ReturnFullUri();
        }
    }
}
