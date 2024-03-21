using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // public GameObject enemySmallPrefab;
    // public GameObject enemyMediumPrefab;
    // public GameObject enemyBigPrefab;

    public ObjectSpawnRate[] enemies;

    public float delaySpawner;

    private List<GameObject> enemylist;

    // Start is called before the first frame update
    void Start()
    {
        enemylist = new List<GameObject>();
        StartCoroutine(Spawner());

    }

    // Update is called once per frame
    private IEnumerator Spawner()
    {
        while (true)
        {
            if (GameManager.GetInstance().isPlaying)
            {
                spawn();
                yield return new WaitForSecondsRealtime(delaySpawner);
            }
            else
            {
                yield return null;
            }
        }
    }

    private GameObject getEnemy()
    {
        int limit = 0;

        foreach (ObjectSpawnRate osr in enemies)
        {
            limit += osr.rate;
        }


        int random = Random.Range(0, limit);

        foreach (ObjectSpawnRate osr in enemies)
        {
            if (random < osr.rate)
            {
                return osr.prefabs;
            }
            else
            {
                random -= osr.rate;
            }
        }
        return null;

    }

    public void spawn()
    {
        Vector3 newPosition = transform.position;
        newPosition.x = Random.Range(-17.5f, 4.5f);
        enemylist.Add(Instantiate(getEnemy(), newPosition, transform.rotation));
    }

    public void clearEnemies()
    {
        foreach (GameObject go in enemylist)
        {
            Destroy(go);
        }
        enemylist.Clear();

    }
}
