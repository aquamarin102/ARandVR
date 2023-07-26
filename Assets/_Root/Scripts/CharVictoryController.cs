using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharVictoryController : MonoBehaviour
{
    [SerializeField] private CharController _charController;
    [SerializeField] private Canvas _victoryCanvas;
    [SerializeField] private Transform _player;
    [SerializeField] private Rigidbody _playerRigidbody;
    [SerializeField] private float _maxDistance;

    private void Update()
    {
        float distance = Vector3.Distance(_player.position, Vector3.zero);
        if (distance >= _maxDistance)
        {
            enabled = false;
            _charController.enabled = false;
            _victoryCanvas.enabled = true;
            _playerRigidbody.velocity = Vector3.zero;
        }
    }
}
