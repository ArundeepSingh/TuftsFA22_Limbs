using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class EnemyMeleeDamage : MonoBehaviour {
       private Renderer rend;
       public Animator anim;
    //    public GameObject healthLoot;
       public float maxHealth = 100;
       public float currentHealth;
       private GameObject player;
       private Rigidbody2D rb2D;
       public float knockBackForce = 5f;

       void Start(){
              rend = GetComponentInChildren<Renderer> ();
              anim = GetComponentInChildren<Animator> ();
              currentHealth = maxHealth;
              player = GameObject.FindWithTag("Player");
              rb2D = GetComponent<Rigidbody2D>();
       }

       public void TakeDamage(int damage){
              Debug.Log("knockback force is " + knockBackForce);
              Debug.Log("enemy is taking damage");
              currentHealth -= damage;
              Rigidbody2D pushRB = player.gameObject.GetComponent<Rigidbody2D>();
              Vector2 moveDirectionPush = rb2D.transform.position - player.transform.position;
              rb2D.AddForce(moveDirectionPush.normalized * knockBackForce, ForceMode2D.Impulse);
              StartCoroutine(EndKnockBack(pushRB));
              if (currentHealth <= 0){
                     Die();
              }
       }


       IEnumerator EndKnockBack(Rigidbody2D otherRB){
              Debug.Log("ending knockback");
              yield return new WaitForSeconds(0.2f);
              otherRB.velocity= new Vector3(0,0,0);
       }

       void Die(){
            //   Instantiate (healthLoot, transform.position, Quaternion.identity);
              //anim.SetBool ("isDead", true);
              GetComponent<Collider2D>().enabled = false;
              StartCoroutine(Death());
       }

       IEnumerator Death(){
              yield return new WaitForSeconds(0.5f);
              Debug.Log("You Killed a baddie. You deserve loot!");
              Destroy(gameObject);
       }

       IEnumerator ResetColor(){
              yield return new WaitForSeconds(0.5f);
              rend.material.color = Color.white;
       }
}
