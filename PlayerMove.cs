using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 7.0f;      //플레이어 이동속도 변수
    public float yVelocity = 0;

    public float jumpPower = 5.0f;       //점프력 변수
    public bool isJumping = false;      //점프상태 감지 변수

    float gravity = -15.0f;
    CharacterController cc;

void Start(){

   cc= GetComponent<CharacterController>();

}
    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");


        Vector3 dir = new Vector3(h, 0, v);
        dir = dir.normalized;
        dir = Camera.main.transform.TransformDirection(dir);   //메인카메라 기준으로 이동방향 조정

if(cc.collisionFlags == CollisionFlags.Below){
    if(isJumping) {isJumping=false;}
    yVelocity = 0;
}


    if(Input.GetButtonDown("Jump")){
        yVelocity = jumpPower;
    }
        yVelocity += gravity *Time.deltaTime;
        dir.y = yVelocity;
        cc.Move(dir* moveSpeed* Time.deltaTime);

    }
}
