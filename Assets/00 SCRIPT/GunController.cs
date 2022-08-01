using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] Transform _firePos;
    [SerializeField] GameObject _bulletPrefab;
    [SerializeField] float _atkSpeed = 3;

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
        Instantiate(_bulletPrefab, _firePos.position,
            Quaternion.Euler(0, 0, this.transform.rotation.eulerAngles.z));

        _timerCountdown = _atkSpeed;

        GameManager.Instant.PlaySound();
    }
}
