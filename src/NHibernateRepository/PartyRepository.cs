// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PartyRepository.cs" company="John Watson">
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

namespace Circles.NHibernateRepository
{
    using System;
    using System.Linq;

    using Circles.Domain;
    using Circles.Persistence;

    using NHibernate;

    /// <summary>
    /// Concrete implementation of the IPersonRespository using NHibernate.
    /// </summary>
    public class PartyRepository : IPartyRepository
    {
        /// <summary>
        /// The session factory.
        /// </summary>
        private readonly ISession session;

        /// <summary>
        /// Initializes a new instance of the <see cref="PartyRepository"/> class.
        /// </summary>
        /// <param name="session">The current session.</param>
        public PartyRepository(ISession session)
        {
            this.session = session;
        }

        /// <summary>
        /// Prevents a default instance of the <see cref="PartyRepository"/> class from being created.
        /// </summary>
        private PartyRepository()
        {
        }

        #region IRepository<Party, Guid> Members

        /// <summary>
        /// Indexer allowing repository to be accessed like a
        /// collection or array using [] notation.
        /// </summary>
        /// <param name="id">Unique identifier for a party.</param>
        /// <returns>The requested party instance or null.</returns>
        public Party this[Guid id]
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Finds all parties.
        /// </summary>
        /// <returns>All party instances or null.</returns>
        public IQueryable<Party> FindAll()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Finds a party using given key.
        /// </summary>
        /// <param name="id">Unique identifier for a party.</param>
        /// <returns>The requested party instance or null.</returns>
        public Party FindById(Guid id)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region ISupportSave<Party, Guid> Members

        /// <summary>
        /// Adds the given <see cref="Party"/> instance to the repository.
        /// </summary>
        /// <param name="entity">The party instance to add.</param>
        /// <returns>The assigned unique identifier for this newly added instance.</returns>
        public Guid Add(Party entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates the given party instance in the repository.
        /// </summary>
        /// <param name="entity">The party instance to update, 
        /// uniquely identified by its Key value.</param>
        public void Update(Party entity)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region ISupportDelete<Party, Guid> Members

        /// <summary>
        /// Deletes a party instance from the repository.
        /// </summary>
        /// <param name="id">Unique identifier for a person.</param>
        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IPartyRepository Members

        /// <summary>
        /// Finds all households.
        /// </summary>
        /// <returns>All household instances or null.</returns>
        public IQueryable<Household> FindAllHouseholds()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Finds all organizations.
        /// </summary>
        /// <returns>All organization instances or null.</returns>
        public IQueryable<Organization> FindAllOrganizations()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Finds all persons.
        /// </summary>
        /// <returns>All person instances or null.</returns>
        public IQueryable<Person> FindAllPersons()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
