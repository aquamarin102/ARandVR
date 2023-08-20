using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameButtonController : MonoBehaviour
{
    private GameMode _gameMode;
    [SerializeField] TMP_Text _gameModeLabel;

    [SerializeField] GameObject _GP_Hammer;
    [SerializeField] GameObject _GP_Swordman;
    [SerializeField] GameObject _MA_Hammer;
    [SerializeField] GameObject _MA_Swordman;

    public void SetGameMode(GameMode newGameMode)
    {
        _gameMode = newGameMode;
        UpdateGameModeLabel();
    }

    private void UpdateGameModeLabel()
    {
        switch (_gameMode)
        {
            case GameMode.GroundPlane:
                _gameModeLabel.text = "Ground Plane";
                break;
            case GameMode.MidAir:
                _gameModeLabel.text = "Mid Air";
                break;
            default:
                _gameModeLabel.text = "";
                break;
        }
    }

    public void HammerButtonPressed()
    {
        switch (_gameMode)
        {
            case GameMode.GroundPlane:
                _GP_Hammer.SetActive(true);
                _MA_Hammer.SetActive(false);
                break;
            case GameMode.MidAir:
                _GP_Hammer.SetActive(false);
                _MA_Hammer.SetActive(true);
                break;
        }
    }

    public void SwordmanButtonPressed()
    {
        switch (_gameMode)
        {
            case GameMode.GroundPlane:
                _GP_Swordman.SetActive(true);
                _MA_Swordman.SetActive(false);
                break;
            case GameMode.MidAir:
                _GP_Swordman.SetActive(false);
                _MA_Swordman.SetActive(true);
                break;
        }
    }
}

public enum GameMode
{
    GroundPlane,
    MidAir
}