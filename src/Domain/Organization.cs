// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Organization.cs" company="John Watson">
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
    /// <summary>
    /// Represents an organization such as a business, club, team, etc.
    /// </summary>
    public class Organization : Party
    {
        /// <summary>
        /// Gets or sets the formal greeting of the House instance.
        /// </summary>
        public virtual string TaxIdentifier { get; set; }
    }
}
