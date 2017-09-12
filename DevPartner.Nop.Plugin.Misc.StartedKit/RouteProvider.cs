#region Copyright
/* Copyright (C) 2016 Fine Support L.P. - All Rights Reserved. 
 *
 * This file is part of DevPartner.Search.
 * 
 * DevPartner.Search can not be copied and/or distributed without the express
 * permission of Fine Support L.P.
 *
 * Written by Kanstantsin Ivinki, March 2016
 * Email: info@dev-partner.biz
 * Website: http://dev-partner.biz
 */
#endregion
using System.Web.Mvc;
using System.Web.Routing;
using Nop.Web.Framework.Mvc.Routes;

namespace DevPartner.Nop.Plugin.Misc.StartedKit
{
    public partial class RouteProvider : IRouteProvider
    {
        //public IAppBuilder _appBuilderService { get; set; }
        public void RegisterRoutes(RouteCollection routes)
        {
            ViewEngines.Engines.Add(new CustomViewEngine());
            RouteBase r = routes.MapRoute("DevPartner.Nop.Plugin.Misc.StartedKit.SubscribeToTheNewsletter",
            "DPStartedKit/SubscribeToTheNewsletter",
            new { controller = "DPStartedKit", action = "SubscribeToTheNewsletter" },
            new[] { "DevPartner.Nop.Plugin.Misc.StartedKit.Controllers" });
            routes.Remove(r);
            routes.Insert(0, r);

        }

        public int Priority => -1;
    }
}
