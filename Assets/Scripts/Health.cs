using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering.LookDev;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] bool isPlayer;
    [SerializeField] int score = 50;
    [SerializeField] float health = 50f;
    [SerializeField] ParticleSystem hitEffect;
    [SerializeField] bool applyCameraShake;
    CameraShake cameraShake;

    AudioPlayer audioPlayer;
    ScoreKeeper scoreKeeper;
    LevelManager levelManager;

    public float getHealth()
    {
        return health;
    }


    void Awake()
    {
        cameraShake = Camera.main.GetComponent<CameraShake>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        levelManager = FindObjectOfType<LevelManager>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();
        if (damageDealer != null)
        {
            TakeDamge(damageDealer.GetDamage());
            PlayHitEffect();
            audioPlayer.playDamageClip();
            ShakeCamera();
            damageDealer.Hit();
        }
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    print("heeeeeeeeeeeeee");
    //    DamageDealer damageDealer = other.GetComponent<DamageDealer>();
    //    if (damageDealer != null)
    //    {
    //        TakeDamge(damageDealer.GetDamage());
    //        damageDealer.Hit();
    //    }

    //}

    private void TakeDamge(float damage)
    {
        health -= damage;
        print(health);
        if (health <= 0)
        {

            Die();
        }
    }

    private void Die()
    {
        if (!isPlayer)
        {
            scoreKeeper.modifyScore(score);
        }
        else
        {
            levelManager.LoadGameOver();
        }
        Destroy(gameObject);
        //print(scoreKeeper.GetCurrentScore());

    }

    void PlayHitEffect()
    {
        if (hitEffect != null)
        {
            ParticleSystem instance = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(instance.gameObject, instance.main.duration + 2);
        }
    }

    void ShakeCamera()
    {
        if (cameraShake != null && applyCameraShake)
        {
            cameraShake.Play();
        }
    }

}
