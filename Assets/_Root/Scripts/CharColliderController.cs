using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharColliderController : MonoBehaviour
{
    [SerializeField] private CharController _charController;
    [SerializeField] private Canvas _gameOverCanvas;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag(TagNames.OBSTACLE))
        {
            _charController.enabled = false;
            _gameOverCanvas.enabled = true;
        }
    }
}
