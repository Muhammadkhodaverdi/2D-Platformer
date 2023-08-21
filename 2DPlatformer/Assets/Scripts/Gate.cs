using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    [SerializeField] private string requiredInventoryItemString;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == NewPlayer.Instance.gameObject)
        {
            if (NewPlayer.Instance.inventory.ContainsKey(requiredInventoryItemString))
            {
                Destroy(gameObject);
                NewPlayer.Instance.RemoveInventoryItem(requiredInventoryItemString);
            }
        }
    }
}
