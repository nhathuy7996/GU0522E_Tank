using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BulletPooling : Singleton<BulletPooling>
{
    List<GameObject> bullets_pool = new List<GameObject>();
    [SerializeField] GameObject bulletPrefab;

    List<GameObject> enemy_pool = new List<GameObject>();
    [SerializeField] GameObject enemyPrefab;

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


    public int countExistEnemy()
    {

        return enemy_pool.Where(g =>
        {
            return g.activeSelf;
        }).Count();

        //int eCount = 0;
        //foreach (GameObject g in enemy_pool)
        //{
        //    if (g.activeSelf)
        //        eCount++;

        //}

        //return eCount;
    }

    public GameObject getEnemy()
    {
        foreach (GameObject g in enemy_pool)
        {
            if (g.activeSelf)
                continue;

            return g;
        }

        GameObject g2 = Instantiate(enemyPrefab, this.transform.position, Quaternion.identity);
        enemy_pool.Add(g2);

        g2.SetActive(false);

        return g2;
    }
}
