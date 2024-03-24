
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("General")]
    [SerializeField] GameObject ProjectilePreFabs;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileLifeTime = 5f;
    [SerializeField] float baseFiringRate = 0.2f;
    [Header("AI")]
    [SerializeField] bool useAI;
    [SerializeField] float firingRateVarience = 0f;
    [SerializeField] float minimumFiringRate = 0.1f;
    [SerializeField]
    [HideInInspector]
    public bool isFiring;
    Coroutine FiringCoroutine;
    void Start()
    {
        if (useAI)
        {
            isFiring = true;
        }
    }

    void Update()
    {
        Fire();
    }

    private void Fire()
    {
        if (isFiring && FiringCoroutine == null)
        {
            FiringCoroutine = StartCoroutine(FireContinuosly());
        }
        else if (!isFiring && FiringCoroutine != null)
        {
            StopCoroutine(FiringCoroutine);
            FiringCoroutine = null;
        }
    }

    // 2024-03-23 AI-Tag 
    // This was created with assistance from Muse, a Unity Artificial Intelligence product

    IEnumerator FireContinuosly()
    {
        while (true)
        {
            GameObject instance = Instantiate(ProjectilePreFabs, transform.position, Quaternion.identity);
            Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = transform.up * projectileSpeed;
            }
            Destroy(instance, projectileLifeTime);
            float timeToNextProjectile = Random.Range(baseFiringRate - firingRateVarience, baseFiringRate + firingRateVarience);
            timeToNextProjectile = Mathf.Clamp(timeToNextProjectile, minimumFiringRate, float.MaxValue);
            yield return new WaitForSeconds(timeToNextProjectile);
        }
    }

}
