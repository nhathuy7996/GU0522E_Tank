using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;

public class DataManager : Singleton<DataManager>
{

    float _atkSpeed = 3;
    public float atkSpeed => _atkSpeed;

    float _movingSpeed = 3;
    public float movingSpeed => _movingSpeed;

    // Start is called before the first frame update
    void Start()
    {
        //lấy dữ liệu về

        StartCoroutine(GetRequest("https://gu0522e-json-default-rtdb.asia-southeast1.firebasedatabase.app/.json"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {

            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(": Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError( ": HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    this.parseData(webRequest.downloadHandler.text);
                    break;
            }
        }
    }


    void parseData(string jsonData)
    {
        var dataParsed = JSON.Parse(jsonData);

        _atkSpeed = dataParsed[CONSTANT.AtkSpeedKey].AsFloat;

       _movingSpeed = dataParsed[CONSTANT.MovingSpeedKey].AsFloat;
    }
}
