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

using System.Linq;
using System.Web.Mvc;
using DevPartner.Nop.Plugin.Core.Services.Entities;
using System;
using DevPartner.Nop.Plugin.Core.Controllers;
using DevPartner.Nop.Plugin.Core.Models.CMS;
using DevPartner.Nop.Plugin.Misc.StartedKit.Models;
using DevPartner.Nop.Plugin.Misc.StartedKit.Singletons;
using Nop.Services.Localization;

namespace DevPartner.Nop.Plugin.Misc.StartedKit.Controllers
{
    public class DPStartedKitController : BaseEntityRenderingController
    {
        #region Constant
        #endregion

        #region Fields

        private readonly IEntityModelService _entityModelService;
        private readonly ILocalizationService _localizationService;

        #endregion Fields

        #region Constructors

        public DPStartedKitController(
            IEntityModelService entityModelService,
            ILocalizationService localizationService
            )
        {
            _entityModelService = entityModelService;
            _localizationService = localizationService;
        }

        #endregion

        #region Methods

        [ChildActionOnly]
        public ActionResult List(GalleryModel model)
        {
            var entities = model.PageSize > 0 ? 
                _entityService.SearchEntities(parentId: model.Id, pageIndex: model.PageIndex - 1, pageSize: model.PageSize) : 
                _entityService.SearchEntities(parentId: model.Id);

            model.TotalCount = entities.TotalCount;

            model.Models = _entityModelService.GetModels<ImageVideoModel>(entities).ToList();
                
            if (model.GalleryPageTemplate != null && (model.GalleryPageTemplate > 0))
            {
                var entityRendering = _entityService.GetEntityById(model.GalleryPageTemplate.Value);

                var publicRendering = _entityModelService.GetModel<PublicPageModel>(entityRendering);

                if (!String.IsNullOrEmpty(publicRendering.Path))
                {
                    return View(publicRendering.Path, model);
                }
                throw new Exception("Public page rendering type not defined in RenderEntity method");
            }
            return View("_DP_GalleryPage", model);
        }


        public ActionResult SubscribeToTheNewsletter(RequestModel model)
        {
            model.Name = string.Format("{0}_{1}", model.Name, DateTime.Now);
            _entityModelService.SaveEntity(model, EntityTypes.Request.Id);
            return Json(new
            {
                success = true,
                message = _localizationService.GetResource("DevPartner.StartedKit.SubscribeToTheNewsletters")
            });
        }
        #endregion

    }
}