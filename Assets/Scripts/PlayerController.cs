using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Camera cam;
    public Vector3 offSet;
    public float swipeSpeed=2;

    public float runningSpeed=5;
    public float xSpeed;
    private float _currentRunningSpeed;
    public float limit_X;

    public bool stopGame = false;

    private void Start()
    {
        _currentRunningSpeed = runningSpeed;
        cam = Camera.main;
    }

    private void Update()

    {
        if (stopGame)
            return;
        // Kamera takip
        cam.transform.position = transform.position + offSet;

        transform.position += Vector3.forward * runningSpeed * Time.deltaTime;

        if (Input.GetButton("Fire1"))
        {
            Move();
        }

    }

    private void Move()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = cam.transform.localPosition.z;

        Ray ray = cam.ScreenPointToRay(mousePos);
        RaycastHit hit;
        if(Physics.Raycast(ray,out hit, 200))
        {
            GameObject firstCub = BoxRush.instance.boxes[0];
            Vector3 hitVec = hit.point;
            hitVec.z = firstCub.transform.localPosition.z;
            hitVec.y = firstCub.transform.localPosition.y;

            firstCub.transform.localPosition = Vector3.MoveTowards(firstCub.transform.localPosition, hitVec, Time.deltaTime * swipeSpeed);
           
        }
    }
}





// Movement Kodlarý  2. yontem


//float newX = 0;
//float touchXDelta = 0;
//if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
//{
//    touchXDelta = Input.GetTouch(0).deltaPosition.x / Screen.width; // parmak ne kadar sað sola kaydýrýyor user
//}
//else if (Input.GetMouseButton(0))
//{
//    touchXDelta = Input.GetAxis("Mouse X");
//}
//newX = transform.position.x + xSpeed * touchXDelta * Time.deltaTime;
//newX = Mathf.Clamp(newX, -limit_X, limit_X); // Sýnýrlandýrma sað ve sol taraflarý

//Vector3 newPosition = new Vector3(newX, transform.position.y, transform.position.z + _currentRunningSpeed * Time.deltaTime);
//transform.position = newPosition;