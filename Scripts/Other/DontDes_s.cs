using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDes_s : MonoBehaviour
{
    //�Q�[���S�̂ŉe������I�u�W�F�N�g���Ǘ�����X�N���v�g
    //�V���O���g��
    public static DontDes_s instance;
    //��������prefab��
    string[] InstanceObjctName = { 
        "AudioManager",
        "FadeManager"
    };

    private void Awake()
    {
        //���g���d�����Ă��邩�`�F�b�N
        CheckInstance();

        //�eprefab����
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
