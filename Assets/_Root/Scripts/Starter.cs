using UnityEngine;

public class Starter : MonoBehaviour
{
    [SerializeField] private Canvas _mainMenu;
    [SerializeField] private CharController _charController;
    [SerializeField] private Transform _VRCamera;

    private float _speed;
    private float _sideSpeed;

    private void Start()
    {
        _charController.enabled = false;
        _mainMenu.enabled = true;

        _VRCamera.rotation = Quaternion.identity;
    }
}
