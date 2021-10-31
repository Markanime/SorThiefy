using System;
using System.Collections.Generic;
using UnityEngine;

public static class ServiceLocator
{
    private static readonly Dictionary<Type, object> _services = new Dictionary<Type, object>();

    public static void RegisterService<T>(T service)
    {
        var type = typeof(T);
        RegisterService(type, service);
    }

    public static void RegisterService(Type type, object service)
    {
        if (_services.ContainsKey(type))
        {
            if (service != _services[type])
            {
                _services[type] = service;
            }
        }
        else
        {
            _services.Add(type, service);
        }
    }

    public static T GetService<T>()
    {
        object service;
        Type type = typeof(T);
        if (!_services.TryGetValue(type, out service))
            throw new Exception(String.Format("Service {0} not found",type.Name));
        return (T)service;
    }

    public static bool HasService<T>()
    {
        Type type = typeof(T);
        return _services.ContainsKey(type);
    }

}