// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PersonMap.cs" company="John Watson">
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

namespace Circles.NHibernateRepository.Maps
{
    using System.Diagnostics.CodeAnalysis;

    using Circles.Domain;

    using FluentNHibernate.Mapping;

    /// <summary>
    /// Defines the mapping of <see cref="Person"/> to the database model
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented",
        Justification = "Reviewed. Suppression is OK here.")]
    public class PersonMap : SubclassMap<Person>
    {
        public PersonMap()
        {
            KeyColumn("PartyId");
            Map(x => x.FirstName).Not.Nullable().Length(50);
            Map(x => x.MiddleName).Length(50);
            Map(x => x.LastName).Not.Nullable().Length(50);
            Map(x => x.Salutation).Length(20);
            Map(x => x.Suffix).Length(10);
            Map(x => x.Gender).Not.Nullable().Length(10);
            Map(x => x.Birthday);
        }
    }
}
