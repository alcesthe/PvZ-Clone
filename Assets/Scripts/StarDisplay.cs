using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StarDisplay : MonoBehaviour
{
    [SerializeField] int stars = 100;
    TextMeshProUGUI starText;
    // Start is called before the first frame update
    void Start()
    {
        starText = GetComponent<TextMeshProUGUI>();
        UpdateDisplay();
    }

    public bool HaveEnoughStars(int amount)
    {
        return stars >= amount;
    }

    private void UpdateDisplay()
    {
        starText.SetText(stars.ToString());
    }
    
    public void AddStars(int amount)
    {
        stars += amount;
        UpdateDisplay();
    }

    public void SpendingStars(int amount)
    {
        if (stars >= amount)
        {
            stars -= amount;
            UpdateDisplay();
        }
    }
}
