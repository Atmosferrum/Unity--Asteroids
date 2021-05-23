using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    GameObject[] objectsToSpawn;

    float spawnCD = 5f; // Таймер новго объекта;
    float minSpawnCd = 1f;
    float timerStep = 0.01f;
    float minSpawnDistance = 1f;
    float maxSpawnDistance = 5f;

    /// <summary>
    /// НАЧАТЬ появление объектов
    /// </summary>
    public void StartSpawn()
    {
        StartCoroutine(SpawnObject());
    }

    /// <summary>
    /// ПОЯВЛЕНИЕ объекта
    /// </summary>
    /// <returns></returns>
    IEnumerator SpawnObject()
    {
        for (int i = 0; i < objectsToSpawn.Length; i++)
        {
            GameObject spawnedObject = Pooler.Instance.GetPooledGO(objectsToSpawn[Random.Range(0, objectsToSpawn.Length - 1)].tag);
            spawnedObject.transform.position = startPos();
            spawnedObject.SetActive(true);

            if (spawnCD > minSpawnCd)
                spawnCD -= timerStep;
            break;
        }

        yield return new WaitForSeconds(spawnCD);

        StartCoroutine(SpawnObject());
    }
    
    /// <summary>
    /// ПОЛУЧЕНИЕ координат за экраном
    /// </summary>
    /// <returns>Координата за экраном</returns>
    Vector2 startPos()
    {
        float[] x = {GameManager.Instance.sceneSize.sceneRightEdge + minSpawnDistance,
                    -GameManager.Instance.sceneSize.sceneRightEdge - minSpawnDistance,
                     GameManager.Instance.sceneSize.sceneRightEdge + maxSpawnDistance,
                    -GameManager.Instance.sceneSize.sceneRightEdge - maxSpawnDistance};

        float[] y = {GameManager.Instance.sceneSize.sceneTopEdge + minSpawnDistance
                    -GameManager.Instance.sceneSize.sceneTopEdge - minSpawnDistance,
                     GameManager.Instance.sceneSize.sceneTopEdge + maxSpawnDistance,
                    -GameManager.Instance.sceneSize.sceneTopEdge - maxSpawnDistance };

        return new Vector2(x[Random.Range(0, x.Length - 1)], y[Random.Range(0, y.Length - 1)]);
    }
}
