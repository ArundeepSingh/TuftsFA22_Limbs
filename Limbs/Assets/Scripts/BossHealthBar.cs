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

      private void Start () {
            gc = GameObject.Find("GameController").GetComponent<GameController>();
      }

      void FixedUpdate () {
            healthBar.fillAmount = gc.BossHealth / gc.BossMaxHealth;
      }

      public void SetColor(Color newColor){
            healthBar.GetComponent<Image>().color = newColor;
      }

      public void BossTakeDamage (float amount){
            gc.BossHealth -= amount;
            //turn red at low health:
            if (gc.Health < 0.3f * gc.MaxHealth){
                  if (gc.Health <= 0){
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

      public void BossDie(){
            Debug.Log("You Win");
      }
}