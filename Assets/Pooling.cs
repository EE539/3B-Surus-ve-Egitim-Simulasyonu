using System.Collections.Generic;
using UnityEngine;

public class Pooling : MonoBehaviour
{
    [System.Serializable]
    public struct Pool
    {
        public Queue<GameObject> pooledObjects;//havuz uretme
        public int poolSize;
        public GameObject objectPrefab;
    }
    //1 havuzda aynı prefabler olur eger 2prefab varsa 2 havuz
    //olusturman gerekir.//bunun içinde bu 1 havuz için gerekli olanları // 2kez uretmen gerekecek. bunun
    //için bunu bir struct yapısında tutumalıyız

    [SerializeField] private Pool[] pools;
  
    private void Awake()
    {
        for (int j = 0; j < pools.Length; j++)//kac tane havuzum var //2
        {
            pools[j].pooledObjects = new Queue<GameObject>();//her bir havuzun queue uretıyoruz//

            for (int i = 0; i < pools[j].poolSize; i++)//1
            {
                GameObject obj = Instantiate(pools[j].objectPrefab);
                obj.SetActive(false);
                pools[j].pooledObjects.Enqueue(obj);
            }
        }
    }

    // Update is called once per frame

    public GameObject GetPooledObject(int j)
    {
        if (j > pools.Length)
        {
            return null;
        }
        GameObject obj = pools[j].pooledObjects.Dequeue();
        obj.SetActive(true);
        pools[j].pooledObjects.Enqueue(obj);
        return obj;
    }
}