using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    WaveConfigSO waveConfig;
    EnemySpawner enemySpawner;
    List<Transform> wayPoints;

    int wayPointIndex = 0;

    private void Awake()
    {
        enemySpawner = FindAnyObjectByType<EnemySpawner>();
    }
    void Start()
    {
        waveConfig = enemySpawner.GetCurrentWave();
        wayPoints = waveConfig.GetWayPoints();
        transform.position = wayPoints[wayPointIndex].position;
    }

    void Update()
    {
        FollowPath();
    }

    private void FollowPath()
    {
        if (wayPointIndex < wayPoints.Count)
        {
            Vector3 tragetPosition = wayPoints[wayPointIndex].position;
            float detla = waveConfig.GetSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, tragetPosition, detla);
            if (transform.position == tragetPosition)
            {
                wayPointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
