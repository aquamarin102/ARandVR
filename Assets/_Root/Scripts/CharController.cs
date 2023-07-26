using UnityEngine;

public class CharController : MonoBehaviour
{
    [SerializeField] private GameObject _camera;
    [SerializeField] public float speed = 6;
    [SerializeField] public float sideSpeed = 2;
    [SerializeField] private float _deadZoneRotation = 10;
    [SerializeField] private Rigidbody _player;

    private void Update()
    {
        Vector3 dir = _player.velocity;

        if (_camera.transform.rotation.eulerAngles.z > _deadZoneRotation && _camera.transform.rotation.eulerAngles.z <= 180)
        {
            dir.x = _camera.transform.rotation.eulerAngles.z * -1 * Time.deltaTime * sideSpeed;
        }

        if (_camera.transform.rotation.eulerAngles.z > 180 && _camera.transform.rotation.eulerAngles.z <= 360 - _deadZoneRotation)
        {
            dir.x = (360 - _camera.transform.rotation.eulerAngles.z) * Time.deltaTime * sideSpeed;
        }

        dir.x = Input.GetAxis("Horizontal") * sideSpeed;

        dir.z = speed;

        _player.velocity = dir;
    }
}
