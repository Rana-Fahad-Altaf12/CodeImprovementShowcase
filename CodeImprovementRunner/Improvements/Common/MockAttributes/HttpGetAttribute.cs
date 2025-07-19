using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Improvements.Common.MockAttributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class HttpGetAttribute : Attribute
    {
        public string Template { get; }
        public HttpGetAttribute(string template = "") => Template = template;
    }
}
