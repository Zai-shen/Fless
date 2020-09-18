using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("LoseTrigger"))
        {
            Debug.Log("Player hits: " + other.name);
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
