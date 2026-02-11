using UnityEngine;
using System.Collections.Generic;
using System.Diagnostics;

public class ListDeleteTest : MonoBehaviour
{
  void Start()
    {
        TestDelete();
    }
    
    void TestDelete()
    {
        int size = 1000000;
        
        UnityEngine.Debug.Log("=== 삭제 성능 비교 ===\n");
        
        // 맨 앞 삭제
        List<int> list1 = new List<int>(size);
        for (int i = 0; i < size; i++)
            list1.Add(i);
        
        var sw = Stopwatch.StartNew();
        list1.RemoveAt(0);  // 맨 앞
        sw.Stop();
        UnityEngine.Debug.Log($"맨 앞 삭제: {sw.ElapsedMilliseconds}ms - O(n)");
        
        // 중간 삭제
        List<int> list2 = new List<int>(size);
        for (int i = 0; i < size; i++)
            list2.Add(i);
        
        sw.Restart();
        list2.RemoveAt(size / 2);  // 중간
        sw.Stop();
        UnityEngine.Debug.Log($"중간 삭제: {sw.ElapsedMilliseconds}ms - O(n)");
        
        // 맨 뒤 삭제
        List<int> list3 = new List<int>(size);
        for (int i = 0; i < size; i++)
            list3.Add(i);
        
        sw.Restart();
        list3.RemoveAt(list3.Count - 1);  // 맨 뒤
        sw.Stop();
        UnityEngine.Debug.Log($"맨 뒤 삭제: {sw.ElapsedTicks} ticks - O(1)");
    }
}
