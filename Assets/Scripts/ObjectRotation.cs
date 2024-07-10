using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotation : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float angleRotation;

    private void Start() => transform.Rotate(Vector3.left, angleRotation);

    void LateUpdate() => transform.Rotate(speed * Time.deltaTime * Vector3.up, Space.Self);

}
