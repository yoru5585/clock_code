using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager_s : MonoBehaviour
{
    AudioSource myAudio;
    List<AudioClip> SE_data = new List<AudioClip>();
    List<AudioClip> BGM_data = new List<AudioClip>();
    int index = 1;

    [SerializeField] AudioMixer audioMixer;

    private void Awake()
    {
        LoadData();
        OnChangeVolume();
    }

    void LoadData()
    {
        BGM_data.Clear();
        SE_data.Clear();

        AudioClip[] tmp0 = Resources.LoadAll<AudioClip>("Sounds/BGM");
        AudioClip[] tmp1 = Resources.LoadAll<AudioClip>("Sounds/SE");
        foreach (AudioClip data in tmp0)
        {
            BGM_data.Add(data);
            Debug.Log(data);
        }

        foreach (AudioClip data in tmp1)
        {
            SE_data.Add(data);
            Debug.Log(data);
        }


    }

    public void PlayBGM(int num)
    {
        myAudio = transform.GetChild(0).gameObject.GetComponent<AudioSource>();
        myAudio.clip = BGM_data[num];
        myAudio.Play();
    }

    public void PlaySE(int num)
    {
        if (index > 3)
        {
            index = 1;
        }
        myAudio = transform.GetChild(index++).gameObject.GetComponent<AudioSource>();
        myAudio.PlayOneShot(SE_data[num]);
    }

    public void OnReverseBGM()
    {
        myAudio = transform.GetChild(0).gameObject.GetComponent<AudioSource>();
        myAudio.pitch *= -1;
    }

    public void OnChangeVolume(float BGM_volume = 0, float SE_volume = 0)
    {
        //transform.GetChild(0).gameObject.GetComponent<AudioSource>().volume = BGM_volume;
        //for (int i = 1; i < 4; i++)
        //{
        //    transform.GetChild(i).gameObject.GetComponent<AudioSource>().volume = SE_volume;
        //}

        audioMixer.SetFloat("BGMVol", BGM_volume);
        audioMixer.SetFloat("SEVol", SE_volume);
        Debug.Log("changeVolume");
    }
}
