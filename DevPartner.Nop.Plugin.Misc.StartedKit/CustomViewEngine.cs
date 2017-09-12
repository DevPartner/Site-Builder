#region Copyright
/* Copyright (C) 2016 Fine Support L.P. - All Rights Reserved. 
 *
 * This file is part of DevPartner.Core.
 * 
 * DevPartner.Core can not be copied and/or distributed without the express
 * permission of Fine Support L.P.
 *
 * Written by Kanstantsin Ivinki, July 2016
 * Email: info@dev-partner.biz
 * Website: http://dev-partner.biz
 */
#endregion

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using Nop.Web.Framework.Themes;

namespace DevPartner.Nop.Plugin.Misc.StartedKit
{
    public class CustomViewEngine : ThemeableRazorViewEngine
    {
        public CustomViewEngine()
        {

            ViewLocationFormats = new[]
            {
                "~/Plugins/DevPartner.CMS.StartedKit/Views/{1}/{0}.cshtml",
            };

            PartialViewLocationFormats = new[]
            {
                "~/Plugins/DevPartner.CMS.StartedKit/Views/{1}/{0}.cshtml",
            };
        }     
    }
}
