// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Entity.cs" company="John Watson">
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
    /// Represents a generic, persistable entity.
    /// </summary>
    public abstract class Entity : EntityBase<Guid>
    {
        /// <summary>
        /// Initializes a new instance of the Entity class.
        /// </summary>
        protected Entity()
            : this(Guid.Empty)
        {
        }

        /// <summary>
        /// Initializes a new instance of the Entity class.
        /// </summary>
        /// <param name="id">An <see cref="System.Guid"/> that 
        /// represents the primary identifier value for the class. </param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", 
            "CA2214:DoNotCallOverridableMethodsInConstructors", 
            Justification = "Necessary to ensure every instance is always uniquely identified.")]
        protected Entity(Guid id)
            : base(id)
        {
            this.Id = (Guid)(id == Guid.Empty ? this.NewId() : id);
        }

        /// <summary>
        /// Gets or sets Version.
        /// </summary>
        public virtual int Version { get; set; }

        /// <summary>
        /// Generates a new globally unique instance id
        /// </summary>
        /// <returns>
        /// A new <see cref="Guid"/>.
        /// </returns>
        public override object NewId()
        {
            return Guid.NewGuid();
        }
    }
}
