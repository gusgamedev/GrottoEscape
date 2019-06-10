using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;
    
    // Update is called once per frame
    void Update()
    {
        if (_target != null)
            transform.position = new Vector3(_target.position.x, _target.position.y, transform.position.z);
    }
}
