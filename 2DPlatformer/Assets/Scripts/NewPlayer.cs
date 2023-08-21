using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class NewPlayer : PhysicsObject
{
    public static NewPlayer Instance;


    [SerializeField] private float moveSpeed = 10;
    [SerializeField] private float jumpPower = 10;

    private Vector2 originalHealthBarSize;

    public int ammo;
    public int health = 100;
    public int maxHealth = 100;
    public int coinCollected;

    public Sprite inventoryItemBlank;
    public Text coinsUI;
    public Image healthBar;
    [SerializeField] private Image inventoryItemImage;






    public Dictionary<string, Sprite> inventory = new Dictionary<string, Sprite>();

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        originalHealthBarSize = healthBar.rectTransform.sizeDelta;

        UpdateUI();
    }

    void Update()
    {
        targetVelocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, 0);


        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            velocity.y = jumpPower;
        }
    }

    public void UpdateUI()
    {
        coinsUI.text = coinCollected.ToString();

        healthBar.rectTransform.sizeDelta = new Vector2(originalHealthBarSize.x * ((float)health / (float)maxHealth), healthBar.rectTransform.sizeDelta.y);
    }

    public void AddInventoryItem(string inventoryItemName, Sprite itemImage)
    {
        inventory.Add(inventoryItemName, itemImage);
        inventoryItemImage.sprite = inventory[inventoryItemName];
    }

    public void RemoveInventoryItem(string inventoryItemName)
    {
        inventory.Remove(inventoryItemName);
        inventoryItemImage.sprite = inventoryItemBlank;
    }

}
