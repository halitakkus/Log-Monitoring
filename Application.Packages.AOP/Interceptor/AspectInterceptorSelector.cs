﻿using System;
using System.Linq;
using System.Reflection;
using Castle.DynamicProxy;

namespace Application.Packages.AOP.Interceptor
{
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes = type
                .GetCustomAttributes<MethodInterceptorBase>(true)
                .ToList();

            var methodAttributes = method
            .GetCustomAttributes<MethodInterceptorBase>(true)
            .ToList();

             classAttributes.AddRange(methodAttributes);

            return classAttributes.OrderBy(i => i.Priority).ToArray();
        }
    }
}
