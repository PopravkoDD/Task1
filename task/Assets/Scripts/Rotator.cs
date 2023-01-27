using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private float _speed;

    void Update()
    {
         gameObject.transform.Rotate(0, _speed * Time.deltaTime, 0);
    }
}
