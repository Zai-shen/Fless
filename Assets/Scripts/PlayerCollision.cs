using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private AudioManager audioManager;
    private void Start()
    {
        audioManager = AudioManager.Instance;
    }

    private void OnCollisionEnter(Collision collision)
    {
        audioManager.PlayWithRandomizedPitch("Box");
    }
}
