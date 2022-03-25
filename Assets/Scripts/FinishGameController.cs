using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FinishGameController : MonoBehaviour
{

     public GameObject Palet;
    
    private float changedXPos = -2f;
    private float changingZPos = 233f; 
    public AudioSource FinishedGameMsc;
    private bool boxStillGoing = true;
    private int boxCount=0;
 
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            // Playera çarpýnca olanlar     
            other.gameObject.GetComponent<Animator>().SetBool("kick",true);
            Debug.Log("çarptý player");
            StartCoroutine(makeKickFalse(other));
            
        }

        if (other.gameObject.CompareTag("AllPlayer"))
        {
            Debug.Log("çarptý all player");
            Palet.SetActive(false);
            other.gameObject.GetComponent<PlayerController>().stopGame = true;
           
        }
        
           
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && boxStillGoing)
        {
            if (BoxRush.instance.boxes.Count-1 == boxCount)
                other.gameObject.GetComponent<Animator>().SetBool("finish", true);
            StartCoroutine(boxStill2(other));

        }
        if (other.gameObject.CompareTag("Collected") && boxStillGoing)
        {
            boxCount++;
            StartCoroutine(boxStill(other));
            Debug.Log("sayi : " + changedXPos);
            StartCoroutine(MusicPlay());
            other.gameObject.transform.DOMove(new Vector3(changedXPos, 2.1f, changingZPos), 5f, false);
            other.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            changedXPos++;
            if (changedXPos > 4)
            {
                changedXPos = -2;
                changingZPos--;
            }
 
        }
    }


    IEnumerator MusicPlay()
    {
        FinishedGameMsc.Play();
        yield return new WaitForSeconds(2.5f);
        FinishedGameMsc.Stop();
    }

    IEnumerator makeKickFalse(Collider other)
    {
        yield return new WaitForSeconds(1.5f);
        other.gameObject.GetComponent<Animator>().SetBool("kick2", false);
    }
    IEnumerator boxStill(Collider other)
    {
        boxStillGoing = false;
        yield return new WaitForSeconds(0.5f);
        boxStillGoing = true;
    }

    IEnumerator boxStill2(Collider other)
    {
        other.gameObject.GetComponent<Animator>().SetBool("kick2", true);
        yield return new WaitForSeconds(0.5f); 
        other.gameObject.GetComponent<Animator>().SetBool("kick2", false);
    }
}
