using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameover_s : MonoBehaviour
{
    AudioManager_s ams;
    // Start is called before the first frame update
    void Start()
    {
        ams = GameObject.Find("AudioManager").GetComponent<AudioManager_s>();
        ams.PlayBGM(4);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            FadeManager.Instance.LoadScene("StartScene", 1.0f);
        }
    }
}
