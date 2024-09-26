// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using DG.Tweening;
// public class EnemyAttack : MonoBehaviour
// {
//     Transform target = null;
//     //GameObject player = null;
//     bool isMovingBack = false;
//     [SerializeField] float detectRange;
//     Vector3 oldpos = Vector3.zero; 
//     // Start is called before the first frame update
//     void Start()
//     {
        
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         if(PlayerInRange() && !isMovingBack){
//             Debug.Log("Player is in range");
//             Attack();
//         } else if (isMovingBack){
//             MovingBack();
//         }
//     }
//     bool PlayerInRange(){
//         RaycastHit2D detectray = Physics2D.CircleCast(transform.position, detectRange, Vector2.zero);
//         if(detectray){
//             if(detectray.collider.gameObject.CompareTag("Player")){
//                 //player = detectray.collider.gameObject;
//                 target.position = detectray.collider.transform.position;
//                 return true;
//             } else return false;
//         } else return false;
//     }
//     void MovingBack(){
//         transform.DOMove(oldpos, 0.35f).OnComplete(() => {
//             StartCoroutine(ResetisMovingBack());
//         });
//     }
//     IEnumerator ResetisMovingBack(){
//         yield return new WaitForSeconds(0.5f);
//         isMovingBack = false;
//     }
//     void Attack(){
//         oldpos = transform.position;
//         transform.DOMove(player.transform.position, 0.35f);
//     }
//     void OnDrawGizmos(){
//         Gizmos.color = Color.red;
//         Gizmos.DrawWireSphere(transform.position, detectRange);
//     }
//     void OnCollisionEnter2D(Collision2D other){
//         if(other.gameObject.CompareTag("Player")){
//             isMovingBack = true;
//         }
//     }
// }
