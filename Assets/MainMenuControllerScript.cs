using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MainMenuControllerScript : MonoBehaviour
{
    public Button level2B, level3B, level4B;
    int levelPassed;

    // Start is called before the first frame update
    void Start()
    {
        levelPassed = PlayerPrefs.GetInt("LevelPassed");
        level2B.interactable = false;
        level3B.interactable = false;
        level4B.interactable = false;
        switch (levelPassed)
        {
            case 1:
                level2B.interactable = true;
                break;
            case 2:
                level2B.interactable = true;
                level3B.interactable = true;
                break;
            case 3:
                level2B.interactable = true;
                level3B.interactable = true;
                level4B.interactable = true;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void levelToLoad(int level)
    {
        SceneManager.LoadScene(level);
    }

    public void resetPlayerPrefs()
    {
        level4B.interactable = false;
        level3B.interactable = false;
        level2B.interactable = false;
        PlayerPrefs.DeleteAll();
    }
}
