using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeConstructor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool showDebug;
    private int[,] data;

    void Awake()
    {
        int width = 7;
        int height = 5;

        data = new int[width, height];

        for (int i = 0; i < width; i++)
        { 
            for (int j = 0; j < height; j++) 
            {
                data[i ,j] = i;
            }
        }
    }

    void OnGUI()
    {
        if (!showDebug)
            return;

        int[,] maze = data;
        int rMax = maze.GetUpperBound(0);
        int cMax = maze.GetUpperBound(1);

        string msg = "";

        for (int i = rMax; i >= 0; i--)
        {
            for (int j = 0; j <= cMax; j++)
                msg += maze[i, j] == 0 ? "...." : "==";
            msg += "\n";
        }

        GUI.Label(new Rect(20, 20, 500, 500), msg);
    }
}
