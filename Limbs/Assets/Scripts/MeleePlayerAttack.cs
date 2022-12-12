using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleePlayerAttack : MonoBehaviour {

   public Animator animator;
   public Transform attackPoint;
   public float attackRange = 0.5f;
   public float attackRate = 2f;
   private float nextAttackTime = 0f;
   public int attackDamage = 1000;
   public LayerMask enemyLayers;
   public GameObject ShowAttackCircle;
   private SpriteRenderer CircleRenderer;


   void Awake(){
      ShowAttackCircle.SetActive(false);
      CircleRenderer = ShowAttackCircle.GetComponent<SpriteRenderer>();
   }

    

   void Update(){
      if (Time.time >= nextAttackTime){
         ShowAttackCircle.SetActive(false);
         if (Input.GetKeyDown(KeyCode.Space)){
            Attack();
            nextAttackTime = Time.time + 1f / attackRate;
            ShowAttackCircle.SetActive(true);
            Color tmp = ShowAttackCircle.GetComponent<SpriteRenderer>().color;
            tmp.a = 1f;
            ShowAttackCircle.GetComponent<SpriteRenderer>().color = tmp;
         }
      }
    }

   void FixedUpdate() {
      if (ShowAttackCircle.GetComponent<SpriteRenderer>().color.a > 0f) {
         Color tmp = ShowAttackCircle.GetComponent<SpriteRenderer>().color;
         tmp.a -= Time.deltaTime;
         Debug.Log(Time.deltaTime);
         ShowAttackCircle.GetComponent<SpriteRenderer>().color = tmp;
         Debug.Log(ShowAttackCircle.GetComponent<SpriteRenderer>().color.a);
      }
   }

    void Attack(){
        //animator.SetTrigger ("Attack");
        Debug.Log("Attacking");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);     //2D
        //Collider[] hitEnemy = Physics.OverlapSphere(AttackPoint.position, attackRange, enemyLayers);   //3D version

        foreach(Collider2D enemy in hitEnemies){        //2D, change Collider2D to Collider for 3D
            Debug.Log("We hit " + enemy.name);
            enemy.GetComponent<EnemyMeleeDamage>().TakeDamage(attackDamage);
        }
    }

   //to help see the attack sphere in editor:
   void OnDrawGizmosSelected(){
        if (attackPoint == null) return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
   }
}