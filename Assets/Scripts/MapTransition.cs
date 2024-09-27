using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class MapTransition : MonoBehaviour
{
    public GameObject spawngb;
    public UnityEngine.UI.Image transition;
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Player")){
            transition.transform.DOScale(new Vector3(1.5f,1.5f, 1f), 0.5f);
            StartCoroutine(ChangePosition(other));
        }
    }

    IEnumerator ChangePosition(Collider2D other){
        yield return new WaitForSeconds(0.5f);
        other.transform.position = spawngb.transform.position;
        yield return new WaitForSeconds(0.5f);
        transition.transform.DOScale(new Vector3(0,0, 1f), 2f);
    }
}
