using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Inventory : MonoBehaviour, IHasChanged
{
    [SerializeField] Transform slots;
    [SerializeField] Text inventoryText;
    [SerializeField] int m;
    [SerializeField] int n;
    [SerializeField] int noInputs;
    [SerializeField] int inputDirection;
    [SerializeField] int noOutputs;
    [SerializeField] int outputDirection;
    [SerializeField] int level;

    void start()
    {
        HasChanged();
    }
    public void HasChanged()
    {
        System.Text.StringBuilder builder = new System.Text.StringBuilder();
        builder.Append("0-");
        int i = 0, itemToBeChecked = 0, input = noInputs, lastDirection = inputDirection, lastItem = 0;
        foreach (Transform slotTransform in slots)
        {
            if(i == itemToBeChecked)
            {
                if (slotTransform.childCount > 0)
                {
                    Transform item = slotTransform.GetChild(0);
                    if (item.tag[0] - 48 == input)
                    {
                        if (item.tag[1] == 'C')
                        {
                            input = 1;
                            if (item.tag[2] == 'x')
                            {
                                lastDirection = 0;
                                lastItem = itemToBeChecked; itemToBeChecked += 1;
                            }
                            else
                            {
                                lastDirection = 1;
                                lastItem = itemToBeChecked; itemToBeChecked += n;
                            }
                        }
                        else if (item.tag[1] == 'Q')
                        {
                            input = 2;
                            if (item.tag[2] == 'x')
                            {
                                lastDirection = 0;
                                lastItem = itemToBeChecked; itemToBeChecked += 1;
                            }
                            else
                            {
                                lastDirection = 1;
                                lastItem = itemToBeChecked; itemToBeChecked += n;
                            }
                        }
                        else if (item.tag[1] == 'D')
                        {
                            input = 1;
                            lastDirection = 2;
                            lastItem = itemToBeChecked; itemToBeChecked += n + 1;
                        }
                    }
                    else if (item.tag == "Block")
                    {
                        input = 1;
                        if (lastDirection == 0)
                        {
                            lastItem = itemToBeChecked; itemToBeChecked += 1;
                        }
                        else if (lastDirection == 1)
                        {
                            lastItem = itemToBeChecked; itemToBeChecked += n;
                        }
                        else if (lastDirection == 2)
                        {
                            lastItem = itemToBeChecked; itemToBeChecked += n + 1;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    if (lastDirection == 0)
                    { lastItem = itemToBeChecked; itemToBeChecked += 1; }
                    else if (lastDirection == 1)
                    { lastItem = itemToBeChecked; itemToBeChecked += n; }
                    else if (lastDirection == 2)
                    {   lastItem = itemToBeChecked; itemToBeChecked += n + 1;
                }
                }
                builder.Append(itemToBeChecked);
                builder.Append("-");
                
            }
            i += 1;
        }
        builder.Append("\nNumber of Outputs = ");
        builder.Append(input);
        builder.Append("\nDirection is ");
        if (lastDirection == 0)
        {
            builder.Append("horizontal");
        }
        else if (lastDirection == 1)
        {
            builder.Append("vertical");

        }
        else if (lastDirection == 2)
        {
            builder.Append("diagonal");
        }
        inventoryText.text = builder.ToString();
        if(lastItem == m*n-1 && input == noOutputs && lastDirection == outputDirection)
        {
            GameOverScript.level = level;
            SceneManager.LoadScene(5);
            PlayerPrefs.SetInt("LevelPassed",level);
        }
    }

    public void levelMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void restart()
    {
        SceneManager.LoadScene(level);
    }

    public void quit()
    {
        Application.Quit();
    }
}

namespace UnityEngine.EventSystems
{
    public interface IHasChanged : IEventSystemHandler
    {
        void HasChanged();
    }
}