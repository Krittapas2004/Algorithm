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

    public int[,] GenerateMazeDataFromDimensions(int numRows, int numCols)
    {
        int[,] maze = new int[numRows, numCols];
        float placementThreshold = 0.1f; 
        for (var x = 0; x < numRows; x++) 
        {
            for (var y = 0; y < numCols; y++) 
            {
                if (x == 0 || y == 0 || x == numRows - 1 || y == numCols - 1) 
                {
                    maze[x, y] = 1; 
                }
                else if (x % 2 == 0 && y % 2 == 0) 
                {
                    if (Random.value > placementThreshold) 
                    {
                        maze[x, y] = 1; 

                        
                        int delta = Random.value > 0.5f ? -1 : 1;
                       
                        int[] offset = new int[2];
                        
                        int offsetIndex = Random.value > 0.5f ? 0 : 1;
                        offset[offsetIndex] = delta;

                        
                        maze[x + offset[0], y + offset[1]] = 1;
                    }
                }
            }
        }

        return maze;
    }
}
