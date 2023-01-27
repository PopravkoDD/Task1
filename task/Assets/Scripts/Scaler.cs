using UnityEngine;
using UnityEngine.Serialization;

public class Scaler : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Vector3 _startScale;
    [SerializeField] private Vector3 targetScale;
    [SerializeField] [Range(0, 1)] private float _lerpMultiplier;

    private void Start()
    {
        _startScale = gameObject.transform.localScale;
    }

    void Update()
    {
        gameObject.transform.localScale = Vector3.Lerp(_startScale, targetScale, _lerpMultiplier);
        _lerpMultiplier += _speed * Time.deltaTime;

        if (_lerpMultiplier > 1 || _lerpMultiplier < 0)
        {
            _speed *= -1;
        }
    }
}
