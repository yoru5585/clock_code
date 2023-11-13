using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_s : MonoBehaviour
{
    //�L�[���͂��Ǘ�����X�N���v�g
    bool IsSpacePressed = false;
    bool IsEscapePressed = false;
    void Start()
    {
        
    }

    void Update()
    {
        //�X�y�[�X�L�[
        if (Input.GetKeyDown(KeyCode.Space))
        {
            IsSpacePressed = true;
        }
        else
        {
            IsSpacePressed = false;
        }

        //�G�X�P�[�v�L�[
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            IsEscapePressed = true;
        }
        else
        {
            IsEscapePressed = false;
        }
    }

    public bool GetSpacePressed()
    {
        return IsSpacePressed;
    }

    public bool GetEscasePressed()
    {
        return IsEscapePressed;
    }
}
