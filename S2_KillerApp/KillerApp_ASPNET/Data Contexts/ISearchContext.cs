using System.Collections.Generic;
using S2_KillerApp_ASPNET.Models;

namespace S2_KillerApp_ASPNET.Data_Contexts
{
    public interface ISearchContext
    {
        List<SearchResult> Search(string searchTerm);
    }
}
