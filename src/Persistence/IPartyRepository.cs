// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPartyRepository.cs" company="John Watson">
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

namespace Circles.Persistence
{
    using System;
    using System.Linq;

    using Circles.Domain;

    /// <summary>
    /// Defines the PartyRepository contract that implementors must support.
    /// </summary>
    public interface IPartyRepository : IRepository<Party, Guid>, ISupportSave<Party, Guid>, ISupportDelete<Party, Guid>
    {
        /// <summary>
        /// Finds all household instances.
        /// </summary>
        /// <returns>All household instances or null.</returns>
        IQueryable<Household> FindAllHouseholds();

        /// <summary>
        /// Finds all organization instances.
        /// </summary>
        /// <returns>All organization instances or null.</returns>
        IQueryable<Organization> FindAllOrganizations();

        /// <summary>
        /// Finds all persons.
        /// </summary>
        /// <returns>All person instances or null.</returns>
        IQueryable<Person> FindAllPersons();
    }
}
