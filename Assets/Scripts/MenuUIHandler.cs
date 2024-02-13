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

    private void Start()
    {
        bestScoreText.text = "Best Score: " + MenuManager.Instance.highscoreHolder + ": " + MenuManager.Instance.highscore;
    }

    public void StartGame()
    {
        //save the inputted name
        MenuManager.Instance.username = inputName.text;
        SceneManager.LoadScene(1);
    }

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
