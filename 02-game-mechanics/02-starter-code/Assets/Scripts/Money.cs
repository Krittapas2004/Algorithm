using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    private int money;
    public AudioSource explosion;

    public int NewMoney{
        get {
            return money;
        }
        set{
            money = value;
            explosion.Play();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        NewMoney = 500;
        print(NewMoney);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
