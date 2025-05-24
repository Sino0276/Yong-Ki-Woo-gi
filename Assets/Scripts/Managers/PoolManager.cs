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
    private Dictionary<string, Pool> pools = new();
    
    public void SetPool(GameObject prefab, int amount)
    {
        string key = prefab.name;

        if (prefab == null || pools.ContainsKey(key)) return;
        
        Pool pool = new Pool();
        pool.prefab = prefab;
        pool.gameObjects = new Stack<GameObject>();
        for (int i = 0; i < amount; i++)
        {
            GameObject gameObject = GameObject.Instantiate(prefab);
            gameObject.SetActive(false);
            gameObject.name = key;
            pool.gameObjects.Push(gameObject);
        }
        
        pools[key] = pool;
    }
    
    public GameObject GetPool(string key)
    {
        if (!pools.ContainsKey(key)) return null;

        GameObject gameObject = pools[key].gameObjects.Pop();
        gameObject.SetActive(true);

        return gameObject;
    }

    public void ReturnPool(GameObject gameObject)
    {
        string key = gameObject.name;
        if (!pools.ContainsKey(key))
        {
            GameObject.Destroy(gameObject);
            return;
        }

        gameObject.SetActive(false);
        pools[key].gameObjects.Push(gameObject);
    }
}
