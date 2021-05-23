using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GOPoolItem
{
    public GameObject[] goToPool; // Объекты длля пула
    public int goQwty; // Кол-во объектов
    public GameObject father; // Положение объектов в иерархии
    public bool addMore = true; // Можно ли добавлять ещё объекты при отсутсвие свободных
}

public class Pooler : MonoBehaviour
{
    public static Pooler Instance;

    public List<GOPoolItem> itemsToPool;
    public List<GameObject> pooledGO;


    private void Start()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        pooledGO = new List<GameObject>();

        // Инициация всех объектов в Пул
        foreach (GOPoolItem item in itemsToPool)
        {
            for (int i = 0; i < item.goQwty; i++)
            {
                GameObject go = Instantiate(item.goToPool[Random.Range(0, item.goToPool.Length)], item.father.transform);
                go.SetActive(false);
                pooledGO.Add(go);
            }
        }

        GameManager.Instance.spawner.StartSpawn();

    }

    /// <summary>
    /// ПОЛУЧЕНИЕ необходимого объекта из Пула по Тэгу
    /// </summary>
    /// <param name="tag">Тэг объекта для получения</param>
    /// <returns></returns>
    public GameObject GetPooledGO(string tag)
    {
        int counter = 0;
        for (int i = 0; i < pooledGO.Count; i++)
            if(pooledGO[i].tag == tag)
                ++counter;

        for (int i = 0; i < pooledGO.Count; i++)
        {
            
            if (pooledGO[i].tag == tag)
            {
                if (!pooledGO[i].activeInHierarchy)
                    return pooledGO[i];
                else if (i >= counter - 1 && pooledGO[i].activeInHierarchy)
                    foreach (GOPoolItem item in itemsToPool)
                    {
                        if (item.goToPool[Random.Range(0, item.goToPool.Length)].tag == tag)
                        {
                            if (item.addMore)
                            {
                                GameObject go = Instantiate(item.goToPool[Random.Range(0, item.goToPool.Length)], item.father.transform);
                                go.SetActive(false);
                                pooledGO.Add(go);
                                return go;
                            }
                        }
                    }
            }
        }
        return null;
    }
}
