using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorOmdbTest.Components.SearchBarComponent
{
    public class SearchEventArgs: EventArgs
    {
        public SearchEventArgs(string textQuery)
        {
            TextQuery = textQuery;
        }

        public string TextQuery { get; private set; }
    }
}
