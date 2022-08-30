using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    LivesDisplay livesDisplay;
    private void Start()
    {
        livesDisplay = FindObjectOfType<LivesDisplay>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
        livesDisplay.LostLives(1);
    }
}
