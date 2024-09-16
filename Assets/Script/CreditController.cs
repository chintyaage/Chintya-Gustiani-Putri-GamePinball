using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Required for Button
using UnityEngine.SceneManagement; // Required for SceneManager

public class CreditController : MonoBehaviour
{
    public Button backButton;

    private void Start()
    {
        backButton.onClick.AddListener(BackButton);
    }

    public void BackButton()
    {
        SceneManager.LoadScene("Main_Menu");
    }
}
