using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LivesDisplay : MonoBehaviour
{
    [SerializeField] int lives = 3;
    TextMeshProUGUI liveText;
    LevelLoad levelLoad;
    // Start is called before the first frame update
    void Start()
    {
        liveText = GetComponent<TextMeshProUGUI>();
        levelLoad = FindObjectOfType<LevelLoad>();
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
            levelLoad.LoadGameOver();
        }
        UpdateDisplay();
    }
}
