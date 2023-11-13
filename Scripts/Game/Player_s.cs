using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_s : MonoBehaviour
{
    //プレイヤーに関わることを管理するスクリプト
    bool IsNeedleTouched = false;
    bool IsJumped = false;
    bool IsDebuged = true;

    [SerializeField]SpriteRenderer test;
    // Start is called before the first frame update
    void Start()
    {
        if (test == null)
        {
            IsDebuged = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        DebugMode();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "needle")
        {
            if (IsJumped)
            {
                return;
            }
            IsNeedleTouched = true;
            //Debug.Log("gameover");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "needle")
        {
            IsNeedleTouched = false;
        }
    }

    public bool GetNeedleTouched()
    {
        return IsNeedleTouched;
    }

    public void SetJumped(bool exist)
    {
        IsJumped = exist;
    }

    public void JumpAnim()
    {
        IsJumped = true;
        GetComponent<Animator>().SetTrigger("Jump");
        
    }

    void DebugMode()
    {
        //当たり判定テスト
        if (!IsDebuged)
        {
            return;
        }

        if (IsJumped)
        {
            test.color = new Color(test.color.r, test.color.g, test.color.b, 0);
        }
        else
        {
            test.color = new Color(test.color.r, test.color.g, test.color.b, 100);
        }
    }
}
