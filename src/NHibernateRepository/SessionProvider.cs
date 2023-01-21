// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SessionProvider.cs" company="John Watson">
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
    using NHibernate;
    using NHibernate.Cfg;

    /// <summary>
    /// Constructs and caches an NHibernate ISessionFactory,
    /// configured for the underlying provider.
    /// </summary>
    public class SessionProvider
    {
        /// <summary>
        /// The configuration.
        /// </summary>
        private static Configuration configuration;

        /// <summary>
        /// The session factory.
        /// </summary>
        private static ISessionFactory sessionFactory;

        /// <summary>
        /// Prevents a default instance of the SessionProvider class from being created.
        /// </summary>
        private SessionProvider()
        {
        }

        /// <summary>
        /// Gets the Configuration.
        /// </summary>
        public static Configuration Configuration
        {
            get
            {
                if (configuration == null)
                {
                    configuration = new Configuration();
                    configuration.Configure();
                    configuration.AddAssembly(typeof(PartyRepository).Assembly);
                }

                return configuration;
            }
        }

        /// <summary>
        /// Gets the ISessionFactory
        /// </summary>
        public static ISessionFactory SessionFactory
        {
            get { return sessionFactory ?? (sessionFactory = Configuration.BuildSessionFactory()); }
        }

        /// <summary>
        /// Gets the ISession
        /// </summary>
        /// <returns>The opened ISession.</returns>
        public static ISession GetSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}
