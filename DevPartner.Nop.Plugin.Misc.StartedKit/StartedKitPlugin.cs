#region Copyright
/* Copyright (C) 2016 Fine Support L.P. - All Rights Reserved. 
 *
 * This file is part of DevPartner.StartedKit.
 * 
 * DevPartner.StartedKit can not be copied and/or distributed without the express
 * permission of Fine Support L.P.
 *
 * Written by Kanstantsin Ivinki, March 2016
 * Email: info@dev-partner.biz
 * Website: http://dev-partner.biz
 */
#endregion

using System.Collections.Generic;
using System.Web.Routing;
using Nop.Core.Plugins;
using Nop.Services.Common;
using Nop.Services.Localization;
using DevPartner.Nop.Plugin.Core.Models.CMS;
using Nop.Core.Infrastructure;
using DevPartner.Nop.Plugin.Core.Services;
using DevPartner.Nop.Plugin.Core.Services.Entities;
using DevPartner.Nop.Plugin.Core.Singletons;
using DevPartner.Nop.Plugin.Misc.StartedKit.Models;
using DevPartner.Nop.Plugin.Core.Helpers;
using DevPartner.Nop.Plugin.Core.Models.Basic;
using DevPartner.Nop.Plugin.Core.Models.Module;

namespace DevPartner.Nop.Plugin.Misc.StartedKit
{
    public class StartedKitPlugin : BasePlugin, IMiscPlugin
    {
        #region Consts

        #endregion

        #region Fields

        #endregion

        #region Ctor
        public StartedKitPlugin()
        {

        }
        #endregion

        #region IMiscPlugin
        /// <summary>
        /// Install plugin
        /// </summary>
        public override void Install()
        {
            var installation = EngineContext.Current.Resolve<DevPartnerSqlFileService>();
            installation.ExecuteFile("~/Plugins/DevPartner.CMS.StartedKit/Sql/DataStartedKit.sql");

            SetDefaultSettings();

            base.Install();
        }

        /// <summary>
        /// Uninstall plugin
        /// </summary>
        public override void Uninstall()
        {
            foreach (var localizationResource in GetLocalizationResources())
            {
                this.DeletePluginLocaleResource(localizationResource.Key);
            }
            base.Uninstall();
        }

        public void GetConfigurationRoute(out string actionName, out string controllerName, out RouteValueDictionary routeValues)
        {
            actionName = "";
            controllerName = "";
            routeValues = new RouteValueDictionary() { { "Namespaces", "DevPartner.Nop.Plugin.Misc.Search.Controllers" }, { "area", null } };
        }
        #endregion

        #region Utils
        public static void SetDefaultSettings()
        {
            GetLocalizationResources().AddOrUpdatePluginLocaleResource();
            var entityModelService = EngineContext.Current.Resolve<IEntityModelService>();
            #region Public pages
            var pageContentPage = new PublicPageModel { Name = "ContentPage", Path = "DP_ContentPage" };
            entityModelService.SaveEntity(pageContentPage, EntityTypes.PublicPage.Id);

            var pageRedirectPage = new PublicPageModel { Name = "RedirectPage", Path = "DP_RedirectPage" };
            entityModelService.SaveEntity(pageRedirectPage, EntityTypes.PublicPage.Id);

            var pageArticlePage = new PublicPageModel { Name = "ArticlePage", Path = "DP_ArticlePage" };
            entityModelService.SaveEntity(pageArticlePage, EntityTypes.PublicPage.Id);

            var pageGalleryPage = new PublicPageModel { Name = "GalleryPage", Path = "DP_GalleryPage" };
            entityModelService.SaveEntity(pageGalleryPage, EntityTypes.PublicPage.Id);

            var pageImageVideo = new PublicPageModel { Name = "ImageVideo", Path = "DP_ImageVideo" };
            entityModelService.SaveEntity(pageImageVideo, EntityTypes.PublicPage.Id);

            //var pageServicePage = new PublicPageModel { Name = "ServicePage", Path = "DP_ServicePage" };
            //entityModelService.SaveEntity(pageServicePage, EntityTypes.PublicPage.Id);

            //var pageFAQPage = new PublicPageModel { Name = "FAQPage", Path = "DP_FAQPage" };
            //entityModelService.SaveEntity(pageFAQPage, EntityTypes.PublicPage.Id);

            //var pagePromotionPage = new PublicPageModel { Name = "PromotionPage", Path = "DP_PromotionPage" };
            //entityModelService.SaveEntity(pagePromotionPage, EntityTypes.PublicPage.Id);

            //var pageTestimonial = new PublicPageModel { Name = "Testimonial" };
            //entityModelService.SaveEntity(pageTestimonial, EntityTypes.PublicPage.Id);

            //var pageClient = new PublicPageModel { Name = "Client" };
            //entityModelService.SaveEntity(pageClient, EntityTypes.PublicPage.Id);

            //var pageServicesModel = new PublicPageModel { Name = "Services", Path = "DP_Services" };
            //entityModelService.SaveEntity(pageServicesModel, EntityTypes.PublicPage.Id);

            //var pageServiceModel = new PublicPageModel { Name = "Service", Path = "DP_ServicePage" };
            //entityModelService.SaveEntity(pageServiceModel, EntityTypes.PublicPage.Id);

            //var pageProjectModel = new PublicPageModel { Name = "Project", Path = "DP_Project" };
            //entityModelService.SaveEntity(pageProjectModel, EntityTypes.PublicPage.Id);
            #endregion

            #region Save List Page Templates
            var pageGridListPage = new ListPageTemplateModel { Name = "GridListPage", Path = "DP_GridListPage" };
            var entityGridListPage = entityModelService.SaveEntity(pageGridListPage, EntityTypes.ListPageTemplate.Id) as DPModel;

            var pageArticleListPage = new ListPageTemplateModel { Name = "ArticleListPage", Path = "DP_ArticleListPage" };
            var entityArticleListPage = entityModelService.SaveEntity(pageArticleListPage, EntityTypes.ListPageTemplate.Id) as DPModel;

            //var pageFAQListPage = new ListPageTemplateModel { Name = "FAQListPage", Path = "DP_FAQListPage" };
            //var entityFAQListPage = entityModelService.SaveEntity(pageFAQListPage, EntityTypes.ListPageTemplate.Id) as DPModel;

            //var pagePortfolioListPage = new ListPageTemplateModel { Name = "PortfolioListPage", Path = "DP_PortfolioListPage" };
            //var entityPortfolioListPage = entityModelService.SaveEntity(pagePortfolioListPage, EntityTypes.ListPageTemplate.Id) as DPModel;

            //var pagePromotionListPage = new ListPageTemplateModel { Name = "PromotionListPage", Path = "DP_PromotionListPage" };
            //var entityPromotionListPage = entityModelService.SaveEntity(pagePromotionListPage, EntityTypes.ListPageTemplate.Id) as DPModel;

            var pageDownloadListPage = new ListPageTemplateModel { Name = "DownloadListPage", Path = "DP_DownloadListPage" };
            var entityDownloadListPage = entityModelService.SaveEntity(pageDownloadListPage, EntityTypes.ListPageTemplate.Id) as DPModel;

            //var pageListPage = new ListPageTemplateModel { Name = "ListPage", Path = "DP_ListPage" };
            //entityModelService.SaveEntity(pageListPage, EntityTypes.ListPageTemplate.Id);
            #endregion

            #region Save cms entities/models
            var installBaseItemsService = EngineContext.Current.Resolve<InstallBaseItemsService>();
            installBaseItemsService.SaveCmsEntitiesAndModels();
            #endregion

            #region Save gallery templates
            //var galleryVideoPage = new GalleryPageTemplateModel { Name = "GalleryVideoPage", Path = "_DP_GalleryVideoPage" };
            //entityModelService.SaveEntity(galleryVideoPage, Singletons.EntityTypes.GalleryPageTemplate.Id);

            var galleryGridPage = new GalleryPageTemplateModel { Name = "GalleryGridPage", Path = "_DP_GalleryGridPage" };
            entityModelService.SaveEntity(galleryGridPage, Singletons.EntityTypes.GalleryPageTemplate.Id);

            var galleryGrid2Page = new GalleryPageTemplateModel { Name = "GalleryGrid2Page", Path = "_DP_GalleryGrid2Page" };
            entityModelService.SaveEntity(galleryGrid2Page, Singletons.EntityTypes.GalleryPageTemplate.Id);

            var gallerySliderPage = new GalleryPageTemplateModel { Name = "GallerySliderPage", Path = "_DP_GallerySliderPage" };
            entityModelService.SaveEntity(gallerySliderPage, Singletons.EntityTypes.GalleryPageTemplate.Id);
            #endregion

            #region Save list pages
            //save Portfolio
            //var portfolio = new ListPageModel { Name = "Portfolio", Published = true, PublicPageTemplate = entityPortfolioListPage != null ? (int?)entityPortfolioListPage.Id : null };
            //
            //entityModelService.SaveEntity(portfolio, entityTypeListPage.Id);

            var entityTypeListPage = EntityTypes.ListPage;
            //save downloads
            var downloadPage = new ListPageModel { Name = "Download", SearchEntityType = Singletons.EntityTypes.Download.Id, PublicPageTemplate = entityDownloadListPage.Id,IncludeInMyAccountMenu = true };
            entityModelService.SaveEntity(downloadPage, entityTypeListPage.Id);

            //save Article
            var article = new ListPageModel { Name = "Article", Published = true, SearchEntityType = Singletons.EntityTypes.Article.Id,  PublicPageTemplate = entityArticleListPage != null ? (int?)entityArticleListPage.Id : null };
            entityModelService.SaveEntity(article, entityTypeListPage.Id);

            ////save FAQPage
            //var faq = new ListPageModel { Name = "FAQPage", Published = true, PublicPageTemplate = entityFAQListPage != null ? (int?)entityFAQListPage.Id : null };
            //entityModelService.SaveEntity(faq, entityTypeListPage.Id);

            ////save Promotion
            //var promotion = new ListPageModel { Name = "Promotion", Published = true, PublicPageTemplate = entityPromotionListPage != null ? (int?)entityPromotionListPage.Id : null };
            //entityModelService.SaveEntity(promotion, entityTypeListPage.Id);

            //save Gallery
            var gallery = new ListPageModel { Name = "Gallery", SearchEntityType = Singletons.EntityTypes.Gallery.Id, Published = true, PublicPageTemplate = entityGridListPage != null ? (int?)entityGridListPage.Id : null };
            entityModelService.SaveEntity(gallery, entityTypeListPage.Id);
            #endregion

        }
        protected static Dictionary<string, string> GetLocalizationResources()
        {
            return new Dictionary<string, string>
            {
                {"DevPartner.StartedKit.Subscription", "Subscription" },
                {"DevPartner.StartedKit.SubscriptionInfo", "Subscription information" },
                {"DevPartner.StartedKit.SubscriptionNote", "Items marked with an * are required" },
                {"DevPartner.StartedKit.PhoneNumber", "Phone number" },
                {"DevPartner.StartedKit.SubscribeToTheNewsletters", "Now you subscribed to the newsletters!" },
                {"DevPartner.StartedKit.ReadMore", "Read more" },
                {"DevPartner.StartedKit.PublishDateTime", "Publish date time" },

            };
        }
        #endregion
    }
}
