using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPooling : Singleton<BulletPooling>
{
    List<GameObject> bullets_pool = new List<GameObject>();
    [SerializeField] GameObject bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject getBullet()
    {
        foreach (GameObject g in bullets_pool)
        {
            if (g.activeSelf)
                continue;

            return g;
        }

        GameObject g2 = Instantiate(bulletPrefab, this.transform.position, Quaternion.identity);

        bullets_pool.Add(g2);

        return g2;
    }
}
