using UnityEngine;
using System.Collections.Generic;


public class ListExample00 : MonoBehaviour
{
   void Start()
    {
        List<string> inventory = new List<string>();
        
        // 아이템 추가
        inventory.Add("검");
        inventory.Add("방패");
        inventory.Add("포션");
        
        Debug.Log($"인벤토리 개수: {inventory.Count}");
        Debug.Log($"내부 용량: {inventory.Capacity}");
        
        // 아이템 출력
        foreach (string item in inventory)
        {
            Debug.Log($"아이템: {item}");
        }
        
        // 아이템 삭제
        inventory.Remove("방패");
        Debug.Log($"삭제 후 개수: {inventory.Count}");
    }
}

