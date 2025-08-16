using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * 미리 만들어 놓고 가져다 쓰는거
 */
public class PoolManager
{
    private struct Pool
    {
        public GameObject prefab;
        // 아마도 캐시 때문에 스택 쓰는듯
        public Stack<GameObject> gameObjects;
    }
    private Dictionary<String, Pool> pools = new();
    
    
    public void Init()
    {
        
    }
    
    
    
    public void SetPool(String key, GameObject prefab, int amount)
    {
        if (prefab == null || pools.ContainsKey(key)) return;
        
        Pool pool = new Pool();
        pool.prefab = prefab;
        pool.gameObjects = new Stack<GameObject>(amount);
        for (int i = 0; i < amount; i++)
        {
            GameObject gameObject = GameObject.Instantiate(prefab);
            gameObject.SetActive(false);
            // pool.gameObjects.Peek().SetActive(false);
            pool.gameObjects.Push(gameObject);
            
        }
        
        // pools.Add(key, pool);
        pools[key] = pool;
    }
    
    public GameObject GetPool(String key)
    {
        if (!pools.ContainsKey(key)) return null;
        
        return pools[key].gameObjects.Pop() ?? null;
    }

    // public void EnablePool(String key, bool enable)
    // {
    //     if (!pools.ContainsKey(key)) return;
    //     
    //     pools[key].gameObjects.Pop().SetActive(enable);
    //     
    // }
    //
    // public void DisablePool(String key, bool disable)
    // {
    //     
    // }
    
    // public void DestroyPool(String key)
    // {
    //     if (!pools.ContainsKey(key)) return;
    //     
    //     for (int i = 0; i < pools[key].gameObjects.Count; i++)
    //     {
    //         GameObject.Destroy(pools[key].prefab);
    //     }
    //     
    // }
    
    
}
