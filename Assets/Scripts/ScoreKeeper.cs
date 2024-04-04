using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    // Start is called before the first frame update
    float currentScore;

    public float GetCurrentScore() { return currentScore; }

    public void ResetScore()
    {
        currentScore = 0;
    }

    public void modifyScore(int value)
    {
        currentScore += value;
        Mathf.Clamp(currentScore, 0, int.MaxValue);
        print(currentScore);
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
