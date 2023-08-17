using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewPlayer : PhysicsObject
{
    [SerializeField] private float moveSpeed = 10;
    [SerializeField] private float jumpPower = 10;

    private Vector2 originalHealthBarSize;

    public int ammo;
    public int health = 100;
    public int maxHealth = 100;
    public int coinCollected;


    public Text coinsUI;
    public Image healthBar;
    void Start()
    {
        originalHealthBarSize = healthBar.rectTransform.sizeDelta;
        
        UpdateUI();
    }

    void Update()
    {
        targetVelocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, 0);

        // If player press space key and he is in ground , Jump
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            velocity.y = jumpPower;
        }
    }

    public void UpdateUI()
    {
        coinsUI.text = coinCollected.ToString();

        healthBar.rectTransform.sizeDelta = new Vector2(originalHealthBarSize.x * ((float)health/ (float)maxHealth),healthBar.rectTransform.sizeDelta.y);
    }
}
