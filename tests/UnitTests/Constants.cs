// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Constants.cs" company="John Watson">
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

namespace Circles.UnitTests
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Internal constants used by FakeRepository
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented",
        Justification = "Reviewed. Suppression is OK here.")]
    internal abstract class Constants
    {
        internal const string HouseholdIdChurchill = "CF5A8CB8-2D3F-4DD2-8DCD-41A85FE49943";
        internal const string HouseholdIdRoosevelt = "710EF937-6AA4-4FE1-A120-1F0B6AB7B546";
        internal const string OrgIdGreatLakes = "53173673-FDA4-4DD2-9FF2-801332842E4B";
        internal const string OrgIdLazyK = "24CE6D89-9C4A-4CCF-A8A4-585EED9FF594";
        internal const string PersonIdDavolio = "D28AA45E-C650-4121-8070-3D12BE31F91A";
        internal const string PersonIdFuller = "212F31D7-4EBF-4D82-B64D-ED20F3699234";
    }
}
