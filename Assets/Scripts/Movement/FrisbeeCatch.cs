using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrisbeeCatch : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Debug.Log("hit character");
            // Todo add score to player
        }
    }
}
