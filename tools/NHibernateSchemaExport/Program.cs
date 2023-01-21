// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="John Watson">
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

namespace NHibernateSchemaExport
{
    using Circles.NHibernateRepository;

    using FluentNHibernate.Cfg;
    using FluentNHibernate.Cfg.Db;

    // using NHibernate.Cache;
    using NHibernate.Cfg;
    using NHibernate.Tool.hbm2ddl;

    class Program
    {
        static void Main(string[] args)
        {
            Fluently.Configure()
                .Database(MsSqlCeConfiguration.Standard
                    .ConnectionString(c => c.FromConnectionStringWithKey("circlesce"))
                // .Database(SQLiteConfiguration.Standard
                //    .ConnectionString(c => c.FromConnectionStringWithKey("circlesdb"))
                    .ShowSql)
                // .Cache(c => c.UseQueryCache().ProviderClass<HashtableCacheProvider>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<PartyRepository>()
                    .ExportTo("."))
                .ExposeConfiguration(BuildSchema)
                .BuildSessionFactory();
        }

        static void BuildSchema(Configuration cfg)
        {
            new SchemaExport(cfg)
              .SetOutputFile("CirclesSchema_SQLCE.sql")
              // .SetOutputFile("CirclesSchema_SQLite.sql")
              .Execute(script: true, export: false, justDrop: false);
        }
    }
}
