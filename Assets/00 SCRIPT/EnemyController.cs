using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
   
    [SerializeField] float  _speed;

    Rigidbody2D _rb;

    Vector2 _border;

    GunController Gun;

    [SerializeField] GameObject _target;

    Collider2D _coli;
    // Start is called before the first frame update
    void Start()
    {
        _rb = this.GetComponent<Rigidbody2D>();

        Invoke("changeDir", Random.Range(3f,5f));

        _border = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        Gun = this.GetComponentInChildren<GunController>();

        _coli = this.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_target != null)
            Gun.Fire();
        CheckPlayer();
        Vector2 distance =  Camera.main.transform.position - this.transform.position;

        if (Mathf.Abs(distance.x) > _border.x)
        {
            _rb.velocity = distance.normalized * _speed * Time.deltaTime;
            return;
        }

        if (Mathf.Abs(distance.y) > _border.y)
        {
            _rb.velocity = distance.normalized * _speed * Time.deltaTime;
            return;
        }

        _rb.velocity = this.transform.up.normalized * _speed * Time.deltaTime;

    }

    void CheckPlayer()
    {

        RaycastHit2D[] hits = new RaycastHit2D[10];
        Debug.DrawRay(this.transform.position, this.transform.up.normalized *10, Color.red);

        _coli.Cast(this.transform.up.normalized * 1000, hits);

        foreach (RaycastHit2D hit in hits)
        {
            if (hit.collider != null && hit.collider.gameObject.tag.Equals("Player"))
            {
                _target = hit.collider.gameObject;
                return;
            }
        }


        _target = null;
    }

    void changeDir()
    {
        this.transform.rotation = Quaternion.Euler(0,0, this.transform.rotation.eulerAngles.z + Random.Range(0,270));
        Invoke("changeDir", Random.Range(3f, 5f));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("bullet"))
        {
            this.gameObject.SetActive(false);
            collision.gameObject.SetActive(false);
            SoundManager.Instant.PlaySound("sfx_ui_back");
            GameManager.Instant.addScore(1);
        }
    }
}
