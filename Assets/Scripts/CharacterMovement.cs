using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class CharacterMovement : MonoBehaviour
{
    [Header("Require second key fragment to be the top of the jump")]
    [SerializeField] private AnimationCurve jumpAnimation;
    
    [SerializeField] private float _currentGravity;
    [SerializeField] private float _speed;
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private Button _jumpButton;
    [SerializeField] private Transform _cameraTransform;
    [SerializeField] private float _sensitivity;
    private Touch[] _touches;
    private Vector2 startPoint;

    [SerializeField] private SimpleTouchController _joystick;
    private void Start()
    {
        _currentGravity = -jumpAnimation.keys[0].value;
        _jumpButton.onClick.AddListener(StartJump);

    }

    void Update()
    {
        var movement = new Vector3(_joystick.GetTouchPosition.x * _speed, _currentGravity,
            _joystick.GetTouchPosition.y * _speed);
        _characterController.Move(transform.TransformDirection(movement) * Time.deltaTime);

        if (Input.touchCount > 0)
        {
            _touches = Input.touches;

            if (Input.touchCount == 1 && _touches[0].phase == TouchPhase.Moved &&
                _touches[0].position.x > Screen.width / 4) //how to get screen coordinates of ui elements???
            {
                
                if (-_touches[0].deltaPosition.y * _sensitivity + _cameraTransform.eulerAngles.x >= 271 || //?????
                    -_touches[0].deltaPosition.y * _sensitivity + _cameraTransform.eulerAngles.x <= 89)
                {
                    _cameraTransform.Rotate(-_touches[0].deltaPosition.y * _sensitivity, 0 , 0);
                }
                transform.Rotate(0, _touches[0].deltaPosition.x * _sensitivity, 0);
            }
            else if (Input.touchCount == 2 && _touches[1].phase == TouchPhase.Moved &&
                     _touches[1].position.x > Screen.width / 4) 
            {
                {
                    _cameraTransform.Rotate(-_touches[1].deltaPosition.y * _sensitivity, 0 , 0);
                }
                transform.Rotate(0, _touches[1].deltaPosition.x * _sensitivity, 0);
            }
        }
    }

    private IEnumerator Jump()
    {
        var animationTime = 0f;
        do
        {
            if ((_characterController.collisionFlags & CollisionFlags.Above) != 0)
            {
                animationTime = jumpAnimation.keys[1].time;
                break;
            }

            animationTime = ApplyGravity(animationTime);
            yield return null;
        } while (animationTime <= jumpAnimation.keys[1].time);

        do
        {
            if (_characterController.isGrounded)
            {
                Debug.Log("Ended");
                _currentGravity = -jumpAnimation.keys[0].value;
                yield break;
            }
            
            animationTime = ApplyGravity(animationTime);

            yield return null;
        } while (animationTime <= jumpAnimation.keys[^1].time);

        Debug.Log("Ended");
        _currentGravity = jumpAnimation.keys[^1].value;

    }

    private float ApplyGravity(float time)
    {
        _currentGravity = jumpAnimation.Evaluate(time);
        time += Time.deltaTime;
        return time;
    }

    private void StartJump()
    {
        if (_characterController.isGrounded)
        {
            StartCoroutine(Jump());
        }
    }
}