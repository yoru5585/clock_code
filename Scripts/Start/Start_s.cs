using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Start_s : MonoBehaviour
{
    AudioManager_s ams;
    Controller_s cont;
    Slider BGMSlider;
    Slider SESlider;
    [SerializeField] Animator playerAnim;
    [SerializeField] GameObject tutorialObj;
    // Start is called before the first frame update
    void Start()
    {
        ams = GameObject.Find("AudioManager").GetComponent<AudioManager_s>();
        cont = GetComponent<Controller_s>();
        ams.PlayBGM(5);
        BGMSlider = GameObject.Find("BGMSlider").GetComponent<Slider>();
        SESlider = GameObject.Find("SESlider").GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cont.GetSpacePressed() && tutorialObj.activeSelf)
        {
            playerAnim.SetTrigger("Jump");
        }

        if (cont.GetEscasePressed())
        {
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
        }
    }

    public void OnStartButtonClicked()
    {
        //ÉVÅ[Éìà⁄ìÆ
        FadeManager.Instance.LoadScene("GameScene", 1.0f);
        ams.PlaySE(2);
    }

    public void OnTutorialButtonClicked()
    {
        if (tutorialObj.activeSelf)
        {
            tutorialObj.SetActive(false);
        }
        else
        {
            tutorialObj.SetActive(true);
        }
    }

    public void OnExitButtonClicked()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                    Application.Quit();
        #endif
    }

    public void OnValueChanged()
    {
        ams.OnChangeVolume(BGMSlider.value, SESlider.value);
        Debug.Log("SliderVolume");
    }
}
