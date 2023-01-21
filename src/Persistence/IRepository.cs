// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRepository.cs" company="John Watson">
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
    /// Basic repository interface designed to mediate between the
    /// domain model and the persistent storage layer. Provides
    /// minimal retrieve methods only.
    /// </summary>
    /// <remarks>
    /// Described by Martin Fowler in PoEAA, 322.
    /// Note that we prefer a smaller, simpler common interface
    /// here with specific repositories describing more advanced
    /// FindByXXXX methods as well as others as needed.
    /// </remarks>
    /// <typeparam name="T">A type derived from Entity</typeparam>
    /// <typeparam name="TId">The type of the unique identity for the Entity</typeparam>
    public interface IRepository<T, in TId> where T : Entity
    {
        /// <summary>
        /// Indexer allowing repository to be accessed like a
        /// collection or array using [] notation.
        /// </summary>
        /// <param name="id">Unique identifier for an entity.</param>
        /// <returns>The requested entity instance or null.</returns>
        T this[TId id] { get; set; }

        /// <summary>
        /// Finds all entities.
        /// </summary>
        /// <returns>All entity instances or null.</returns>
        IQueryable<T> FindAll();

        /// <summary>
        /// Finds an entity using given id.
        /// </summary>
        /// <typeparam name="TId">The <see cref="Type"/> used to define the Entity's unique id.</typeparam>
        /// <param name="id">Unique identifier for an entity.</param>
        /// <returns>The requested entity instance or null.</returns>
        T FindById(TId id);
    }
}
