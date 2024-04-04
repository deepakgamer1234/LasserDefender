using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIDisplay : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] Slider slider;
    [SerializeField] Health playerHealth;

    [Header("Score")]
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper scoreKeeper;

    private void Awake()
    {
        scoreKeeper = FindAnyObjectByType<ScoreKeeper>();   
    }

    void Start()
    {
        slider.maxValue = playerHealth.getHealth();
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = playerHealth.getHealth();
        scoreText.text = scoreKeeper.GetCurrentScore().ToString("00000000000");
    }
}
