using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_s : MonoBehaviour
{
    //キー入力を管理するスクリプト
    bool IsSpacePressed = false;
    bool IsEscapePressed = false;
    void Start()
    {
        
    }

    void Update()
    {
        //スペースキー
        if (Input.GetKeyDown(KeyCode.Space))
        {
            IsSpacePressed = true;
        }
        else
        {
            IsSpacePressed = false;
        }

        //エスケープキー
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
