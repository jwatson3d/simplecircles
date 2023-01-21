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

namespace Circles.Maps
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    using AutoMapper;

    using Circles.Domain;

    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented",
        Justification = "Reviewed. Suppression is OK here.")]
    public class PersonMap
    {
        public static void CreateMaps()
        {
            Mapper.CreateMap<Domain.Person, Models.Person>()
                .ForMember(dest => dest.Birthday, opt => opt.MapFrom(src => src.Birthday))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender.ToString()))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.MiddleName, opt => opt.MapFrom(src => src.MiddleName ?? null))
                .ForMember(dest => dest.PersonId, opt => opt.MapFrom(src => src.PartyId))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.PartyName))
                .ForMember(dest => dest.Salutation, opt => opt.MapFrom(src => src.Salutation ?? null))
                .ForMember(dest => dest.Suffix, opt => opt.MapFrom(src => src.Suffix ?? null));

            Mapper.CreateMap<Models.Person, Domain.Person>()
                .ForMember(dest => dest.ChannelAddresses, opt => opt.Ignore())
                .ForMember(dest => dest.Birthday, opt => opt.MapFrom(src => src.Birthday))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => (GenderEnum)Enum.Parse(typeof(GenderEnum), src.Gender)))
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.MiddleName, opt => opt.MapFrom(src => src.MiddleName ?? null))
                .ForMember(dest => dest.Notes, opt => opt.Ignore())
                .ForMember(dest => dest.PartyId, opt => opt.MapFrom(src => src.PersonId))
                .ForMember(dest => dest.PartyName, opt => opt.Ignore())
                .ForMember(dest => dest.PartyType, opt => opt.Ignore())
                .ForMember(dest => dest.PostalAddresses, opt => opt.Ignore())
                .ForMember(dest => dest.Salutation, opt => opt.MapFrom(src => src.Salutation ?? null))
                .ForMember(dest => dest.Suffix, opt => opt.MapFrom(src => src.Suffix ?? null));

            // configuration validation normally handled in unit tests...
            // Mapper.AssertConfigurationIsValid();
        }
    }
}