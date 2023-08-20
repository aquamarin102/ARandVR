using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenuController : MonoBehaviour
{
    [SerializeField] GameButtonController _gameButtonController;

    public void GroundPlanePressed()
    {
        gameObject.SetActive(false);
        _gameButtonController.SetGameMode(GameMode.GroundPlane);
        _gameButtonController.gameObject.SetActive(true);
    }

    public void MidAirPressed()
    {
        gameObject.SetActive(false);
        _gameButtonController.SetGameMode(GameMode.MidAir);
        _gameButtonController.gameObject.SetActive(true);
    }
}
