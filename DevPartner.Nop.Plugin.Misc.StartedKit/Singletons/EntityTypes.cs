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

using DevPartner.Nop.Plugin.Core.Domain;
using DevPartner.Nop.Plugin.Core.Helpers;
using DevPartner.Nop.Plugin.Misc.StartedKit.Models;

namespace DevPartner.Nop.Plugin.Misc.StartedKit.Singletons
{
    public class EntityTypes
    {
        private static EntityType _galleryPageTemplate;
        public static EntityType GalleryPageTemplate => _galleryPageTemplate ??
                                                        (_galleryPageTemplate = Core.Singletons.EntityTypes.GetEntityType("GalleryPageTemplate"));

        private static EntityType _imageVideoModel;
        public static EntityType ImageVideoModel => _imageVideoModel ??
                                                    (_imageVideoModel = Core.Singletons.EntityTypes.GetEntityType("ImageVideo"));

        private static EntityType _entityRequest;
        public static EntityType Request => _entityRequest ??
                                            (_entityRequest = Core.Singletons.EntityTypes.GetEntityType("Request"));

        private static EntityType _services;
        public static EntityType Services => _services ??
                                            (_services = Core.Singletons.EntityTypes.GetEntityType("Services"));
        private static EntityType _service;
        public static EntityType Service => _service ??
                                            (_service = Core.Singletons.EntityTypes.GetEntityType("Service"));
        private static EntityType _testimonial;
        public static EntityType Testimonial => _testimonial ??
                                            (_testimonial = Core.Singletons.EntityTypes.GetEntityType("Testimonial"));
        private static EntityType _project;
        public static EntityType Project => _project ??
                                            (_project = Core.Singletons.EntityTypes.GetEntityType("Project"));

        private static EntityType _article;
        public static EntityType Article => _article ?? (_article =
                                                Core.Singletons.EntityTypes.GetEntityType(typeof(ArticleModel)
                                                    .GetSystemName()));
        private static EntityType _download;
        public static EntityType Download => _download ?? (_download =
                                                 Core.Singletons.EntityTypes.GetEntityType(typeof(DownloadModel)
                                                     .GetSystemName()));

        private static EntityType _gallery;
        public static EntityType Gallery => _gallery ?? (_gallery =
                                                Core.Singletons.EntityTypes.GetEntityType(typeof(GalleryModel)
                                                    .GetSystemName()));
    }
}
