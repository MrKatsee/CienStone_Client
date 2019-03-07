using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MyResourceManager
{
    private static Dictionary<string, Object> resourceData = new Dictionary<string, Object>();

    public static T Load<T>(string path) where T : Object
    {
        if (resourceData.ContainsKey(path))
        {
            return resourceData[path] as T;
        }
        else
        {
            T newResource = Resources.Load<T>(path);
            if (newResource != null)
            {
                resourceData.Add(path, newResource);
                return resourceData[path] as T;
            }
            else
            {
                return null;
            }
        }
    }

    public static void ClearMemory()
    {
        resourceData.Clear();
        Resources.UnloadUnusedAssets();
    }
}
