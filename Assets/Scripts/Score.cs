using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI pointsText;
    
    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance != null)
        {
            pointsText.text = $"Distancia recorrida: {GameManager.Instance.Score.ToString("F2")} mts";
        }
    }
}
