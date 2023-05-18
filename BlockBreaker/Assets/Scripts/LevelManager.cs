using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void LoadLevel(string name)
    {
        Debug.Log($"«апрошена загрузка уровн€ дл€ {name}");
        Brick.breakableCount = 0;
        SceneManager.LoadScene(name);
    }
    public void QuitRequest()
    {
        Debug.Log($"я хочу выйти");
        Application.Quit();
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("Start");
    }
    public void LoadNextLevel()
    {
        Brick.breakableCount = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void BrickDestroyed()
    {
        if (Brick.breakableCount <= 0)
        {
            LoadNextLevel();
        }
    }
}
