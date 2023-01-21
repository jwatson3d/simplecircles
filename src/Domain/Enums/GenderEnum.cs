// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GenderEnum.cs" company="John Watson">
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

// ReSharper disable CheckNamespace
namespace Circles.Domain
// ReSharper restore CheckNamespace
{
    /// <summary>
    /// Represents the allowable genders.
    /// </summary>
    public enum GenderEnum
    {
        /// <summary>
        /// Gender is unknown
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// Gender is female
        /// </summary>
        Female = 1,

        /// <summary>
        /// Gender is male
        /// </summary>
        Male = 2
    }
}
