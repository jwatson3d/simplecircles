// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Person.cs" company="John Watson">
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
    using System.Text;

    /// <summary>
    /// Represents a person.
    /// </summary>
    public class Person : Party
    {
        private string firstName;
        private string lastName;
        private string middleName;
        private string salutation;
        private string suffix;

        /// <summary>
        /// Initializes a new instance of the Person class.
        /// </summary>
        public Person()
        {
            // PartyType = PartyTypeEnum.Person;
        }

        /// <summary>
        /// Initializes a new instance of the Person class.
        /// </summary>
        /// <param name="id">An <see cref="System.Object"/> that 
        /// represents the primary identifier value for the class. </param>
        protected Person(Guid id)
            : base(id)
        {
            // PartyType = PartyTypeEnum.Person;
        }

        /// <summary>
        /// Gets or sets the first name of the Person instance.
        /// </summary>
        public virtual string FirstName
        {
            get
            {
                return this.firstName;
            }

            set
            {
                this.firstName = value;
                this.SetPartyName();
            }
        }

        /// <summary>
        /// Gets or sets the middle name of the Person instance.
        /// </summary>
        public virtual string MiddleName
        {
            get
            {
                return this.middleName;
            }

            set
            {
                this.middleName = value;
                this.SetPartyName();
            }
        }

        /// <summary>
        /// Gets or sets the last name of the Person instance.
        /// </summary>
        public virtual string LastName
        {
            get
            {
                return this.lastName;
            }

            set
            {
                this.lastName = value;
                this.SetPartyName();
            }
        }

        /// <summary>
        /// Gets or sets the salutation (a.k.a. honorific) of the Person instance.
        /// </summary>
        public virtual string Salutation
        {
            get
            {
                return this.salutation;
            }

            set
            {
                this.salutation = value;
                this.SetPartyName();
            }
        }

        /// <summary>
        /// Gets or sets the suffix (II, Jr. Sr., etc.) of the Person instance.
        /// </summary>
        public virtual string Suffix
        {
            get
            {
                return this.suffix;
            }

            set
            {
                this.suffix = value;
                this.SetPartyName();
            }
        }

        /// <summary>
        /// Gets or sets the gender of the Person instance.
        /// </summary>
        public virtual GenderEnum Gender { get; set; }

        /// <summary>
        /// Gets or sets the birthday of the Person instance.
        /// </summary>
        public virtual DateTime? Birthday { get; set; }

        #region Methods

        /// <summary>
        /// Calculates the age of the person.
        /// </summary>
        /// <returns>Person's age in years.</returns>
        private int CalculateAge()
        {
            if (this.Birthday == null)
            {
                return -1;
            }

            // Store today's date
            var now = DateTime.Today;

            // Calculate the difference in years
            var years = now.Year - this.Birthday.Value.Year;

            // Subtract one year, if the current date is 
            // before the birthday
            if ((now.Month < this.Birthday.Value.Month) ||
                (now.Month == this.Birthday.Value.Month &&
                 now.Day < this.Birthday.Value.Day))
            {
                years--;
            }

            return years;
        }

        /// <summary>
        /// Update party name whenever any relevant person property changes.
        /// </summary>
        private void SetPartyName()
        {
            var sb = new StringBuilder();

            if (!string.IsNullOrEmpty(this.Salutation))
            {
                sb.Append(this.Salutation);
            }

            if (!string.IsNullOrEmpty(this.FirstName))
            {
                if (sb.Length > 0)
                {
                    sb.Append(" ");
                }

                sb.Append(this.FirstName);
            }

            if (!string.IsNullOrEmpty(this.MiddleName))
            {
                if (sb.Length > 0)
                {
                    sb.Append(" ");
                }

                sb.Append(this.MiddleName.Substring(0, 1));
            }

            if (!string.IsNullOrEmpty(this.LastName))
            {
                if (sb.Length > 0)
                {
                    sb.Append(" ");
                }

                sb.Append(this.LastName);
            }

            if (!string.IsNullOrEmpty(this.Suffix))
            {
                if (sb.Length > 0)
                {
                    sb.Append(" ");
                }

                sb.Append(this.Suffix);
            }

            if (sb.Length > 0)
            {
                this.PartyName = sb.ToString();
            }
        }

        #endregion
    }
}
