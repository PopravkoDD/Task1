using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] private float _timeBetweenTeleports;
    [SerializeField] private float _teleportOffset;
    private Vector3 _startPoint;
    [SerializeField] private bool _canTeleport;
    
    void Start()
    {
        _startPoint = gameObject.transform.position;
        StartCoroutine(Teleport());
    }

    private IEnumerator Teleport()
    {
        while (_canTeleport)
        {
            yield return new WaitForSeconds(_timeBetweenTeleports);
            var endPoint = new Vector3(Random.Range(_startPoint.x - _teleportOffset, _startPoint.x + _teleportOffset), 0, Random.Range(_startPoint.y - _teleportOffset, _startPoint.y + _teleportOffset));
            gameObject.transform.position = endPoint;
        }
    }
}
