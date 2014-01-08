﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;

namespace Zirpl.Metrics.MixPanel.Web.Mvc
{
    public class PropertiesVariableBuilder : IHtmlString
    {
        private String _variableName;
        private readonly PropertiesBuilder<object> _propertiesBuilder; 

        public PropertiesVariableBuilder()
        {
            this._propertiesBuilder = new PropertiesBuilder<object>(this);
        }

        public PropertiesVariableBuilder VariableName(String value)
        {
            this._variableName = value;
            return this;
        }

        public string ToHtmlString()
        {
            if (String.IsNullOrEmpty(this._variableName))
            {
                throw new InvalidOperationException("Cannot call ToHtmlString without setting VariableName");
            }

            return string.Format("var {0} = {1};", this._variableName,
                this._propertiesBuilder.ToPartialHtmlString());
        }
    }
}
