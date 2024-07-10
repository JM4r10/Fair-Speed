using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPos;
    private float repeatWidth;
    void Start()
    {
        startPos = transform.position;
        repeatWidth = GetComponent<BoxCollider>().size.z / 2;
    }

    private void Update() => ReturnToOriginalPos();


    private void ReturnToOriginalPos()
    {
        if (transform.position.z < startPos.z - repeatWidth)
        {
            transform.position = startPos;
        }
    }

}