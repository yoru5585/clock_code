using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate_s : MonoBehaviour
{
    //�j�̉�]�𐧌䂷��X�N���v�g
    [SerializeField] float speed;
    // Start is called before the first frame update
    void Start()
    {
        ChangeDir();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, speed * Time.deltaTime);
    }

    public void ChangeDir()
    {
        speed *= -1;
    }

    public void ChangeSpeed(float value)
    {
        speed = value;
    }
}
