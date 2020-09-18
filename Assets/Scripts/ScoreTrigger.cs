using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTrigger : MonoBehaviour
{
    private bool scored;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !scored)
        {
            scored = true;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawCube(transform.position, transform.localScale);
    }

}
