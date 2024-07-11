using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawnManager : MonoBehaviour {

    // Car spawn manager
    [SerializeField] private GameObject[] cars;
    [SerializeField] private float spawnInterval = 3f;
    [SerializeField] private float spawnDistance = 5f;
    [SerializeField] private float spawnDistanceForward = 1000f;

    [SerializeField] private Transform player;
    private float spawnTimer = 0f;


    private void Update() {
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnInterval) {
            SpawnCar();
            spawnTimer = 0f;
        }
    }

    private void SpawnCar() {
        int randomCar = Random.Range(0, cars.Length);
        Vector3 spawnPosition = new Vector3(Random.Range(-2, 2), 0, player.position.z + 50);
        Instantiate(cars[randomCar], spawnPosition, Quaternion.identity);
    
    }
}
