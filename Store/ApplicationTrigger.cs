using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorOmdbTest.Store
{
    public enum ApplicationTrigger
    {
        SeeCategories,
        SelectCategory,
        SeeActors,
        SelectActor,
        Search,
        SeeMovies,
        SelectMovie,
        GoHome
    }
}
