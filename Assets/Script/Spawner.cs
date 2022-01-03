﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private float spawnRangeX;
    [SerializeField]
    private float spawnRangeY;

    public GameObject boxPrefab;
    [Header ("Debug Setting")]
    public float debugXLineHeight = 10f;
    public float debugYLineDistance = 10f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnBoxRandom", 2, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnBoxRandom()
    {
        Vector3 spawnPos = new Vector3(
            Random.Range(-spawnRangeX, spawnRangeX), 
            Random.Range(-spawnRangeY, spawnRangeY), 
            0);

        Instantiate(boxPrefab, spawnPos, boxPrefab.transform.rotation);
    }

    private void OnDrawGizmos()
    {

        Debug.DrawLine(new Vector3(-spawnRangeX, 0, 0) + Vector3.up * debugXLineHeight / 2, new Vector3(spawnRangeX, 0, 0) + Vector3.up * debugXLineHeight / 2, Color.red);
        
        Debug.DrawLine(new Vector3(0, -spawnRangeY, 0) + Vector3.right * debugYLineDistance / 2, new Vector3(0, spawnRangeY, 0) + Vector3.right * debugYLineDistance / 2, Color.green);
    
    }
}
