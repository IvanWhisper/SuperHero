using Autofac;
using Castle.DynamicProxy;
using SuperScanning.DataModel;
using SuperScanning.ModuleInterface;
using SuperScanning.ModuleInterface.InterceptorCallHandlerAttributeAttribute;
using SuperScanning.ModuleInterface.Interceptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SuperScanning.Interceptor
{
    public class AuthInterceptor: IAuthInterceptor
    {
        private ILifetimeScope _root;
        private ILogger _log;
        public AuthInterceptor(ILogger log, ILifetimeScope root)
        {
            this._log = log;
            this._root = root;
        }
        public void Intercept(IInvocation invocation)
        {
            if (invocation == null)
                return;
            MethodInfo methodInfo = invocation.MethodInvocationTarget;
            if (methodInfo == null)
            {
                methodInfo = invocation.Method;
            }
            AuthInterceptorCallHandlerAttribute authInterceptor = methodInfo.GetCustomAttributes<AuthInterceptorCallHandlerAttribute>(true).FirstOrDefault();
            if (authInterceptor != null)
            {
                UserEntity user = null;
                using (var scope=_root.BeginLifetimeScope())
                {
                    user=scope.ResolveOptional<ICache>().User;
                }
                //adminToken
                if (user!=null&&user.Role.Equals(authInterceptor.Role) && user.Password.Equals("admin123"))
                {
                    _log.Info($"[{authInterceptor.ObjID}] Token is right!");
                    invocation.Proceed();
                    _log.Info($"Method:[{invocation.Method.Name}] is done!");
                }
                else
                {
                    invocation.ReturnValue = authInterceptor.DefaultReturnValue;
                }
            }
            else
            {
                invocation.Proceed();
            }

        }
    }
}

