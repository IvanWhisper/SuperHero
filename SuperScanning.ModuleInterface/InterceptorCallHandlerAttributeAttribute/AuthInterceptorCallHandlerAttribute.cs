using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperScanning.ModuleInterface.InterceptorCallHandlerAttributeAttribute
{
    [AttributeUsage(AttributeTargets.Method, Inherited = true)]
    public class AuthInterceptorCallHandlerAttribute : Attribute
    {
        public Guid ObjID { get; set; }
        public AuthInterceptorCallHandlerAttribute()
        {
            ObjID = Guid.NewGuid();
        }
        public  string Role { get; set; }
        public object DefaultReturnValue { get; set; } = "NoAuth";
    }
}
