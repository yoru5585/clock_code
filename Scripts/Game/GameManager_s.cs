using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager_s : MonoBehaviour
{
    //ゲームシステムを管理するスクリプト
    Slider HPSlider;
    Controller_s cont;
    AudioManager_s ams;
    Player_s player;
    Animator HandAnim;

    [SerializeField] float damage;
    bool IsReverse;

    // Start is called before the first frame update
    void Start()
    {
        ams = GameObject.Find("AudioManager").GetComponent<AudioManager_s>();
        ams.PlayBGM(0);

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_s>();
        HandAnim = GameObject.Find("Hand").GetComponent<Animator>();
        HPSlider = GameObject.Find("HPSlider").GetComponent<Slider>();
        cont = GetComponent<Controller_s>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckState();

        if (cont.GetSpacePressed())
        {
            player.JumpAnim();
            ams.PlaySE(1);
        }

        if (cont.GetEscasePressed())
        {
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
        }


        if (player.GetNeedleTouched())
        {
            HPSlider.value -= damage * Time.deltaTime; 
        }

        if (IsReverse)
        {
            OnReverse();
            ams.OnReverseBGM();
        }
    }

    void CheckState()
    {
        if (HPSlider.value <= 0)
        {
            FadeManager.Instance.LoadScene("GameoverScene", 1.0f);
            HPSlider.value = 10f;
            return;
        }
    }

    public void OnHandAnim()
    {
        HandAnim.SetTrigger("HandFirst");
        HandAnim.GetBehaviour<HandMove_s>().num = Random.Range(3,5);
    }

    public void SetReverse(bool exist)
    {
        IsReverse = exist;
    }

    void OnReverse()
    {
        GameObject[] tmp =  GameObject.FindGameObjectsWithTag("needle");
        foreach (GameObject obj in tmp)
        {
            obj.transform.parent.gameObject.GetComponent<Rotate_s>().ChangeDir();
        }
        IsReverse = false;
    }

    public void OnClockDestroy()
    {
        GameObject[] tmp = GameObject.FindGameObjectsWithTag("needle");
        foreach (GameObject obj in tmp)
        {
            obj.transform.parent.gameObject.GetComponent<Animator>().SetTrigger("destroy");
        }
    }
}
