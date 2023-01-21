// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FakePartyRepository.cs" company="John Watson">
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

namespace Circles.FakeRepository
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    using Circles.Domain;
    using Circles.Persistence;

    /// <summary>
    /// Fake implementation for testing purposes.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented",
        Justification = "Reviewed. Suppression is OK here.")]
    public class FakePartyRepository : IPartyRepository
    {
        private readonly List<Household> fakeHouseholdList = new List<Household> 
        {
            new Household { PartyId = new Guid("CF5A8CB8-2D3F-4DD2-8DCD-41A85FE49943"), PartyName = "Churchill", FormalGreeting = "Sir Winston and Lady Clementine" },
            new Household { PartyId = new Guid("710EF937-6AA4-4FE1-A120-1F0B6AB7B546"), PartyName = "Roosevelt", FormalGreeting = "President Franklin and Mrs. Eleanor" },
        };

        private readonly List<Organization> fakeOrganizationList = new List<Organization> 
        {
            new Organization { PartyId = new Guid("53173673-FDA4-4DD2-9FF2-801332842E4B"), PartyName = "Great Lakes Food Market" },
            new Organization { PartyId = new Guid("CE607E3C-CBED-4A6C-BA69-F73503A2088B"),  PartyName = "Hungry Coyote Import Store" },
            new Organization { PartyId = new Guid("24CE6D89-9C4A-4CCF-A8A4-585EED9FF594"), PartyName = "Lazy K Kountry Store" },
        };

        private readonly List<Person> fakePersonList = new List<Person> 
        {
            new Person { PartyId = new Guid("D28AA45E-C650-4121-8070-3D12BE31F91A"), FirstName = "Nancy", LastName = "Davolio", Gender = GenderEnum.Female, Birthday = new DateTime(1948, 12, 8) },
            new Person { PartyId = new Guid("212F31D7-4EBF-4D82-B64D-ED20F3699234"), FirstName = "Andrew", LastName = "Fuller", Gender = GenderEnum.Male, Birthday = new DateTime(1992, 8, 14) },
            new Person { FirstName = "Janet", LastName = "Leverling", Gender = GenderEnum.Female, Birthday = new DateTime(1963, 8, 30) },
            new Person { FirstName = "Margaret", LastName = "Peacock", Gender = GenderEnum.Female, Birthday = new DateTime(1937, 9, 19) },
            new Person { FirstName = "Steven", LastName = "Buchanan", Gender = GenderEnum.Male, Birthday = new DateTime(1955, 3, 4) },
            new Person { FirstName = "Michael", LastName = "Suyama", Gender = GenderEnum.Male, Birthday = new DateTime(1963, 7, 2) },
            new Person { FirstName = "Robert", LastName = "King", Gender = GenderEnum.Male, Birthday = new DateTime(1960, 5, 29) },
            new Person { FirstName = "Laura", LastName = "Callahan", Gender = GenderEnum.Female, Birthday = new DateTime(1958, 1, 9) },
            new Person { FirstName = "Anne", LastName = "Dodsworth", Gender = GenderEnum.Female, Birthday = new DateTime(1966, 1, 27) },
        };

        private readonly IQueryable<Household> fakeHouseholdRepository;
        private readonly IQueryable<Organization> fakeOrganizationRepository;
        private readonly IQueryable<Person> fakePersonRepository;
        private readonly IQueryable<Party> fakePartyRepository;

        public FakePartyRepository()
        {
            this.fakeHouseholdRepository = this.fakeHouseholdList.AsQueryable();
            this.fakeOrganizationRepository = this.fakeOrganizationList.AsQueryable();
            this.fakePersonRepository = this.fakePersonList.AsQueryable();
            this.fakePartyRepository = this.fakeOrganizationList.Union<Party>(this.fakePersonList).Union(this.fakeHouseholdList).AsQueryable();
        }

        #region IRepository<Party> Members

        public Party this[Guid id]
        {
            get
            {
                return this.FindById(id);
            }

            set
            {
                if (this.FindById(id) == null)
                {
                    this.Add(value);
                }
                else
                {
                    this.Update(value);
                }
            }
        }

        public IQueryable<Party> FindAll()
        {
            return this.fakePartyRepository;
        }

        public Party FindById(Guid id)
        {
            return this.fakePartyRepository.FirstOrDefault(x => x.PartyId == id);
        }

        #endregion

        #region ISupportSave<Party> Members

        public Guid Add(Party entity)
        {
            var type = entity.GetType();
            if (type == typeof(Person))
            {
                this.fakePersonList.Add(entity as Person);
                return entity.Id;
            }

            if (type == typeof(Household))
            {
                this.fakeHouseholdList.Add(entity as Household);
                return entity.Id;
            }

            if (type == typeof(Organization))
            {
                this.fakeOrganizationList.Add(entity as Organization);
                return entity.Id;
            }

            return Guid.Empty;
        }

        public void Update(Party entity)
        {
            var parties = this.fakePartyRepository.ToList();
            var idx = parties.FindIndex(x => x.Id == entity.Id);

            if (idx < 0)
            {
                parties.Add(entity);
            }
            else
            {
                parties[idx] = entity;
            }
        }

        #endregion

        #region ISupportDelete<Party> Members

        public void Delete(Guid id)
        {
            var party = this.FindById(id);
            if (party == null)
            {
                return;
            }

            var type = party.GetType();
            if (type == typeof(Person))
            {
                this.fakePersonList.Remove(party as Person);
            }
            else if (type == typeof(Household))
            {
                this.fakeHouseholdList.Remove(party as Household);
            }
            else if (type == typeof(Organization))
            {
                this.fakeOrganizationList.Remove(party as Organization);
            }
        }

        #endregion

        #region IPartyRepository Members

        /// <summary>
        /// Finds all household instances.
        /// </summary>
        /// <returns>All household instances or null.</returns>
        public IQueryable<Household> FindAllHouseholds()
        {
            return this.fakeHouseholdRepository;
        }

        /// <summary>
        /// Finds all organization instances.
        /// </summary>
        /// <returns>All organization instances or null.</returns>
        public IQueryable<Organization> FindAllOrganizations()
        {
            return this.fakeOrganizationRepository;
        }

        /// <summary>
        /// Finds all person instances.
        /// </summary>
        /// <returns>All person instances or null.</returns>
        public IQueryable<Person> FindAllPersons()
        {
            return this.fakePersonRepository;
        }

        #endregion
    }
}
