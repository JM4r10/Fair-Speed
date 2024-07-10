using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFoward : MonoBehaviour
{
    void Update()
    {
        if (GameManager.Instance.GameSpeed > 0) transform.Translate(GameManager.Instance.GameSpeed * Time.deltaTime * Vector3.forward);
    }

}
