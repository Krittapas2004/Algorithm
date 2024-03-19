using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSlot : MonoBehaviour
{
    public GameObject MonsterPrefab;
    private GameObject PlacedMonster = null;
    void OnMouseUp()
    {
        if (PlacedMonster == null)
        {
           PlacedMonster = Instantiate(MonsterPrefab, transform.position, Quaternion.identity); 
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
