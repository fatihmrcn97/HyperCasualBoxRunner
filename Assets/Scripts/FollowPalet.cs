using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPalet : MonoBehaviour
{


    public Transform palet;
    public Animator anim;

    public void Kick()
    {
    }
    void Update()
    { 
        transform.position = new Vector3(palet.transform.position.x,transform.position.y,transform.position.z);
    }
}
