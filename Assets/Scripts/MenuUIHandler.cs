using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

[DefaultExecutionOrder(1000)] //good for UI
public class MenuUIHandler : MonoBehaviour
{

    public TextMeshProUGUI inputName;
    public TextMeshProUGUI bestScoreText;

    /// <summary>
    /// Call up our current best scorer and their score and assign to a text
    /// </summary>
    private void Start()
    {
        bestScoreText.text = "Best Score: " + MenuManager.Instance.highscoreHolder + ": " + MenuManager.Instance.highscore;
    }

    /// <summary>
    /// Use the inputted name in our menu as the username for main scene
    /// </summary>
    public void StartGame()
    {
        //save the inputted name
        MenuManager.Instance.username = inputName.text;
        SceneManager.LoadScene(1);
    }


    /// <summary>
    /// Turn the application off. But before doing that, we save our data for
    /// the next session
    /// </summary>
    public void QuitGame()
    {
        MenuManager.Instance.SaveInfo();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
