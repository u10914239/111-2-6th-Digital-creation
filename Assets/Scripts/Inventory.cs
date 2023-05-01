using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int[] Slot; //!物品欄內物品
    public int slotNumber; //!物品欄數量控制
    public int holdItemNumber; //!當前背包有多少物品


    void Start()
    {
        
    }

    
    void Update()
    {
        InventoryControl();
    }

    void InventoryControl() //* 物品欄的數量與基本控制
    {
        Slot = new int[slotNumber]; //*陣列長度
        
        if(holdItemNumber <= 4)  //*只要握持物品數量大於4，物品欄將永遠會有現在握持的物品數量加一
        {
            slotNumber = 4;
        }
        else
        {
            slotNumber = holdItemNumber + 1;
        }
    }
}
