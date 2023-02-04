using UnityEngine;
using UnityEngine.UI;

public class RotatorController : MonoBehaviour
{
    [SerializeField] private Transform _backPoint;
    [SerializeField] private Transform _facePoint;
    [SerializeField] private Transform _upPoint;
    [SerializeField] private Transform _downPoint;
    [SerializeField] private Transform _miniCameraTransform;
    [SerializeField] private Button _backButton;
    [SerializeField] private Button _faceButton;
    [SerializeField] private Button _upButton;
    [SerializeField] private Button _downButton;
    [SerializeField] private float _rotationSpeedMultiplier;
    private Touch _touch;
    
    void Start()
    {
        _backButton.onClick.AddListener(delegate { PlaceCamera(_backPoint); });
        _faceButton.onClick.AddListener(delegate { PlaceCamera(_facePoint); });
        _upButton.onClick.AddListener(delegate { PlaceCamera(_upPoint); });
        _downButton.onClick.AddListener(delegate { PlaceCamera(_downPoint); });;
    }

    void Update()
    {
        if (Input.touchCount == 1)
        {
            _touch = Input.GetTouch(0);
            if (_touch.phase == TouchPhase.Moved)
            {
               gameObject.transform.Rotate(0, -_touch.deltaPosition.x * Time.deltaTime * _rotationSpeedMultiplier, 0);
            }
        }
    }

    private void PlaceCamera(Transform transform)
    {
        _miniCameraTransform.position = transform.position;
        _miniCameraTransform.rotation = transform.rotation;
    }
}
