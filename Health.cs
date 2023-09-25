using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
  //  public Text healthText;       //텍스트
  //  public Image healthBar;       
    public Image[] healthPoints;

    float health,maxHealth = 100;
    float lerpSpeed;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
    //    healthText.text = "Health: "+ health + "%";   //텍스트
        if(health > maxHealth) {health = maxHealth;}

        lerpSpeed = 3f * Time.deltaTime;   //줄어드는 모습을 자연스럽게 하는 함수

        HealthBarFiller();
    }

    void HealthBarFiller(){
     //   healthBar.fillAmount = health / maxHealth;        

     //   healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, health / maxHealth, lerpSpeed);

        for (int i =0; i< healthPoints.Length; i++){
            healthPoints[i].enabled = !DisplayHealthPoint(health,i);
        }
    }

    bool DisplayHealthPoint(float _health, int pointNumber){
        return ((pointNumber *10) >= _health);
    }

    public void Damage(float damagePoints){
        if (health>0) {health -= damagePoints;}
    }

    public void Heal(float healPoints){
        if (health<maxHealth) {health += healPoints;}
    }
}