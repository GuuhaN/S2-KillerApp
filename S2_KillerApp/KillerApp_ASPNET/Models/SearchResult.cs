using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace S2_KillerApp_ASPNET.Models
{
    public class SearchResult
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string TableName { get; set; }

        public SearchResult(int _ID, string _name, string _tableName)
        {
            ID = _ID;
            Name = _name;
            TableName = _tableName;
        }
    }
}
