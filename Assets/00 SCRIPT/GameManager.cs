using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{

    private static GameManager _Instant;

    public static GameManager Instant => _Instant;

    [SerializeField] SoundManager SoundManager;

    [SerializeField] PlayerController player;

    private void Awake()
    {
        _Instant = this;
    }

    [SerializeField] GameObject _enemyPrefab;
    [SerializeField] Text score_text;

    Vector2 _border;

    [SerializeField]
    int _score = 0;


    float timeCountdown = 0;

    int enemyCount = 0;

    Coroutine coroutineSpawE;


    //public void PlaySound()
    //{
    //    SoundManager.PlaySound();
    //}

    public Vector2 getPlayerPos()
    {
        return player.transform.position;
    }

    // Start is called before the first frame update
    void Start()
    {
        //Invoke("spawnEnemy", Random.Range(2f, 2.1f));

        _border = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        //coroutineSpawE = StartCoroutine(_spawEnemy());

        // StopCoroutine(coroutineSpawE);
        _score = PlayerPrefs.GetInt(CONSTANT.SCORE);
    }

    // Update is called once per frame
    void Update()
    {
        score_text.text = "Score: "+ _score.ToString();
        if (BulletPooling.Instant.countExistEnemy() > 3)
            return;
        timeCountdown -= Time.deltaTime;

        if (timeCountdown <= 0)
        {
            spawnEnemy();
            timeCountdown = Random.Range(2, 2.1f);
           
        }

    }

    void spawnEnemy()
    {
        Vector2 pos = new Vector2(
           Random.Range(-_border.x, _border.x),
           Random.Range(-_border.y, _border.y)
           );

        GameObject e = BulletPooling.Instant.getEnemy();
        e.transform.position = pos;
        e.SetActive(true);
    }

    public void addScore(int score)
    {
        if (score < 0)
            score = 0;
        this._score += score;
        PlayerPrefs.SetInt(CONSTANT.SCORE, this._score);
    }

    IEnumerator _spawEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(5f,10f));
            Vector2 pos = new Vector2(
              Random.Range(-_border.x, _border.x),
              Random.Range(-_border.y, _border.y)
              );
            GameObject e = BulletPooling.Instant.getEnemy();
            e.transform.position = pos;
            e.SetActive(true);
        }
    }
}
