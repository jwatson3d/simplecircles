// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PeopleControllerTest.cs" company="John Watson">
// Copyright 2012 John Watson, New Hampshire, USA
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Circles.UnitTests.ControllerTests
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Web.Mvc;

    using Circles.Controllers;
    using Circles.Domain;
    using Circles.UnitTests;

    using Xunit;
    using Xunit.Extensions;

    using Person = Circles.Models.Person;

    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented",
        Justification = "Reviewed. Suppression is OK here.")]
    public class PeopleControllerTest : IUseFixture<DataMapperFixture>
    {
        public void SetFixture(DataMapperFixture data)
        {
            data.CreateMaps();
        }

        [Fact]
        public void CreateGetReturnsCreateView()
        {
            // arrange
            const string ExpectedViewName = "Create";
            var peopleController = new PeopleController(new FakeRepository.FakePartyRepository());

            // act
            var viewResult = (ViewResult)peopleController.Create();

            // assert
            Assert.NotNull(viewResult);
            Assert.Equal(ExpectedViewName, viewResult.ViewName);
        }

        [Fact]
        public void CreatePostReturnsViewIfModelStateIsInvalid()
        {
            // arrange
            const string ExpectedViewName = "Create";
            var peopleController = new PeopleController(new FakeRepository.FakePartyRepository());
            peopleController.ModelState.AddModelError("LastName", "LastName is required.");
            var person = new Person
                {
                    FirstName = "Henry",
                    MiddleName = "Lewis",
                    // LastName = "Stimson ",
                    Gender = Enum.GetName(typeof(GenderEnum), GenderEnum.Male),
                    Birthday = new DateTime(1867, 9, 21)
                };

            // act
            var viewResult = peopleController.Create(person) as ViewResult;

            // assert
            Assert.NotNull(viewResult);
            Assert.Equal(ExpectedViewName, viewResult.ViewName);
        }

        [Fact]
        public void CreatePostRoutesToIndexIfModelIsValid()
        {
            // arrange
            const string ExpectedRoute = "Index";
            var peopleController = new PeopleController(new FakeRepository.FakePartyRepository());
            var person = new Person
                {
                    FirstName = "Henry",
                    MiddleName = "Lewis",
                    LastName = "Stimson ",
                    Gender = Enum.GetName(typeof(GenderEnum), GenderEnum.Male),
                    Birthday = new DateTime(1867, 9, 21)
                };

            // act
            var routeResult = peopleController.Create(person) as RedirectToRouteResult;

            // assert
            Assert.NotNull(routeResult);
            Assert.Equal(ExpectedRoute, routeResult.RouteValues["action"]);
        }

        [Fact]
        public void DefaultGetReturnsIndexView()
        {
            // arrange
            const string ExpectedViewName = "Index";
            var peopleController = new PeopleController(new FakeRepository.FakePartyRepository());

            // act
            var viewResult = peopleController.Index();

            // assert
            Assert.NotNull(viewResult);
            Assert.Equal(ExpectedViewName, viewResult.ViewName);
            var model = viewResult.ViewData.Model as IEnumerable<Person>;
            Assert.NotNull(model);
        }

        [Theory,
        InlineData(Constants.PersonIdDavolio)]
        public void DeleteConfirmedPostRoutesToIndex(string id)
        {
            // arrange
            const string ExpectedRoute = "Index";
            var peopleController = new PeopleController(new FakeRepository.FakePartyRepository());

            // act
            var routeResult = peopleController.DeleteConfirmed(new Guid(id)) as RedirectToRouteResult;

            // assert
            Assert.NotNull(routeResult);
            Assert.Equal(ExpectedRoute, routeResult.RouteValues["action"]);
        }

        [Theory,
        InlineData(Constants.PersonIdDavolio)]
        public void DeleteGetReturnsCreateView(string id)
        {
            // arrange
            const string ExpectedViewName = "Delete";
            var peopleController = new PeopleController(new FakeRepository.FakePartyRepository());

            // act
            var viewResult = (ViewResult)peopleController.Delete(new Guid(id));

            // assert
            Assert.NotNull(viewResult);
            Assert.Equal(ExpectedViewName, viewResult.ViewName);
        }

        [Fact]
        public void EditPostReturnsViewIfModelStateIsInvalid()
        {
            // arrange
            const string ExpectedViewName = "Edit";
            var peopleController = new PeopleController(new FakeRepository.FakePartyRepository());
            peopleController.ModelState.AddModelError("LastName", "LastName is required.");
            var person = new Person
            {
                FirstName = "Henry",
                MiddleName = "Lewis",
                // LastName = "Stimson ",
                Gender = Enum.GetName(typeof(GenderEnum), GenderEnum.Male),
                Birthday = new DateTime(1867, 9, 21)
            };

            // act
            var viewResult = peopleController.Edit(person) as ViewResult;

            // assert
            Assert.NotNull(viewResult);
            Assert.Equal(ExpectedViewName, viewResult.ViewName);
        }

        [Fact]
        public void EditPostRoutesToIndexIfModelIsValid()
        {
            // arrange
            const string ExpectedRoute = "Index";
            var peopleController = new PeopleController(new FakeRepository.FakePartyRepository());
            var person = new Person
            {
                FirstName = "Henry",
                MiddleName = "Lewis",
                LastName = "Stimson ",
                Gender = Enum.GetName(typeof(GenderEnum), GenderEnum.Male),
                Birthday = new DateTime(1867, 9, 21)
            };

            // act
            var routeResult = peopleController.Edit(person) as RedirectToRouteResult;

            // assert
            Assert.NotNull(routeResult);
            Assert.Equal(ExpectedRoute, routeResult.RouteValues["action"]);
        }
    }
}
