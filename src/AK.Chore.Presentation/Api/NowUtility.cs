/*******************************************************************************************************************************
 * AK.Chore.Presentation.Api.NowUtility
 * Copyright © 2014-2015 Aashish Koirala <http://aashishkoirala.github.io>
 * 
 * This file is part of CHORE.
 *  
 * CHORE is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 * 
 * CHORE is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with CHORE.  If not, see <http://www.gnu.org/licenses/>.
 * 
 *******************************************************************************************************************************/

#region Namespace Imports

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Controllers;

#endregion

namespace AK.Chore.Presentation.Api
{
    /// <summary>
    /// Gets/sets date/time representing now from/to HTTP header.
    /// </summary>
    /// <author>Aashish Koirala</author>
    public static class NowUtility
    {
        public static DateTime GetNow(this HttpControllerContext context)
        {
            var now = DateTime.Now;
            var headers = context.Request.Headers;

            IEnumerable<string> values;
            if (!headers.TryGetValues("X-Now", out values)) return now;

            var value = values.FirstOrDefault();

            if (value == null) return now;
            return DateTime.TryParse(value, out now) ? now : DateTime.Now;
        }
    }
}