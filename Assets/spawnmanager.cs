using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnmanager : MonoBehaviour
{
    public GameObject enemyprefab;
    public GameObject powerupprefab;
    public Vector2 spawnrange;
    private int enemycount;
    private int waves;

    void Start()
    {
        waves = 1;
        spawnenemy();
    }
    private void Update()
    {
        enemycount = FindObjectsOfType<enemycontroller>().Length;
        if(enemycount==0)
        {
            waves++;
            spawnenemy();
        }
    }
    private void spawnenemy()
    {
        for(var i=0;i<waves;i++)
        {
            Vector3 spawnpos = new Vector3(Random.Range(spawnrange[0], spawnrange[1]), enemyprefab.transform.position.y,
            Random.Range(spawnrange[0], spawnrange[1]));

            Instantiate(enemyprefab, spawnpos, enemyprefab.transform.rotation);
        }
        
    }
}
