using UnityEngine;

public class TennisBallProjectile : Projectile
{

    private void Start()
    {
        ChangeColor();
        ApplyForce(Vector3.up + transform.forward);
    }
}
