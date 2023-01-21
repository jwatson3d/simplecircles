// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ChannelAddress.cs" company="John Watson">
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

namespace Circles.Domain
{
    using System;

    /// <summary>
    /// Represents a communication channel (email, phone, instant messenger) address.
    /// </summary>
    public class ChannelAddress : Entity
    {
        /// <summary>
        /// Initializes a new instance of the ChannelAddress class.
        /// </summary>
        public ChannelAddress()
        {
        }

        /// <summary>
        /// Initializes a new instance of the ChannelAddress class.
        /// </summary>
        /// <param name="id">A <see cref="System.Guid"/> that 
        /// represents the primary identifier value for the class. </param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors", 
            Justification = "Necessary to ensure every instance is always uniquely identified.")]
        protected ChannelAddress(Guid id)
            : base(id)
        {
        }

        /// <summary>
        /// Gets or sets the unique identifier of the ChannelAddress instance.
        /// </summary>
        public Guid AddressId
        {
            get { return Id; }
            set { Id = value; }
        }

        /// <summary>
        /// Gets or sets type of address this instance is.
        /// </summary>
        public virtual string AddressType { get; set; }

        /// <summary>
        /// Gets or sets the effective from date of the PostalAddress instance.
        /// </summary>
        public virtual DateTime EffectiveFromDate { get; set; }

        /// <summary>
        /// Gets or sets the effective to date of the PostalAddress instance.
        /// </summary>
        public virtual DateTime EffectiveToDate { get; set; }

        /// <summary>
        /// Gets or sets address line 1 of the PostalAddress instance.
        /// </summary>
        public virtual string Address { get; set; }

        /// <summary>
        /// Gets or sets the Party instance this PostalAddress is part of.
        /// </summary>
        public virtual Party Party { get; set; }
    }
}
