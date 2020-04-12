using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorOmdbTest.Store
{
    public enum ApplicationState
    {
        Initial = 0,
        CategoriesDisplayed,
        CategorySelected,
        ActorsDisplayed,
        ActorCardDisplayed,
        SearchPerformed,
        MoviesDisplayed,
        MovieCardDisplayed,
        ApplicationClosed
    }
}
