using UnityEngine;
using UnityEngine.Serialization;

public class PingPongController : MonoBehaviour
{
    [SerializeField] private Transform _endPoint;
    private Vector3 _tempPoint;
    [SerializeField] private float _speed;
    [SerializeField] private float _endPointOffset;

    void Start()
    {
        _tempPoint = gameObject.transform.position;
    }

    void Update()
    {
        var currentPosition = gameObject.transform.position;
        
        gameObject.transform.position = Vector3.MoveTowards(currentPosition, _endPoint.position, _speed * Time.deltaTime);
        
        if ((currentPosition - _endPoint.position).magnitude < _endPointOffset)
        {
            SwapEndPoints();
        }
    }

    private void SwapEndPoints()
    {
        var temp= _tempPoint;
        _tempPoint = _endPoint.position;
        _endPoint.position = temp;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawSphere(_endPoint.position, 0.1f);
    }
}
