// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDbSession.cs" company="John Watson">
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
    using System.Data;

    /// <summary>
    /// Generic database session
    /// </summary>
    /// <remarks>
    /// Inspired by work of Bob Cravens as shown in
    /// https://github.com/rcravens/GenericRepository
    /// </remarks>
    public interface IDbSession : IDisposable
    {
        #region Transactional semantics

        /// <summary>
        /// Initiates a database transaction
        /// </summary>
        /// <param name="isolationLevel">Specifies the transaction locking behavior for the connection.</param>
        void BeginTransaction(IsolationLevel isolationLevel);

        /// <summary>
        /// Commit pending (unsaved) changes to the database.
        /// </summary>
        void Commit();

        /// <summary>
        /// Rollback pending (unsaved) changes to the database.
        /// </summary>
        void Rollback();

        #endregion

        /// <summary>
        /// Used to obtain a concrete <see cref="IPartyRepository"/> implementation.
        /// </summary>
        /// <returns>
        /// A concrete PartyRepository suitable for use.
        /// </returns>
        IPartyRepository CreatePartyRepository();
    }
}
