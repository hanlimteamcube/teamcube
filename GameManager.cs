using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool Game_Start = false;     //게임 시작 체크

  //  public GameObject Charactor; //주인공 게임오브젝트
   // public Slider Slider;       //슬라이더 

        
    public float Current_Time=0.0f;       //현재 남은 시간
    public float Destination_Time=10.0f;  //전체 시간
    public float Add_Time_Flow = 0.1f; //감소되는 시간
    
    public Text countdownText;

    // Start is called before the first frame update
    void Start()
    {
        countdownText.text =Current_Time.ToString("0.0");
        Init(); //초기화
    }

    // Update is called once per frame
    void Update()
    { 
        if(Game_Start) {  
       // Destination_Time -= Add_Time_Flow; //적용시 감소가 점점 빨라짐
        Current_Time -= Time.deltaTime;    //deltaTime=컴퓨터 성능에 따라 프레임 사이가 일정하지 않더라도 원하는 시간만큼만 적당히 작동하도록 도와주는 명령어
      //  Slider.value= Current_Time / Destination_Time;  //슬라이더 표시기
      
      countdownText.text = Current_Time.ToString("0.0");

      if(Current_Time<0f){                //시간 종료시 결과
            Result();
        }

        }
    }

    public void Init() {        // 오브젝트, 시간 초기화
        Destination_Time=10.0f;
        Current_Time= Destination_Time;
        Game_Start=true;

        }

    public void Result() {
        Debug.Log("Game Over");
countdownText.text = Current_Time.ToString("game over");
        Game_Start = false;
    }
}
