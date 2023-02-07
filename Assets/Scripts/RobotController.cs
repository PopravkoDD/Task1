using UnityEngine;

public class RobotController : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _roationSpeed;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private GameObject[] _projectiles;
    [SerializeField] private int _projectilesIndex;
    [SerializeField] private bool _canShoot;
    private Vector2 _movementDirection;
    public bool CanShoot
    {
        set => _canShoot = value;
    }

    public int ProjectileIndex
    {
        set
        {
            if (value >= 0 && value < _projectiles.Length)
            {
                _projectilesIndex = value;
            }
        }
    }



    void Update()
    {
        if (Input.GetAxis("Vertical") != 0)
        {
            _rigidbody.velocity = transform.right * (_movementSpeed * Input.GetAxis("Vertical"));
        }

        if (Input.GetAxis("Horizontal") != 0)
        {
            _rigidbody.angularVelocity = new Vector3(0f, Input.GetAxis("Horizontal") * _roationSpeed, 0f);
        }

        if (Input.GetKeyDown(KeyCode.Space) && _canShoot)
        {
            Instantiate(_projectiles[_projectilesIndex], _spawnPoint.position, _spawnPoint.rotation);
        }
    }
}
