using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    enum CollectableType { Coin, Health, Ammo }
    [SerializeField] private CollectableType collectableType;

    private const string PLAYER = "Player";
    private NewPlayer player;


    void Start()
    {
        player = GameObject.Find(PLAYER).GetComponent<NewPlayer>();
    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == PLAYER)
        {
            if (collectableType == CollectableType.Coin)
            {
                player.coinCollected += 1;
            }
            else if (collectableType == CollectableType.Health)
            {
                if (player.health < 100)
                {
                    player.health += 1;
                }
            }
            else if (collectableType == CollectableType.Ammo)
            {
                player.ammo += 1;
            }
            else
            {

            }
            player.UpdateUI();
            Destroy(gameObject);
        }
    }
}
