using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Velocity : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI pointsText;

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance != null)
        {
            pointsText.text = $"Velocidad: {GameManager.Instance.GameSpeed.ToString("0.0")}";
        }
    }
}
