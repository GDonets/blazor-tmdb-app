﻿using Stateless;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorOmdbTest.Store
{
    public class ApplicationStore
    {
        private StateMachine<ApplicationState, ApplicationTrigger> _machine;

        public ApplicationStore()
        {
            _machine = new StateMachine<ApplicationState, ApplicationTrigger>(ApplicationState.Initial);
            Initialize();
        }

        private void Initialize() {

            _machine.Configure(ApplicationState.Initial)
                //TODO: movie category selection should update the filter with category and move to MoviesDisplayed
                //.OnEntryFrom(_machine.SetTriggerParameters<string>(ApplicationTrigger.SelectCategory), category => SelectedMovieCategory = category)
                .Permit(ApplicationTrigger.SeeMovies, ApplicationState.MoviesDisplayed)
                .OnEntryFrom(_machine.SetTriggerParameters<int>(ApplicationTrigger.SelectActor), actor => SelectedActor = actor)
                .Permit(ApplicationTrigger.SelectActor, ApplicationState.ActorCardDisplayed)
                .Permit(ApplicationTrigger.SeeCategories, ApplicationState.CategoriesDisplayed)
                .Permit(ApplicationTrigger.SeeActors, ApplicationState.ActorsDisplayed);

            _machine.Configure(ApplicationState.CategoriesDisplayed)
                //TODO: movie category selection should update the filter with category and move to MoviesDisplayed
                //.OnEntryFrom(_machine.SetTriggerParameters<string>(ApplicationTrigger.SeeMovies), category => SelectedMovieCategory = category)
                .Permit(ApplicationTrigger.SeeMovies, ApplicationState.MoviesDisplayed);

            _machine.Configure(ApplicationState.ActorsDisplayed)
                .OnEntryFrom(_machine.SetTriggerParameters<int>(ApplicationTrigger.SelectActor), actor => SelectedActor = actor)
                .Permit(ApplicationTrigger.SelectActor, ApplicationState.ActorCardDisplayed);

            _machine.Configure(ApplicationState.ActorCardDisplayed)
                .OnEntryFrom(_machine.SetTriggerParameters<int>(ApplicationTrigger.SelectMovie), movie => SelectedMovie = movie)
                .Permit(ApplicationTrigger.SelectMovie, ApplicationState.MovieCardDisplayed)
                //TODO: update filter with actor
                .Permit(ApplicationTrigger.SeeMovies, ApplicationState.MoviesDisplayed);

            _machine.Configure(ApplicationState.MoviesDisplayed)
                .OnEntryFrom(_machine.SetTriggerParameters<int>(ApplicationTrigger.SelectMovie), movie => SelectedMovie = movie)
                .Permit(ApplicationTrigger.SelectMovie, ApplicationState.MovieCardDisplayed);
        }

        public int SelectedActor { get; private set; }

        public int SelectedMovie { get; private set; }
    }
}
