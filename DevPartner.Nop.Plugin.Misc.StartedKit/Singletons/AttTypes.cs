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
using DevPartner.Nop.Plugin.Core.Domain;
using DevPartner.Nop.Plugin.Core.Services.Entities;
using Nop.Core.Infrastructure;

namespace DevPartner.Nop.Plugin.Misc.StartedKit.Singletons
{
    public class AttTypes
    {
        private static AttType _tags;
        public static AttType Tags
        {
            get
            {
                return _tags ??
                       (_tags = Core.Singletons.AttTypes.Instance.FirstOrDefault(x => x.Name == "Tags"));
            }
        }
    }
}
