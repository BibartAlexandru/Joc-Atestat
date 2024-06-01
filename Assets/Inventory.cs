using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject inventory;
    public Slot[] slots;
    private ControllerControls gamepad;

    private void Awake()
    {
        inventory.SetActive(false);
        gamepad = GetComponent<ControllerControls>();
    }

    public void Update()
    {
        inventory.SetActive(gamepad.inventoryActive);
    }
}
