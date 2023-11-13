using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDes_s : MonoBehaviour
{
    //ゲーム全体で影響するオブジェクトを管理するスクリプト
    //シングルトン
    public static DontDes_s instance;
    //生成するprefab名
    string[] InstanceObjctName = { 
        "AudioManager",
        "FadeManager"
    };

    private void Awake()
    {
        //自身が重複しているかチェック
        CheckInstance();

        //各prefab生成
        foreach (string name in InstanceObjctName)
        {
            GameObject obj = Instantiate((GameObject)Resources.Load(name), gameObject.transform);
            obj.name = name;
        }
    }

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CheckInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
