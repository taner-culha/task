using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    public Transform Hold;
    void Start()
    {
        Hold= GameObject.FindWithTag("hold").transform;
    }
    private void OnMouseDrag() {
        transform.position=Vector3.Lerp(transform.position,Hold.position,Time.deltaTime*5);
        GetComponent<Rigidbody>().useGravity=false;
    }
    private void OnMouseUp() {
        GetComponent<Rigidbody>().useGravity=true;
    }
}