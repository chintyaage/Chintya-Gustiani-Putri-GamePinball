using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUiController : MonoBehaviour
{
    public Button playButton;
    public Button exitButton;
    public Button creditButton;

    private void Start()
    {
        playButton.onClick.AddListener(PlayGame);
        exitButton.onClick.AddListener(ExitGame);
        creditButton.onClick.AddListener(CreditGame);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Pinball");
    }

    private void ExitGame()
    {
        Application.Quit();
    }

    private void CreditGame()
    {
        SceneManager.LoadScene("Credit");
    }
}