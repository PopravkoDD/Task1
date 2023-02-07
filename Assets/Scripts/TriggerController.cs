using System;
using UnityEngine;

public class TriggerController : MonoBehaviour
{
    [SerializeField] private int _projectileIndex;
    [SerializeField] private LayerMask layerToTrigger;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer != LayerMask.NameToLayer("Robot"))
        {
            return;
        }
        
        var robotController = other.gameObject.GetComponent<RobotController>();
        robotController.ProjectileIndex = _projectileIndex;
        robotController.CanShoot = true;
        Debug.Log("Can Shoot");
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer != LayerMask.NameToLayer("Robot"))
        {
            return;
        }

        other.gameObject.GetComponent<RobotController>().CanShoot = false;
        
        Debug.Log("Cant Shoot");
    }
}
