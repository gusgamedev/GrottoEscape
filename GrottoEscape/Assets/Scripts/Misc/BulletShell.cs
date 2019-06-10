using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShell : MonoBehaviour
{
    private Rigidbody2D _rb;
    [SerializeField] private Vector2 _force;
    [SerializeField] private float _torque;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        if (transform.rotation.y == -1f)
            _force = new Vector2(Random.Range(3f, 6f), Random.Range(5f, 7f));
        else
            _force = new Vector2(Random.Range(-3f, -6f), Random.Range(5f, 7f));

        _torque = Random.Range(2f, 5f);

        _rb.AddForce(_force, ForceMode2D.Impulse);
        _rb.AddTorque(_torque, ForceMode2D.Impulse);

        Destroy(gameObject, 2f);
    }

    

}
