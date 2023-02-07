using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Color _projectileColor;
    [SerializeField] private float _deathTime;
    
    void Start()
    {
        ChangeColor();
        ApplyForce(transform.forward);
    }

    protected void ApplyForce(Vector3 direction)
    {
        _rigidbody.AddForce(direction * _speed, ForceMode.Acceleration);
    }

    protected void ChangeColor()
    {
        gameObject.GetComponent<MeshRenderer>().material.color = _projectileColor;
    }


    protected virtual void OnCollisionEnter(Collision collision)
    {
        StartCoroutine(DestroyProjectile());
    }

    protected IEnumerator DestroyProjectile()
    {
        yield return new WaitForSeconds(_deathTime);
        Destroy(gameObject);
    }
}
