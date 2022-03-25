using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectController : MonoBehaviour
{
    //public Transform BoxRef;
  
    public AudioSource collectMsc;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collect"))
        {
           
            if (!BoxRush.instance.boxes.Contains(other.gameObject))
            {
                collectMsc.Play();
                other.GetComponent<BoxCollider>().isTrigger = false;
                other.gameObject.tag = "Collected";
                other.gameObject.AddComponent<CollectController>();
                other.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                other.gameObject.GetComponent<Rigidbody>().useGravity = true;
                other.gameObject.GetComponent<Rigidbody>().mass = 0.05f;

                BoxRush.instance.StackBox(other.gameObject, BoxRush.instance.boxes.Count - 1);
            }

        }

        
    }

     

}
