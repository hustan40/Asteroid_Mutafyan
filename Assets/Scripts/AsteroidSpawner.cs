using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public Asteroid AsteroidPrefab;
    public float spawnTime = 2.0f, spawnDistance = 14, coefSize = 0.1f;
    public int spawnAmount = 1;
    private void Start()
    {
        InvokeRepeating(nameof(Spawn),this.spawnTime, this.spawnTime);
    }
    private void Spawn()
    {
        for (int i = 0; i < spawnAmount; i++)
        {
            Vector3 spawnDirection = Random.insideUnitCircle.normalized * spawnDistance;
            Vector3 spawnPoint = this.transform.position + spawnDirection;
            float variance = Random.Range(-30f, 30f);
            Quaternion rotation = Quaternion.AngleAxis(variance, Vector3.forward);

            Asteroid asteroid = Instantiate(AsteroidPrefab, spawnPoint, rotation);
            asteroid.size = Random.Range(0.5f, 1.5f) * coefSize;
            asteroid.SetTrajectory(rotation * -spawnDirection);
        }
    }
}
