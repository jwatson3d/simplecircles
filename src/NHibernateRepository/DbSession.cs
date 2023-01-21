// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DbSession.cs" company="John Watson">
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
    using System.Data;

    using Circles.Persistence;

    using NHibernate;

    /// <summary>
    /// Concrete implementation of a database session.
    /// </summary>
    /// <remarks>
    /// Inspired by work of Bob Cravens as shown in
    /// https://github.com/rcravens/GenericRepository
    /// </remarks>
    public class DbSession : IDbSession
    {
        private readonly ISession session;
        private ITransaction transaction;

        /// <summary>
        /// Initializes a new instance of the <see cref="DbSession"/> class.
        /// </summary>
        /// <param name="sessionFactory">The session factory.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="sessionFactory"/> is missing.</exception>
        public DbSession(ISessionFactory sessionFactory)
        {
            Guard.NotNull(() => sessionFactory, sessionFactory);

            this.session = sessionFactory.OpenSession();
            this.session.FlushMode = FlushMode.Auto;
        }

        ~DbSession()
        {
            this.Dispose();
        }

        #region Implementation of IDisposable

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <filterpriority>2</filterpriority>
        public void Dispose()
        {
            if (this.session == null)
            {
                return;
            }

            lock (this.session)
            {
                if (this.session.IsOpen)
                {
                    this.session.Close();
                }
            }

            GC.SuppressFinalize(this);
        }

        #endregion

        #region Implementation of IDbSession

        /// <summary>
        /// Used to obtain a concrete <see cref="IPartyRepository"/> implementation.
        /// </summary>
        /// <returns>A concrete PartyRepository suitable for use.</returns>
        public IPartyRepository CreatePartyRepository()
        {
            return new PartyRepository(this.session);
        }

        /// <summary>
        /// Initiates a database transaction
        /// </summary>
        /// <param name="isolationLevel">Specifies the transaction locking behavior for the connection.</param>
        public void BeginTransaction(IsolationLevel isolationLevel)
        {
            this.transaction = this.session.BeginTransaction(isolationLevel);
        }

        /// <summary>
        /// Commit pending (unsaved) changes to the database.
        /// </summary>
        public void Commit()
        {
            if (this.transaction == null)
            {
                return;
            }

            if (!this.transaction.IsActive)
            {
                throw new InvalidOperationException("No active transation");
            }

            this.transaction.Commit();
        }

        /// <summary>
        /// Rollback pending (unsaved) changes to the database.
        /// </summary>
        public void Rollback()
        {
            if (this.transaction == null)
            {
                return;
            }

            if (this.transaction.IsActive)
            {
                this.transaction.Rollback();
            }
        }

        #endregion
    }
}
