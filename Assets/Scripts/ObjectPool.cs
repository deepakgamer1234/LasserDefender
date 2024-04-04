using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool Instance;

    [SerializeField] GameObject projectilePrefab;
    [SerializeField] int poolSize = 20;
    Queue<GameObject> projectilesPool = new Queue<GameObject>();

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject projectile = Instantiate(projectilePrefab);
            projectile.SetActive(false);
            projectilesPool.Enqueue(projectile);
        }
    }

    public GameObject Get()
    {
        if (projectilesPool.Count > 0)
        {
            GameObject projectile = projectilesPool.Dequeue();
            projectile.SetActive(true);
            return projectile;
        }
        else
        {
            GameObject projectile = Instantiate(projectilePrefab);
            return projectile;
        }
    }

    public void ReturnToPool(GameObject projectile)
    {
        projectile.SetActive(false);
        projectilesPool.Enqueue(projectile);
    }
}
