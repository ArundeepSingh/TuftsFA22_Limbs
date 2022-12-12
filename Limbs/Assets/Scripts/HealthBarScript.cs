using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBarScript : MonoBehaviour {

      //public GameObject deathEffect;
      public Image healthBar;
      public Color healthyColor = new Color(0.3f, 0.8f, 0.3f);
      public Color unhealthyColor = new Color(0.8f, 0.3f, 0.3f);

            //temporary time variables:
      public float timeToDamage = 5f;
      private float theTimer;
      public float damageAmt = 10f;

      private HitEnemy HitEnemyScript;
      private GameController gc;

      private void Start () {
            theTimer= timeToDamage;
            HitEnemyScript = GameObject.Find("Soul").GetComponent<HitEnemy>();
            gc = GameObject.Find("GameController").GetComponent<GameController>();
      }

// this timer is just to test damage. Comment-out when no longer needed
      void FixedUpdate () {
            if (gc.BleedingOut) {
                  gc.Health -= 1f * Time.deltaTime;
                  //Debug.Log(gc.Health);
            }
            healthBar.fillAmount = gc.Health / gc.MaxHealth;
            if (HitEnemyScript.GotHit) {
                  TakeDamage(5f);
                  HitEnemyScript.GotHit = false;
            }
      }

      public void SetColor(Color newColor){
            healthBar.GetComponent<Image>().color = newColor;
      }

      public void TakeDamage (float amount){
            gc.Health -= amount;
            healthBar.fillAmount = gc.Health / gc.MaxHealth;
            //turn red at low health:
            if (gc.Health < 0.3f){
                  if (gc.Health <= 0){
                        SetColor(Color.white);
                        Die();
                  }
                  else {
                        SetColor(unhealthyColor);
                  }
            }
            else {
                  SetColor(healthyColor);
            }
      }

      public void Die(){
            Debug.Log("You Died So Much");
           // death stuff. change scene? how about a particle effect?
            //Vector3 objPos = this.transform.position
            //Instantiate(deathEffect, objPos, Quaternion.identity) as GameObject;
           SceneManager.LoadScene("LoseScene");
      }
}