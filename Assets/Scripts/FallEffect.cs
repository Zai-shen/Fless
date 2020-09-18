using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallEffect : MonoBehaviour
{
    [SerializeField] private ParticleSystem fallEffect = default;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Line"))
        {
            if (collision.relativeVelocity.y >= 3)
            {
                // Debug.Log("We hit a line with relative velocity Y of: " + collision.relativeVelocity.y + " Displaying particle effect!");
                ContactPoint contact = collision.contacts[0];
                // Debug.DrawRay(contact.point, contact.normal, Color.white);
                Instantiate(fallEffect, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.LookRotation(contact.normal));
            }
        }
    }
}
