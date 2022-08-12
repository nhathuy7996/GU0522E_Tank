using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] Transform _firePos;
    [SerializeField] GunData _data;

    [SerializeField]
    float _timerCountdown = 0;
    // Start is called before the first frame update
    void Start()
    {   
    }
    // Update is called once per frame
    void Update()
    {
        _timerCountdown -= Time.deltaTime;
    }

    public void Fire()
    {
        if (_timerCountdown > 0)
            return;

        //Debug.Log(this.transform.localRotation.z);
        SoundManager.Instant.PlaySound("sfx_ui_click");
        GameObject g = BulletPooling.Instant.getBullet();
        g.transform.position = _firePos.position;
        g.transform.rotation = Quaternion.Euler(0, 0, this.transform.rotation.eulerAngles.z);
        g.SetActive(true);

        _timerCountdown = _data.AtkSpeed;

       
    }
}
