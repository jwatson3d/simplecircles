// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PartyMap.cs" company="John Watson">
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
    /// Defines the mapping of <see cref="Party"/> to the database model
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented",
        Justification = "Reviewed. Suppression is OK here.")]
    public class PartyMap : ClassMap<Party>
    {
        public PartyMap()
        {
            Id(x => x.PartyId).GeneratedBy.GuidComb();
            Version(x => x.Version);
            References(x => x.PartyType, "TypeId").Not.Nullable().ForeignKey("fk_Party_PartyType");
            Map(x => x.PartyName).Not.Nullable().Length(255).Unique().Index("ukPartyName");
        }
    }
}
