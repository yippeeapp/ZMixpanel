﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Zirpl.Metrics.MixPanel.Web.Mvc
{
    public class ConfigBuilder :IHtmlString, IPartialHtmlString
    {
        private readonly ConfigSettings _settings;
        private readonly IHtmlString _outermostBuilder;
        internal bool IsDirty { get; private set; }

        public ConfigBuilder(IHtmlString outermostBuilder)
        {
            this._outermostBuilder = outermostBuilder;
            this._settings = new ConfigSettings();
        }

        public ConfigBuilder UseCrossSubdomainCookie(bool value)
        {
            this._settings.UseCrossSubdomainCookie = value;
            this.IsDirty = true;
            return this;
        }

        public ConfigBuilder CookieName(String value)
        {
            this._settings.CookieName = value;
            this.IsDirty = true;
            return this;
        }

        public ConfigBuilder CookieLifetimeInDays(int value)
        {
            this._settings.CookieLifetimeInDays = value;
            this.IsDirty = true;
            return this;
        }

        public ConfigBuilder TrackPageView(bool value)
        {
            this._settings.TrackPageView = value;
            this.IsDirty = true;
            return this;
        }

        public ConfigBuilder TrackLinksTimeoutInMilliseconds(int value)
        {
            this._settings.TrackLinksTimeoutInMilliseconds = value;
            this.IsDirty = true;
            return this;
        }

        public ConfigBuilder DisableCookie(bool value)
        {
            this._settings.DisableCookie = value;
            this.IsDirty = true;
            return this;
        }

        public ConfigBuilder TransmitSecureCookieOnly(bool value)
        {
            this._settings.TransmitSecureCookieOnly = value;
            this.IsDirty = true;
            return this;
        }

        public ConfigBuilder UpgradeCookie(bool value)
        {
            this._settings.UpgradeCookie = value;
            this.IsDirty = true;
            return this;
        }

        public string ToHtmlString()
        {
            return this._outermostBuilder.ToHtmlString();
        }

        public string ToPartialHtmlString()
        {
            if (this.IsDirty)
            {
                return JsonConvert.SerializeObject(this._settings,
                    Formatting.Indented,
                    new JsonSerializerSettings {NullValueHandling = NullValueHandling.Ignore});
            }
            return null;
        }
    }
}
