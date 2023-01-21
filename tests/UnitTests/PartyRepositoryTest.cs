// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PartyRepositoryTest.cs" company="John Watson">
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

namespace Circles.UnitTests
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    using Circles.Domain;
    using Circles.FakeRepository;
    using Circles.Persistence;

    using Xunit;
    using Xunit.Extensions;

    /// <summary>
    /// Provides unit tests for the PartyRepository
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented",
        Justification = "Reviewed. Suppression is OK here.")]
    public class PartyRepositoryTest
    {
        [Fact]
        public void CanAddHousehold()
        {
            // arrange
            IPartyRepository repository = new FakePartyRepository();

            // act
            var id = repository.Add(new Household
                {
                    PartyName = "Eisenhower", 
                    FormalGreeting = "President Dwight D. and Mrs. Mamie", 
                    InformalGreeting = "Ike and Mamie"
                });

            // assert
            Assert.NotNull(id);
            Assert.NotNull(repository.FindById(id));
        }

        [Fact]
        public void CanAddOrganization()
        {
            // arrange
            IPartyRepository repository = new FakePartyRepository();

            // act
            var id = repository.Add(new Organization { PartyName = "Let's Stop N Shop" });

            // assert
            Assert.NotNull(id);
            Assert.NotNull(repository.FindById(id));
        }

        [Fact]
        public void CanAddPerson()
        {
            // arrange
            IPartyRepository repository = new FakePartyRepository();

            // act
            var id = repository.Add(new Person
                {
                    FirstName = "Henry", 
                    MiddleName = "Lewis", 
                    LastName = "Stimson ", 
                    Gender = GenderEnum.Male, 
                    Birthday = new DateTime(1867, 9, 21)
                });

            // assert
            Assert.NotNull(id);
            Assert.NotNull(repository.FindById(id));
        }

        [Theory,
        InlineData(Constants.HouseholdIdRoosevelt)]
        public void CanDeleteHousehold(string id)
        {
            // arrange
            IPartyRepository repository = new FakePartyRepository();
            var partyId = new Guid(id);

            // act
            repository.Delete(partyId);

            // assert
            Assert.Null(repository.FindById(partyId));
        }

        [Theory,
        InlineData(Constants.OrgIdLazyK)]
        public void CanDeleteOrganization(string id)
        {
            // arrange
            IPartyRepository repository = new FakePartyRepository();
            var partyId = new Guid(id);

            // act
            repository.Delete(partyId);

            // assert
            Assert.Null(repository.FindById(partyId));
        }

        [Theory,
        InlineData(Constants.PersonIdDavolio)]
        public void CanDeletePerson(string id)
        {
            // arrange
            IPartyRepository repository = new FakePartyRepository();
            var partyId = new Guid(id);

            // act
            repository.Delete(partyId);

            // assert
            Assert.Null(repository.FindById(partyId));
        }

        [Fact]
        public void CanFindAllParties()
        {
            // arrange
            IPartyRepository repository = new FakePartyRepository();

            // act
            var parties = repository.FindAll();

            // assert
            Assert.NotNull(parties);
            Assert.True(parties.Any());
        }

        [Fact]
        public void CanFindAllHouseholds()
        {
            // arrange
            IPartyRepository repository = new FakePartyRepository();

            // act
            var households = repository.FindAllHouseholds();

            // assert
            Assert.NotNull(households);
            Assert.True(households.Any());
        }

        [Fact]
        public void CanFindAllPersons()
        {
            // arrange
            IPartyRepository repository = new FakePartyRepository();

            // act
            var persons = repository.FindAllPersons();

            // assert
            Assert.NotNull(persons);
            Assert.True(persons.Any());
        }

        [Theory,
        InlineData(Constants.HouseholdIdChurchill)]
        public void CanFindSingleHousehold(string id)
        {
            // arrange
            IPartyRepository repository = new FakePartyRepository();
            var partyId = new Guid(id);

            // act
            var household = repository.FindById(partyId) as Household;

            // assert
            Assert.NotNull(household);
            Assert.True(household.Id == partyId);
        }

        [Theory,
        InlineData(Constants.OrgIdGreatLakes)]
        public void CanFindSingleOrganization(string id)
        {
            // arrange
            IPartyRepository repository = new FakePartyRepository();
            var partyId = new Guid(id);

            // act
            var organization = repository.FindById(partyId) as Organization;

            // assert
            Assert.NotNull(organization);
            Assert.True(organization.Id == partyId);
        }

        [Theory,
        InlineData(Constants.PersonIdDavolio)]
        public void CanFindSinglePerson(string id)
        {
            // arrange
            IPartyRepository repository = new FakePartyRepository();
            var partyId = new Guid(id);

            // act
            var person = repository.FindById(partyId) as Person;

            // assert
            Assert.NotNull(person);
            Assert.True(person.Id == partyId);
        }

        [Theory,
        InlineData(Constants.HouseholdIdRoosevelt)]
        public void CanUpdateHousehold(string id)
        {
            // arrange
            IPartyRepository repository = new FakePartyRepository();
            var partyId = new Guid(id);

            // act
            var household = repository.FindById(partyId) as Household;
            Assert.NotNull(household);
            household.InformalGreeting = "Franklin and Eleanor";
            repository.Update(household);

            // assert
            var household2 = repository.FindById(household.PartyId) as Household;
            Assert.NotNull(household2);
            Assert.True(household.InformalGreeting == household2.InformalGreeting);
            Assert.True(household == household2);
        }

        [Theory,
        InlineData(Constants.OrgIdGreatLakes)]
        public void CanUpdateOrganization(string id)
        {
            // arrange
            IPartyRepository repository = new FakePartyRepository();
            var partyId = new Guid(id);

            // act
            var organization = repository.FindById(partyId) as Organization;
            Assert.NotNull(organization);
            organization.TaxIdentifier = "10-1234567";
            repository.Update(organization);

            // assert
            var organization2 = repository.FindById(organization.PartyId) as Organization;
            Assert.NotNull(organization2);
            Assert.True(organization.TaxIdentifier == organization2.TaxIdentifier);
            Assert.True(organization == organization2);
        }

        [Theory,
        InlineData(Constants.PersonIdFuller)]
        public void CanUpdatePerson(string id)
        {
            // arrange
            IPartyRepository repository = new FakePartyRepository();
            var partyId = new Guid(id);

            // act
            var person = repository.FindById(partyId) as Person;
            Assert.NotNull(person);
            person.MiddleName = "J.";
            person.Birthday = new DateTime(1992, 2, 29);
            repository.Update(person);

            // assert
            var person2 = repository.FindById(person.PartyId) as Person;
            Assert.NotNull(person2);
            Assert.True(person.MiddleName == person2.MiddleName);
            Assert.True(person.Birthday == person2.Birthday);
            Assert.True(person == person2);
        }
    }
}
