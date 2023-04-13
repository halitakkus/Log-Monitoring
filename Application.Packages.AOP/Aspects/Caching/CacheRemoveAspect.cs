﻿using Application.Core.Utilities.DependencyServiceTool;
using Application.Packages.AOP.Interceptor;
using Application.Packages.Caching.Core.Service;
using Castle.DynamicProxy;

namespace Application.Packages.AOP.Aspects.Caching;

public class CacheRemoveAspect :  MethodInterceptor
{
    private string _pattern;
    private ICacheService _cacheService;

    public CacheRemoveAspect(string pattern)
    {
        _pattern = pattern;
        var service = DependencyServiceTool.ServiceProvider.GetService(typeof(ICacheService));

        _cacheService = (ICacheService)service;
    }

    public override void OnSuccess(IInvocation invocation)
    {
        _cacheService.Remove(_pattern);
    }
}