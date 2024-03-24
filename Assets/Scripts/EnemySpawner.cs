using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.HID;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfigSO> waveConfigs;
    WaveConfigSO currentwave;
    [SerializeField] bool isLooping;

    public WaveConfigSO GetCurrentWave() { return currentwave; }
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
    

        do
        {
            foreach (WaveConfigSO waveConfig in waveConfigs)
            {
                currentwave = waveConfig;
                for (int i = 0; i < currentwave.GetEnemyCount(); i++)
                {
                    Instantiate(currentwave.GetEnemyPrefab(i), currentwave.GetStartingWayPoint().position, Quaternion.Euler(0,0,180), transform);
                    yield return new WaitForSecondsRealtime(currentwave.GetRandomSpawnTime());
                }
                yield return new WaitForSeconds(1);
            }
        } while (isLooping);
    }


    void Update()
    {

    }
}
