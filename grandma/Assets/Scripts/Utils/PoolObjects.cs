using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PoolObjects : MonoBehaviour
{
    [SerializeField] Transform container;

    [SerializeField] List<GameObject> objectsToPool;
    Dictionary<string, List<GameObject>> all;

    public GameObject GetObject(string key)
    {
        foreach (KeyValuePair<string, List<GameObject>> d in all)
        {
            if (d.Key == key)
            {
                GameObject go = GetObjectInDic(d.Value);
                if (go == null)
                {
                    go = AddNeObject(key);
                    return go;
                }
            }
        }
        Debug.LogError("No obj on pool" + key);
        return null;
    }
    public GameObject GetObjectInDic(List<GameObject> allInDic)
    {
        foreach (GameObject go in allInDic)
        {
            if (go.activeSelf)
                return go;
        }
        return null;
    }
    public GameObject AddNeObject(string key)
    {
        foreach (GameObject go in objectsToPool)
        {
            if (key == go.name)
            {
                foreach (KeyValuePair<string, List<GameObject>> d in all)
                {
                    if (d.Key == key)
                    {
                        List<GameObject> a = d.Value;
                        GameObject newGO = Instantiate(go, container);
                        a.Add(newGO);
                        return newGO;
                    }
                }
            }
        }
        return null;
    }
    public void Pool(GameObject go)
    {
        go.SetActive(false);
        go.transform.SetParent(container);
    }
}