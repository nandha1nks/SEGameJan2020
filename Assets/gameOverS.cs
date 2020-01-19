using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameOverS : MonoBehaviour
{
    public void nextLevel()
    {
        GameOverScript.goToNextLevel();
    }

    public void restart()
    {
        GameOverScript.restartLevel();
    }
    public void quit()
    {
        GameOverScript.quit();
    }
    public void levelMenu()
    {
        GameOverScript.goToLevelMenu();
    }
}
