using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using S2_KillerApp_ASPNET.Data_Contexts;
using S2_KillerApp_ASPNET.Models;

namespace S2_KillerApp_ASPNET.Repositories
{
    public class SearchRepository
    {
        private ISearchContext searchContext;
        public SearchRepository(ISearchContext _searchContext)
        {
            searchContext = _searchContext;
        }

        public List<SearchResult> GetSearchResults(string searchTerm)
        {
            return searchContext.Search(searchTerm);
        }
    }
}
