using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] _obstacles;
    [SerializeField] private float _spawnStep;
    [SerializeField] private float _spawnDistance;
    [SerializeField] private Vector2 _segmentWidth;
    [SerializeField] private Transform _player;

    private Vector3 _lastPos;

    private List<Transform> _spawnedObstacles = new List<Transform>();
    public List<Transform> spawnedObstacles { get { _spawnedObstacles.RemoveAll(TransformIsNull); return _spawnedObstacles; } }

    private bool TransformIsNull(Transform t)
    {
        return t == null;
    }

    private void Start()
    {
        _lastPos = _player.position;
    }

    private void Update()
    {
        if (_player.position.z > _lastPos.z + _spawnStep)
        {
            _lastPos.z += _spawnStep;

            Transform newObstacle = _obstacles[Random.Range(0, _obstacles.Length)];

            _spawnedObstacles.Add(Instantiate(newObstacle, new Vector3(Random.Range(_segmentWidth.x, _segmentWidth.y), 0, _lastPos.z + _spawnDistance), Quaternion.identity));
        }
    }
}
