using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour {

       private GameController gameHandlerObj;
       public float speed = 10f;
       private Transform playerTrans;
       private Vector2 target;
    //    public GameObject hitEffectAnim;
       public float SelfDestructTime = 2.0f;
       public float damage;

       void Start() {
             //NOTE: transform gets location, but we need Vector2 for direction, so we can use MoveTowards.
             playerTrans = GameObject.FindGameObjectWithTag("Player").transform;
             target = new Vector2(playerTrans.position.x, playerTrans.position.y);

             if (gameHandlerObj == null){
               gameHandlerObj = GameObject.FindWithTag("GameController").GetComponent<GameController>();
             }
             StartCoroutine(selfDestruct());
       }

       void Update () {

              transform.position = Vector2.MoveTowards (transform.position, target, speed * Time.deltaTime);
       }

       //if the bullet hits a collider, play the explosion animation, then destroy the effect and the bullet
       void OnTriggerEnter2D(Collider2D collision){
              if (collision.gameObject.tag == "Player") {
                     gameHandlerObj.Health -= damage;
              }
              
              if (collision.gameObject.tag == "IgnoreProj"){
                     Debug.Log("hit ignore tag");
                     Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
              }

              if (collision.gameObject.tag != "enemyShooter" && collision.gameObject.tag != "IgnoreProj") {
                    //  GameObject animEffect = Instantiate (hitEffectAnim, transform.position, Quaternion.identity);
                    //  Destroy (animEffect, 0.5f);
                     Destroy (gameObject);
              }
       }

       IEnumerator selfDestruct(){
              yield return new WaitForSeconds(SelfDestructTime);
              Destroy (gameObject);
       }
}
