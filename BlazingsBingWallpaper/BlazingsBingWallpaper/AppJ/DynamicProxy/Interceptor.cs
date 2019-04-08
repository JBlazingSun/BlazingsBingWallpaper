using System;
using Castle.DynamicProxy;

namespace BlazingsBingWallpaper.AppJ.DynamicProxy
{
    [Serializable]
    public class Interceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            Console.WriteLine("Before target call");
            try
            {
                invocation.Proceed();

            }
            catch (Exception e)
            {
                Console.WriteLine("Target threw an exception!");
                throw;
            }
            finally
            {
                Console.WriteLine("After target call");
            }
        }
    }
}
