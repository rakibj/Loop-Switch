using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

    public float lastPositionY;
    private Quaternion lastRotation;
    public static SpawnManager instance;
    ObjectPooler objectpooler;
    GameObject lastLoop;
    public GameObject loopSpawnEffect;

    void Start () {
        objectpooler = ObjectPooler.instance;
        MakeSingleton();
        lastPositionY = 0f;
        lastRotation = Quaternion.identity;
        SpawnLoop();
    }

    void MakeSingleton()
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

    void Update () {
        if (lastLoop != null)
        {
            lastRotation = lastLoop.transform.rotation;
        }
    }

    public void SpawnLoop()
    {
        Debug.Log(GameManager.score);
        Vector2 spawnPosition = new Vector2(0, lastPositionY + 2);
        Instantiate(loopSpawnEffect, spawnPosition, lastRotation);
        lastLoop = objectpooler.SpawnFromPool("Loop", spawnPosition, lastRotation);
        lastPositionY += 2;
    }
}
