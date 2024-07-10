using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    void Update() => transform.Translate(GameManager.Instance.GameSpeed * Time.deltaTime * Vector3.back, Space.World);
}
