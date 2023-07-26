using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverView : MonoBehaviour
{
    [SerializeField] private Button _mainMenuButton;

    private void Start()
    {
        _mainMenuButton.onClick.AddListener(MainMenuButtonPressed);
    }

    private void MainMenuButtonPressed()
    {
        SceneManager.LoadScene(0);
    }
}
