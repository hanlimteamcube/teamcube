using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;       //싱글턴

    PlayerMove player;

    private void Awake()
    {
        if(gm == null)
        {
            gm = this;
        }
    }

    public enum GameState
    {
        Ready,
        Run,
        Pause,
        GameOver
    }
    public GameState gState;
    public GameObject gameOption;

    public bool Game_Start = false;     //게임 시작 체크

  //  public GameObject Charactor; //주인공 게임오브젝트
 //   public Slider Slider;       //슬라이더 

        
    public float Current_Time=0.0f;       //현재 남은 시간
    public float Destination_Time=10.0f;  //전체 시간
    public float Add_Time_Flow = 0.1f; //감소되는 시간
    
    public Text countdownText;

    public GameObject gameLabel;
    Text gameText;

    public GameObject Options;


    // Start is called before the first frame update
    void Start()
    {
        gState = GameState.Ready;
        countdownText.text =Current_Time.ToString("0.0");

        player = GameObject.Find("Player").GetComponent<PlayerMove>();
        gameText = gameLabel.GetComponent<Text>();

        StartCoroutine(ReadyToStart());

        Init(); //초기화
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.gm.gState != GameManager.GameState.Run)
        {
            return;
        }

        if (Game_Start) {  

       // Destination_Time -= Add_Time_Flow; //적용시 감소가 점점 빨라짐
        Current_Time -= Time.deltaTime;    //deltaTime=컴퓨터 성능에 따라 프레임 사이가 일정하지 않더라도 원하는 시간만큼만 적당히 작동하도록 도와주는 명령어
       // Slider.value= Current_Time / Destination_Time;  //슬라이더 표시기

      countdownText.text = Current_Time.ToString("0.0");

      if(Current_Time<0f){                //시간 종료시 결과
                Timeout();
          
            }

      if (player.health <= 0)       //체력 0이하가 될때 리셋
            {
                gameLabel.SetActive(true);

                gameText.text = "Dead";
                    gameText.color = new Color32(255, 0, 0, 255);

                Transform buttons =gameText.transform.GetChild(0);

                buttons.gameObject.SetActive(true);

                gState = GameState.GameOver;

  //게임을 리셋하지 않고 v플레이어를 시작점으로 이동 todo

            }

        }
    }

    public void Init() {        // 초기화
        Destination_Time=10.0f;
        Current_Time= Destination_Time;

        Game_Start = true;
       
    }

    public void Timeout() {
        gameLabel.SetActive(true);
        Debug.Log("Time out");
        countdownText.text = Current_Time.ToString("0.0");
        Game_Start = false;

        gameText.text = "Time out";
        gameText.color = new Color32(255, 0, 0, 255);

        gState = GameState.Pause;

    }

    IEnumerator ReadyToStart()
    {
        gameLabel.SetActive(true);
        gameText.text = "Wake";
        gameText.color = new Color32(255, 255, 0, 255);
        yield return new WaitForSeconds(2f);

        gameText.color = new Color32(0, 255, 255, 255);
        gameText.text = "Wake UP";
        yield return new WaitForSeconds(1f);

        gameText.color = new Color32(0, 255, 0, 255);
        gameLabel.SetActive(false);


        gState = GameState.Run;
        
    }

    public void OpenOptionWindow()
    {
        Options.SetActive(true);

        Time.timeScale = 0f;

        gState = GameState.Pause;
    }

    public void CloseOptionWindow()
    {
        Options.SetActive(false);

        Time.timeScale = 1f;

        gState = GameState.Run;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
