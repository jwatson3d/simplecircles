// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ISupportSave.cs" company="John Watson">
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
    using Circles.Domain;

    /// <summary>
    /// A "role" interface that allows repositories to be
    /// marked as supporting additions and updates (i.e.
    /// not read-only).
    /// </summary>
    /// <typeparam name="T">A type derived from Entity</typeparam>
    /// <typeparam name="TId">The type of the unique identity for the Entity</typeparam>
    public interface ISupportSave<in T, out TId> where T : Entity
    {
        /// <summary>
        /// Adds the given entity instance to the repository.
        /// </summary>
        /// <param name="entity">The entity instance to add.</param>
        /// <returns>The unique identifier for the newly added entity instance.</returns>
        TId Add(T entity);

        /// <summary>
        /// Updates the given entity instance in the repository.
        /// </summary>
        /// <param name="entity">The entity instance to update, 
        /// uniquely identified by its Key value.</param>
        void Update(T entity);
    }
}
