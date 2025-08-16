using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager
{
    private Dictionary<string, Object> resources = new Dictionary<string, Object>();

    public void Init()
    {
        
    }

    public T Load<T>(string path) where T : Object
    {
        if (resources.TryGetValue(path, out Object resource))
        {
            return resource as T;
        }

        resource = Resources.Load<T>(path);
        if (resource == null)
        {
            Debug.Log($"Failed to load prefab at path: {path}");
            return null;
        }

        resources.Add(path, resource);
        return resource as T;
    }

    public List<Sprite> LoadProjectileSprites(List<string> paths)
    {
        List<Sprite> sprites = new List<Sprite>();

        for (int i = 0; i < paths.Count; i++)
        {
            Sprite sprite = Load<Sprite>("Projectiles/" + paths[i]);
            if (sprite == null)
            {
                Debug.Log($"Failed to load prefab at path: {paths[i]}");
                return null;
            }

            sprites.Add(sprite);
        }

        return sprites;
    }
}
