using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class BoxRush : MonoBehaviour
{
    public static BoxRush instance;
    public float movementDelay=0.15f;
    public Transform BoxRefPos;

    public List<GameObject> boxes = new List<GameObject>();

    private void Awake()
    {
        if (instance == null)
            instance = this;

    }

    private void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            MoveListElement();

        }
        if (Input.GetButtonUp("Fire1"))
        {
            MoveOrigin();
        }



    }
    public void StackBox(GameObject other ,int index)
    {
        other.transform.parent = transform;
        if(index == 0)
        {
            Vector3 newPos = boxes[index].transform.localPosition;
            newPos.y += 0.1f;
            other.transform.localPosition = newPos;
            boxes.Add(other);
        }
        else
        {
            Vector3 newPos = boxes[index].transform.localPosition; // Box'un son elemaný alýyoruz
            newPos.y += 1;
            other.transform.localPosition = newPos;
            boxes.Add(other);
        }
    }

    //hareket halindeyken kutular bi oraya bi buraya gider
    private void MoveListElement()
    {
        for (int i=1; i < boxes.Count; i++)
        {
            Vector3 pos = boxes[i].transform.localPosition;
            pos.x = boxes[i - 1].transform.localPosition.x;
            boxes[i].transform.DOLocalMove(pos, movementDelay);
        }
    }

    // Bu dokunmayý býrakýnca düzler hemen
    private void MoveOrigin()
    {
        for (int i = 1; i < boxes.Count; i++)
        {
            Vector3 pos = boxes[i].transform.localPosition;
            pos.x = boxes[0].transform.localPosition.x;
            boxes[i].transform.DOLocalMove(pos, 0.7f);
        }
    }
    
}
