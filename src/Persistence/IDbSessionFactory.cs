// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDbSessionFactory.cs" company="John Watson">
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
    /// <summary>
    /// Represents an immutable factory for creating <see cref="IDbSession"/> instances.
    /// </summary>
    /// <remarks>
    /// An <c>IDbSessionFactory</c> implementation is 'heavy-weight' and normally needs
    /// to be created once and reused for the lifetime of the application.
    /// </remarks>
    public interface IDbSessionFactory
    {
        /// <summary>
        /// Create an <see cref="IDbSession"/> instance.
        /// </summary>
        /// <param name="withTransaction"><c>True</c> if transaction needs to be started.</param>
        /// <returns>An <see cref="IDbSession"/> initialized and ready for use.</returns>
        IDbSession Create(bool withTransaction);
    }
}
