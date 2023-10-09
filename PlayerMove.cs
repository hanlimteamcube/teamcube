using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 7.0f;      //플레이어 이동속도 변수
    public float yVelocity = 0;

    public float jumpPower = 5.0f;       //점프력 변수
    public bool isJumping = false;      //점프상태 감지 변수

    public Image[] healthPoints;

    float health, maxHealth = 100;
    float lerpSpeed;

    public GameObject hitEffect;       //피격효과 오브젝트
    public GameObject healEffect;       //회복효과 오브젝트

    float gravity = -15.0f;
    CharacterController cc;

void Start(){
        health = maxHealth;
        cc = GetComponent<CharacterController>();

}
    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 dir = new Vector3(h, 0, v);
        dir = dir.normalized;
        dir = Camera.main.transform.TransformDirection(dir);   //메인카메라 기준으로 이동방향 조정

        if (health > maxHealth) { health = maxHealth; }

        lerpSpeed = 3f * Time.deltaTime;   //줄어드는 모습을 자연스럽게 하는 함수

        HealthBarFiller();

        if (cc.collisionFlags == CollisionFlags.Below){
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

    void HealthBarFiller()
    {
        //   healthBar.fillAmount = health / maxHealth;        

        //   healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, health / maxHealth, lerpSpeed);

        for (int i = 0; i < healthPoints.Length; i++)
        {
            healthPoints[i].enabled = !DisplayHealthPoint(health, i);
        }
    }
    bool DisplayHealthPoint(float _health, int pointNumber)
    {
        return ((pointNumber * 10) >= _health);
    }

    public void Damage(float damagePoints)
    {
        if (health > 0)
        {
            StartCoroutine(PlayHitEffect());
            health -= damagePoints;
        }
    }

    public void Heal(float healPoints)
    {
        if (health < maxHealth) {
            StartCoroutine(PlayHealEffect());
            health += healPoints; 
        }
    }

    IEnumerator PlayHitEffect()       //피격효과 코루틴
    {
        hitEffect.SetActive(true);

        yield return new WaitForSeconds(0.3f);  //0.3초만큼 대기 후 종료
        hitEffect.SetActive(false);
    }

    IEnumerator PlayHealEffect()       //회복효과 코루틴
    {
        healEffect.SetActive(true);

        yield return new WaitForSeconds(0.3f);  //0.3초만큼 대기 후 종료
        healEffect.SetActive(false);
    }
}
