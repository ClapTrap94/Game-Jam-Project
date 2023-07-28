using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro; // Import the TextMeshPro namespae

public class Scoring : MonoBehaviour
{
    public GameObject scoreText;
    public GameObject firewoodUI;
    private int _firewoodAmount;

    public void IncreaseScore(int score)
    {
        TextMeshProUGUI textMeshProComponent = scoreText.GetComponent<TextMeshProUGUI>();
        textMeshProComponent.text = score.ToString();
    }
    public void IncreaseFirewood(int firewood)
    {
        _firewoodAmount += firewood;
        TextMeshProUGUI textMeshProComponent = firewoodUI.GetComponent<TextMeshProUGUI>();
        textMeshProComponent.text = firewood.ToString();
    }
    public void DecreaseFirewood(int firewood)
    {
        _firewoodAmount -= firewood;
        TextMeshProUGUI textMeshProComponent = firewoodUI.GetComponent<TextMeshProUGUI>();
        textMeshProComponent.text = firewood.ToString();
    }
}
