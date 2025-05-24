using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ResourceManager
{
    private Dictionary<string, Object> resources = new Dictionary<string, Object>();

    public T Load<T>(string path) where T : Object
    {
        if(resources.ContainsKey(path))
        {
            return resources[path].GetComponent<T>();
        }

        T resource = Resources.Load<T>(path);
        if (resource == null)
        {
            Debug.Log($"Failed to load prefab at path: {path}");
            return null;
        }

        resources.Add(path, resource);
        return resource;
    }
}
