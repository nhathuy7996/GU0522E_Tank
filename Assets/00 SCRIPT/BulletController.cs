using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] float _timeDestroy = 10, _speed;

    Rigidbody2D _rb;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, _timeDestroy);
        _rb = this.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        _rb.velocity = this.transform.up.normalized * _speed * Time.deltaTime;
    }
}
