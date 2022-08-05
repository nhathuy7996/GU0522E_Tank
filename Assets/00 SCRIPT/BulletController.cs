using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] float _timeDestroy = 10, _speed;

    Rigidbody2D _rb;

    Coroutine autoDestructCor;
    // Start is called before the first frame update
    void Start()
    {
       
        _rb = this.GetComponent<Rigidbody2D>();

    }

    private void OnEnable()
    {
        autoDestructCor = StartCoroutine(autoDestruct());
    }

    private void OnDisable()
    {
        StopCoroutine(autoDestructCor);
    }

    // Update is called once per frame
    void Update()
    {
        _rb.velocity = this.transform.up.normalized * _speed * Time.deltaTime;
    }

    IEnumerator autoDestruct()
    {
        yield return new WaitForSeconds(_timeDestroy);
        this.gameObject.SetActive(false);
    }
}
