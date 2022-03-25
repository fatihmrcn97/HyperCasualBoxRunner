using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public AudioSource boxLoseMsc;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collected"))
        {
            boxLoseMsc.Play();
            BoxRush.instance.boxes[BoxRush.instance.boxes.Count - 1].transform.parent = transform.parent;
            BoxRush.instance.boxes.RemoveAt(BoxRush.instance.boxes.Count - 1);
            other.gameObject.tag = "Untagged";
        }
    }
}
