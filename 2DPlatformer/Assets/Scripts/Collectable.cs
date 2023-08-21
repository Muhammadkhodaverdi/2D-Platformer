using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    enum CollectableType { Coin, Health, Ammo, InventoryItem }
    [SerializeField] private CollectableType collectableType;

    [SerializeField] private string inventoryItemName;
    [SerializeField] private Sprite inventorySprite;

    void Start()
    {

    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == NewPlayer.Instance.gameObject)
        {
            if (collectableType == CollectableType.Coin)
            {
                NewPlayer.Instance.coinCollected += 1;
            }
            else if (collectableType == CollectableType.Health)
            {
                if (NewPlayer.Instance.health < 100)
                {
                    NewPlayer.Instance.health += 1;
                }
            }
            else if (collectableType == CollectableType.Ammo)
            {
                NewPlayer.Instance.ammo += 1;
            }
            else if (collectableType == CollectableType.InventoryItem)
            {
                NewPlayer.Instance.AddInventoryItem(inventoryItemName, inventorySprite);
            }
            else
            {

            }
            NewPlayer.Instance.UpdateUI();
            Destroy(gameObject);
        }
    }
}
