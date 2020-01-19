using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public static class GameOverScript
{
    public static int level;

    public static void restartLevel()
    {
        SceneManager.LoadScene(level);
    }

    public static void goToNextLevel()
    {
        SceneManager.LoadScene(level + 1);
    }

    public static void goToLevelMenu()
    {
        SceneManager.LoadScene(0);
    }

    public static void quit()
    {
        Application.Quit();
    }
}
