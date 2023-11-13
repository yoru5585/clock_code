using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager_s : MonoBehaviour
{
    //時間管理用スクリプト
    GameManager_s gms;
    AudioManager_s ams;

    //BGM変更タイミング、逆回転タイミング
    [SerializeField] float[] TimeInterval_change;
    [SerializeField] float TimeInterval_reverse;
    float TimeCount_change;
    float TimeCount_reverse;

    int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        gms = GetComponent<GameManager_s>();
        ams = GameObject.Find("AudioManager").GetComponent<AudioManager_s>();
    }

    // Update is called once per frame
    void Update()
    {
        TimeCount_reverse += Time.deltaTime;
        TimeCount_change += Time.deltaTime;

        if (TimeCount_reverse > TimeInterval_reverse)
        {
            TimeCount_reverse = 0;
            gms.OnHandAnim();
        }

        if (index > 2)
        {
            if (index == 3)
            {
                gms.OnClockDestroy();
                FadeManager.Instance.LoadScene("ClearScene", 1.0f);
                index = 4;
            }
            return;
        }

        if (TimeCount_change > TimeInterval_change[index])
        {
            TimeCount_change = 0;
            ams.PlayBGM(index + 1);
            index++;
        }
    }
}
