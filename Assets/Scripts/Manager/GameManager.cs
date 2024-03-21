using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public GameObject playerPrefab;

    public GameObject activePlayer;

    public UnityAction OngameOverAction;

    public ScriptableInteger life;
    public ScriptableInteger coin;

    public bool isPlaying = false;

    public EnemySpawner spawner;

    public List<GameObject> items;

    internal void addItem(GameObject gameObject)
    {
        items.Add(gameObject);

    }

    public void clearAllItems()
    {
        foreach (GameObject go in items)
        {
            Destroy(go);
        }
        items.Clear();

    }

    // Start is called before the first frame update


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    internal void gameOver()
    {
        isPlaying = false;
        OngameOverAction?.Invoke();

    }

    void Start()
    {
        // spawnPlayer();
        items = new List<GameObject>();

    }

    public static GameManager GetInstance()
    {
        return instance;
    }

    public Vector3 getPlayerPosition()
    {
        if (activePlayer != null)
        {
            return activePlayer.transform.position;
        }
        return Vector3.zero;
    }

    private void spawnPlayer()
    {
        activePlayer = Instantiate(playerPrefab);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void startGame()
    {
        isPlaying = true;
        spawnPlayer();

    }

    internal void retryGame()
    {
        life.reset();
        coin.reset();

        spawner.clearEnemies();

        ObjectPool.GetInstance().deactivateAllObjects();

        clearAllItems();

    }

    public void pauseGame()
    {
        isPlaying = false;
        Time.timeScale = 0;
    }

    public void resumeGame()
    {
        isPlaying = true;
        Time.timeScale = 1;
    }


}
