using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] int loadDelay;

    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu 1");
    }

    public void LoadGameOver()
    {
        //SceneManager.LoadScene("GameOver");
        StartCoroutine(waitAndLoad("GameOver", 5));
    } 
    public void QuitGame()
    {
        print("Quiting the game...");
        Application.Quit();
    }

    IEnumerator waitAndLoad(string sceneName,int delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}
