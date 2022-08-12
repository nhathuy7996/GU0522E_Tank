using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D _rb;
    Vector2 _movement;
    [SerializeField] float _speed => DataManager.Instant.movingSpeed;
    [SerializeField] Transform _rotate_object;

    [SerializeField] GameObject obj;

    [SerializeField]
    GunController Gun;

    // Start is called before the first frame update
    void Start()
    {
        _rb = this.GetComponent<Rigidbody2D>();
        Gun = this.GetComponentInChildren<GunController>();
    }

    // Update is called once per frame
    void Update()
    {

        Moving();
        Look();

        if (Input.GetKey(KeyCode.Space))
        {
            Gun.Fire();
           
        }
           
    }

    void Moving()
    {
        //_movement.x = Input.GetAxisRaw("Horizontal") * _speed;
        //_movement.y = Input.GetAxisRaw("Vertical") * _speed;

        //_rb.velocity = _movement * Time.deltaTime;

        _rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")) * _speed * Time.deltaTime;
    }

    void Look()
    {
        Vector2 mouse_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 dir = mouse_pos - (Vector2)this.transform.position;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        _rotate_object.transform.rotation = Quaternion.Euler(0,0,angle - 90);
    }
}
