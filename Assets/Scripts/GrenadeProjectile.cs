using UnityEngine;

public class GrenadeProjectile : Projectile
{
    [SerializeField] private float _radius;
    [SerializeField] private Color _gizmosColor;
    private Collider[] _boxesCollidersList;
    [SerializeField] private LayerMask _layersToCheck;
    [SerializeField] private float _explosionForce;
    void Start()
    {
        ChangeColor();
        var gameObjectTransform = transform;
        ApplyForce(gameObjectTransform.forward + gameObjectTransform.up);
    }

    protected override void OnCollisionEnter(Collision collision)
    {
        _boxesCollidersList = Physics.OverlapSphere(transform.position, _radius);
        foreach (var box in _boxesCollidersList)
        {
            if (box.gameObject.layer == LayerMask.NameToLayer("Box"))
            {
                box.gameObject.GetComponent<Rigidbody>()
                    .AddForce((box.transform.position - transform.position).normalized * _explosionForce);
            }
        }
        Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = _gizmosColor;
        Gizmos.DrawSphere(transform.position, _radius);
    }
}
