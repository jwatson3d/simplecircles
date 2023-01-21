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

namespace Circles.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Represents a view model of a Person
    /// </summary>
    public class Person
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Person"/> class. 
        /// </summary>
        /// <remarks>Used to ensure Gender has a default value.</remarks>
        public Person()
        {
            this.Gender = "Unknown";
        }

        [Display(Name = "Person Id")]
        [Key]
        public Guid PersonId { get; set; }

        [Display(Name = "Full name")]
        public string FullName { get; set; }

        // [Required]
        [Display(Name = "Salutation")]
        [StringLength(20)]
        public string Salutation { get; set; }

        [Required]
        [Display(Name = "First name")]
        [StringLength(50, MinimumLength = 3)]
        public string FirstName { get; set; }

        // [Required]
        [Display(Name = "Middle name")]
        [StringLength(50)]
        public string MiddleName { get; set; }

        [Required]
        [Display(Name = "Last name")]
        [StringLength(50, MinimumLength = 3)]
        public string LastName { get; set; }

        // [Required]
        [Display(Name = "Suffix")]
        [StringLength(10)]
        public string Suffix { get; set; }

        [Required]
        [Display(Name = "Gender")]
        public string Gender { get; set; }

        // [Required]
        [Display(Name = "Birthday")]
        public DateTime Birthday { get; set; }
    }
}