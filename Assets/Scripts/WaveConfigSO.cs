using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave config", fileName = "New Wave Config")]
public class WaveConfigSO : ScriptableObject
{
    [SerializeField] List<GameObject> enemyPrefabs;
    [SerializeField] Transform pathPrefab;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float timeBetweenEnemySpawns = 1f;
    [SerializeField] float spawnTimeVarience = 0f;
    [SerializeField] float minimumSpawnTime = 0.2f;
    public int GetEnemyCount() {  return enemyPrefabs.Count; }

    public GameObject GetEnemyPrefab(int index) {  return enemyPrefabs[index]; }
    public Transform GetStartingWayPoint()
    {
        return pathPrefab.GetChild(0);
    }

    public List<Transform> GetWayPoints()
    {
        List<Transform> wayPoints = new List<Transform>();
        foreach (Transform child in pathPrefab)
        {
            wayPoints.Add(child);
        }
        return wayPoints;
    }
    public float GetSpeed()
    {
        return moveSpeed;
    }

    public float GetRandomSpawnTime()
    {
        float spawnTime = Random.Range(timeBetweenEnemySpawns-spawnTimeVarience, timeBetweenEnemySpawns+spawnTimeVarience);
        return Mathf.Clamp(spawnTime, minimumSpawnTime, float.MaxValue);
    }
}
