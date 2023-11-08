using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    public float rotSpeed = 500f;   //회전속도(마우스 민감도) 변수

    float mx =0;
    float my =0;        //회전값 변수

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.gm.gState != GameManager.GameState.Run)
        {
            return;
        }
        float mouse_X = Input.GetAxis("Mouse X");
        float mouse_Y = Input.GetAxis("Mouse Y");

        mx +=mouse_X * rotSpeed *Time.deltaTime;
        my +=mouse_Y * rotSpeed *Time.deltaTime;

        my = Mathf.Clamp(my,-85f,80f);          // 인간의 목 각도를 생각해 마우스의 상하이동 회전 변수(my)를 -85~80도로 제한
        transform.eulerAngles =new Vector3(-my, mx, 0);
    }
}