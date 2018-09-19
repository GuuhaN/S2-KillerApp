using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using S2_KillerApp_ASPNET.Data_Contexts;
using S2_KillerApp_ASPNET.Models;

namespace S2_KillerApp_ASPNET.Controllers
{
    [Authorize(Roles = "User, Admin")]
    public class SearchController : Controller
    {
        private Repositories.SearchRepository searchRepository;
        private Data_Contexts.ISearchContext searchContext;
        public SearchController()
        {
            searchContext = new SearchSqlContext();
            searchRepository = new Repositories.SearchRepository(searchContext);
        }

        [HttpGet]
        public IActionResult Browse(string searchTerm)
        {
            if (searchTerm == null)
                searchTerm = "";

            List<SearchResult> searchResults = searchRepository.GetSearchResults(searchTerm);
            return PartialView("_Browse", searchResults);
        }
    }
}