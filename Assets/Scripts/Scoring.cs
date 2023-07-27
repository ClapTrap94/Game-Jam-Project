using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro; // Import the TextMeshPro namespae

public class Scoring : MonoBehaviour
{
    public GameObject scoreText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseScore(int score)
    {
        TextMeshProUGUI textMeshProComponent = scoreText.GetComponent<TextMeshProUGUI>();
        textMeshProComponent.text = score.ToString();
    }
}
