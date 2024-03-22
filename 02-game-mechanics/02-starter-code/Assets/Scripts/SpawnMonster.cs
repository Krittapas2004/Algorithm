using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMonster : MonoBehaviour
{

    public GameObject MonsterPrefab;
    private GameObject PlacedMonster = null;

    void OnMouseUp(){
        if (PlacedMonster == null){
            PlacedMonster = Instantiate(MonsterPrefab, transform.position, Quaternion.identity);
        }
        else{
            PlacedMonster.GetComponent<MonsterData>().IncreaseLevel();
        }
    }

    private bool CanUpgradeMonster()
    {
        if (PlacedMonster != null)
        {
            MonsterData monsterData = PlacedMonster.GetComponent<MonsterData>();
            MonsterLevel nextLevel = monsterData.GetNextLevel();
            if (nextLevel != null)
            {
                return true;
            }
        }
        return false;
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
