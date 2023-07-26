using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MainMenuView : MonoBehaviour
{
    [SerializeField] private Button _startVRButton;
    [SerializeField] private Button _startNormalButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private Canvas _mainMenuCanvas;
    [SerializeField] private GameObject _VRCameraGameObject;
    [SerializeField] private GameObject _NormalCameraGameObject;
    [SerializeField] private CharController _charConrtoller;
    [SerializeField] private Camera _VRCamera;
    [SerializeField] private Camera _NormalCamera;

    private void Start()
    {
        _startVRButton.onClick.AddListener(StartVRButtonPressed);
        _startNormalButton.onClick.AddListener(StartNormalButtonPressed);
        _exitButton.onClick.AddListener(ExitButtonPressed);
    }
    
    private void ChangeUICamera(Camera newCamera)
    {
        Canvas[] canvases = FindObjectsOfType<Canvas>();
        foreach (Canvas canvas in canvases)
        {
            canvas.worldCamera = newCamera;
        }
    }

    private void Set_VR_EventSystem()
    {
        FindObjectOfType<StandaloneInputModule>().enabled = false;
        FindObjectOfType<VRInputModule>().enabled = true;
    }

    private void Set_Normal_EventSystem()
    {
        FindObjectOfType<VRInputModule>().enabled = false;
        FindObjectOfType<StandaloneInputModule>().enabled = true;
    }

    private void StartVRButtonPressed()
    {
        _mainMenuCanvas.enabled = false;
        _VRCameraGameObject.SetActive(true);
        _NormalCameraGameObject.SetActive(false);
        _charConrtoller.enabled = true;

        FibUIAppearScript vrSetup = FindObjectOfType<FibUIAppearScript>();
        vrSetup.enabled = true;

        ChangeUICamera(_VRCamera);
        Set_VR_EventSystem();
    }

    private void StartNormalButtonPressed()
    {
        _mainMenuCanvas.enabled = false;
        _VRCameraGameObject.SetActive(false);
        _NormalCameraGameObject.SetActive(true);
        _charConrtoller.enabled = true;

        FibUIAppearScript vrSetup = FindObjectOfType<FibUIAppearScript>();
        vrSetup.enabled = false;

        ChangeUICamera(_NormalCamera);
        Set_Normal_EventSystem();
    }

    private void ExitButtonPressed()
    {
        Application.Quit();
    }
}
