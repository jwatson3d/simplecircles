// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EntityBase.cs" company="John Watson">
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
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    /// <summary>
    /// Abstract base class for all entities in a domain model.
    /// </summary>
    /// <typeparam name="TId">
    /// Represents the <see cref="Type"/> of the unique id for this entity.
    /// </typeparam>
    /// <remarks>
    /// Inspiration for this base Entity class comes from
    /// Jason Dentler's NHibernate 3.0 Cookbook, pp. 24-27
    /// </remarks>
    public abstract class EntityBase<TId>
    {
        /// <summary>
        /// Unique identifier for an Entity instance
        /// </summary>
        private TId id;

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the EntityBase class.
        /// </summary>
        protected EntityBase() 
        {
        }

        /// <summary>
        /// Initializes a new instance of the EntityBase class.
        /// </summary>
        /// <param name="id">An <see cref="System.Object"/> that 
        /// represents the primary identifier value for the class.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", 
            "CA2214:DoNotCallOverridableMethodsInConstructors", 
            Justification = "Necessary to ensure every instance is always uniquely identified.")]
        protected EntityBase(TId id)
        {
            this.id = id;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the unique identifier of the Entity instance.
        /// </summary>
        public virtual TId Id
        {
            get
            {
                return this.id;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value", "The id property cannot be set to null.");
                }

/*
                if (this.id != null)
                {
                    throw new ApplicationException("The id property is immutable and may never be changed.");
                }
*/
                this.id = value;
            }
        }

        #endregion

        #region Operators

        /// <summary>
        /// Operator overload for determining equality.
        /// </summary>
        /// <param name="base1">The first instance of an <see cref="EntityBase{TId}"/>.</param>
        /// <param name="base2">The second instance of an <see cref="EntityBase{TId}"/>.</param>
        /// <returns>True if equal.</returns>
        public static bool operator ==(EntityBase<TId> base1, EntityBase<TId> base2)
        {
            // check for both null (cast to object or recursive loop)
            if ((object)base1 == null && (object)base2 == null)
            {
                return true;
            }

            // check for either of them == to null
            if ((object)base1 == null || (object)base2 == null)
            {
                return false;
            }

            return base1.Id.Equals(base2.Id);
        }

        /// <summary>
        /// Operator overload for determining inequality.
        /// </summary>
        /// <param name="base1">The first instance of an <see cref="EntityBase{TId}"/>.</param>
        /// <param name="base2">The second instance of an <see cref="EntityBase{TId}"/>.</param>
        /// <returns>True if not equal.</returns>
        public static bool operator !=(EntityBase<TId> base1, EntityBase<TId> base2)
        {
            return !(base1 == base2);
        }

        #endregion

        #region Equality Tests

        /// <summary>
        /// Determines whether the specified entity is equal to the current instance.
        /// </summary>
        /// <param name="obj">An <see cref="System.Object"/> that will be compared to the current instance.</param>
        /// <returns>True if the passed in entity is equal to the current instance.</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            return obj.GetType() == typeof(EntityBase<TId>) && this.Equals((EntityBase<TId>)obj);
        }

        /// <summary>
        /// Determines whether the specified entity is equal to the current instance.
        /// </summary>
        /// <param name="entity">Another <see cref="EntityBase{TId}"/> that will be compared to the current instance.</param>
        /// <returns>True if the passed in entity is equal to the current instance.</returns>
        public virtual bool Equals(EntityBase<TId> entity)
        {
            // NHibernate 3.0 Cookbook, pp 24-26
            if (entity == null)
            {
                return false;
            }

            if (ReferenceEquals(this, entity))
            {
                return true;
            }

            if (!IsTransient(this) &&
                !IsTransient(entity) &&
                Equals(this.Id, entity.Id))
            {
                var otherType = entity.GetUnproxiedType();
                var thisType = this.GetUnproxiedType();
                return thisType.IsAssignableFrom(otherType) ||
                    otherType.IsAssignableFrom(thisType);
            }

            return false;
        }

        /// <summary>
        /// Serves as a hash function for this type.
        /// </summary>
        /// <returns>A hash code for the current Key property.</returns>
        public override int GetHashCode()
        {
            if (Equals(this.Id, default(TId)))
            {
                return base.GetHashCode();
            }

            return this.Id.GetHashCode();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Default implementation for generating a new instance id.
        /// </summary>
        /// <returns>A new unique identifier for an instance.</returns>
        /// <exception cref="NotImplementedException">Must override to provide functionality</exception>
        public virtual object NewId()
        {
            throw new NotImplementedException();
        }

        private static bool IsTransient(EntityBase<TId> entity)
        {
            return entity != null && Equals(entity.Id, default(TId));
        }

        private Type GetUnproxiedType()
        {
            return GetType();
        }

        #endregion
    }
}
