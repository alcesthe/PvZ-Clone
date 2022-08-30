using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LivesDisplay : MonoBehaviour
{
    [SerializeField] float baseLives = 3;
    float lives;
    TextMeshProUGUI liveText;
    LevelController levelController;
    // Start is called before the first frame update
    void Start()
    {
        lives = baseLives - PlayerPrefsController.GetDifficulty();
        liveText = GetComponent<TextMeshProUGUI>();
        levelController = FindObjectOfType<LevelController>();
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        liveText.SetText("Lives: " + lives.ToString());
    }
    
    public void AddLives(int amount)
    {
        lives += amount;
        UpdateDisplay();
    }

    public void LostLives(int amount)
    {
        lives -= amount;
        if (lives == 0)
        {
            levelController.HandleLoseCondition();
        }
        UpdateDisplay();
    }
}
