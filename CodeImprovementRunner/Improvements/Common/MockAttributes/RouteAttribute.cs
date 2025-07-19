using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Improvements.Common.MockAttributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class RouteAttribute : Attribute
    {
        public string Template { get; }
        public RouteAttribute(string template) => Template = template;
    }


    [AttributeUsage(AttributeTargets.Parameter)]
    public class FromRouteAttribute : Attribute { }


    [AttributeUsage(AttributeTargets.Parameter)]
    public class FromQueryAttribute : Attribute { }

    [AttributeUsage(AttributeTargets.Method)]
    public class HttpPostAttribute : Attribute
    {
        public string Template { get; }
        public HttpPostAttribute(string template = "") => Template = template;
    }

    [AttributeUsage(AttributeTargets.Parameter)]
    public class FromBodyAttribute : Attribute
    {
    }
}
