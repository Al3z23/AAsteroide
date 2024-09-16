using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class EnemySpawner : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public float spawnRatePerMinute = 30f;
    public float spawnRateIncrement = 1f;
    public float xLimit;
    public float maxTimeLife = 2f;
    private float spawnNext = 0;

    void Update()
    {
        if(Time.time > spawnNext){
            spawnNext = Time.time + 60/spawnRatePerMinute;
            spawnRatePerMinute += spawnRateIncrement;
            float rand = Random.Range(-xLimit,xLimit);
            Vector2 spawnPosition = new Vector2(rand,8f);
            GameObject meteor = Instantiate(asteroidPrefab, spawnPosition, Quaternion.identity); 
            //Sin object pooling
            Destroy(meteor, maxTimeLife); //Sin object pooling
            
        }
    }

}
