// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Party.cs" company="John Watson">
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

    /// <summary>
    /// An abstract class representing any 'Party' that can be interacted with.
    /// </summary>
    public abstract class Party : Entity
    {
        private ISet<ChannelAddress> channelAddresses = new HashSet<ChannelAddress>();

        private ISet<PartyNote> notes = new HashSet<PartyNote>();

        private ISet<PostalAddress> postalAddresses = new HashSet<PostalAddress>();

        /// <summary>
        /// Initializes a new instance of the Party class.
        /// </summary>
        protected Party()
        {
        }

        /// <summary>
        /// Initializes a new instance of the Party class.
        /// </summary>
        /// <param name="id">A <see cref="System.Guid"/> that 
        /// represents the primary identifier value for the class. </param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", 
            "CA2214:DoNotCallOverridableMethodsInConstructors", 
            Justification = "Necessary to ensure every instance is always uniquely identified.")]
        protected Party(Guid id)
            : base(id)
        {
        }

        /// <summary>
        /// Gets or sets the unique identifier of the Party instance.
        /// </summary>
        public virtual Guid PartyId
        {
            get { return Id; }
            set { Id = value; }
        }

        /// <summary>
        /// Gets or sets the PartyType of the Party instance.
        /// </summary>
        public virtual PartyType PartyType { get; set; }

        /// <summary>
        /// Gets or sets the name of the Party instance.
        /// </summary>
        public virtual string PartyName { get; set; }

        /// <summary>
        /// Gets or sets the Notes associated with the Party instance.
        /// </summary>
        public virtual ISet<ChannelAddress> ChannelAddresses
        {
            get { return this.channelAddresses; }
            set { this.channelAddresses = value; }
        }

        /// <summary>
        /// Gets or sets the Notes associated with the Party instance.
        /// </summary>
        public virtual ISet<PartyNote> Notes
        {
            get { return this.notes; }
            set { this.notes = value; }
        }

        /// <summary>
        /// Gets or sets the PostalAddresses associated with the Party instance.
        /// </summary>
        public virtual ISet<PostalAddress> PostalAddresses
        {
            get { return this.postalAddresses; }
            set { this.postalAddresses = value; }
        }

        #region Methods

        /// <summary>
        /// Add a <see cref="ChannelAddress"/> to the Party instance.
        /// </summary>
        /// <param name="address">The address to add.
        /// </param>
        public virtual void AddAddress(ChannelAddress address)
        {
            address.Party = this;
            this.channelAddresses.Add(address);
        }

        /// <summary>
        /// Add a <see cref="PostalAddress"/> to the Party instance.
        /// </summary>
        /// <param name="address">The address to add.
        /// </param>
        public virtual void AddAddress(PostalAddress address)
        {
            address.Party = this;
            this.postalAddresses.Add(address);
        }

        /// <summary>
        /// Add a <see cref="PartyNote"/> to the Party instance.
        /// </summary>
        /// <param name="note">The note to add.</param>
        public virtual void AddNote(PartyNote note)
        {
            note.Party = this;
            this.notes.Add(note);
        }

        #endregion
    }
}
