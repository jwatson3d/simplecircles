// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PartyType.cs" company="John Watson">
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
    /// Represents a custom-defined party classification.
    /// </summary>
    public class PartyType : Entity
    {
        /// <summary>
        /// Initializes a new instance of the PartyType class.
        /// </summary>
        public PartyType()
        {
        }

        /// <summary>
        /// Initializes a new instance of the PartyType class.
        /// </summary>
        /// <param name="id">A <see cref="System.Guid"/> that 
        /// represents the primary identifier value for the class. </param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors", 
            Justification = "Necessary to ensure every instance is always uniquely identified.")]
        protected PartyType(Guid id)
            : base(id)
        {
        }

        /// <summary>
        /// Gets or sets the unique identifier of the PartyType instance.
        /// </summary>
        public virtual Guid TypeId
        {
            get { return Id; }
            set { Id = value; }
        }

        /// <summary>
        /// Gets or sets the name of the PartyType instance.
        /// </summary>
        public virtual string TypeName { get; set; }
    }
}
