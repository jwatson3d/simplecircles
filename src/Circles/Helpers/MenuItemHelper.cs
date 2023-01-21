// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MenuItemHelper.cs" company="John Watson">
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

namespace Circles.Helpers
{
    using System;
    using System.Web.Mvc;
    using System.Web.Mvc.Html;

    /// <summary>
    /// This helper method renders a link within an HTML LI tag.
    /// A class="selected" attribute is added to the tag when
    /// the link being rendered corresponds to the current
    /// controller and action.
    /// <para>
    /// This helper method is used in the Site.Master View 
    /// Master Page to display the website menu.</para>
    /// </summary>
    public static class MenuItemHelper
    {
        /// <summary>
        /// Constructs a MenuItem that indicates whether or not it is currently selected.
        /// </summary>
        /// <param name="helper">The helper.</param>
        /// <param name="linkText">The link text.</param>
        /// <param name="actionName">The action name.</param>
        /// <param name="controllerName">The controller name.</param>
        /// <returns>
        /// An HTML &lt;LI&gt; tag with class="selected" if applicable.
        /// </returns>
        public static MvcHtmlString MenuItem(this HtmlHelper helper, string linkText, string actionName, string controllerName)
        {
            var currentControllerName = (string)helper.ViewContext.RouteData.Values["controller"];
            var currentActionName = (string)helper.ViewContext.RouteData.Values["action"];

            var builder = new TagBuilder("li");
            
            // Add selected class
            if (currentControllerName.Equals(controllerName, StringComparison.CurrentCultureIgnoreCase)
                && currentActionName.Equals(actionName, StringComparison.CurrentCultureIgnoreCase))
            {
                builder.AddCssClass("selected");
            }

            // Add link
            builder.InnerHtml = helper.ActionLink(linkText, actionName, controllerName).ToString();
            
            // Render Tag Builder
            return MvcHtmlString.Create(builder.ToString(TagRenderMode.Normal));
        }
    }
}
