using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BossHealthBar : MonoBehaviour {

      //public GameObject deathEffect;
      public Image healthBar;
      public Color healthyColor = new Color(0.3f, 0.8f, 0.3f);
      public Color unhealthyColor = new Color(0.8f, 0.3f, 0.3f);

      private GameController gc;
      private EnemyMeleeDamage DamageScript;
      private float max_health;

      private void Start () {
            gc = GameObject.Find("GameController").GetComponent<GameController>();
            GameObject boss = GameObject.Find("FinalBoss");
            DamageScript = boss.GetComponent<EnemyMeleeDamage>();

            if (boss == null) {
                Debug.Log("boss is null");
            } else {
                Debug.Log("boss is not null");
            }

            if (DamageScript == null) {
                Debug.Log("DamageScript is null");
            } else {
                Debug.Log("DamageScript is not null");
            }
            
            max_health = DamageScript.maxHealth;

      }

      void FixedUpdate () {
            float cur_health = DamageScript.currentHealth;
            //Debug.Log("enemy cur health " + cur_health);
            healthBar.fillAmount = cur_health/ max_health;
            //turn red at low health:
            if (cur_health < 0.3f * max_health){
                  if (cur_health <= 0){
                        SetColor(Color.white);
                        BossDie();
                  }
                  else {
                        SetColor(unhealthyColor);
                  }
            }
            else {
                  SetColor(healthyColor);
            }
      }

      public void SetColor(Color newColor){
            healthBar.GetComponent<Image>().color = newColor;
      }


      public void BossDie(){
            Debug.Log("You Win");
            SceneManager.LoadScene("WinScene");
      }
}