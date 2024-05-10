using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeConstructor : MonoBehaviour
{
    public bool showDebug;
    private int[,] data;
 
     void Start()
    {
       
        GameObject mazeObject = new GameObject("Maze");
        mazeObject.transform.position = Vector3.zero;
        MeshFilter meshFilter = mazeObject.AddComponent<MeshFilter>();
        MeshRenderer meshRenderer = mazeObject.AddComponent<MeshRenderer>();
        meshRenderer.material = Resources.Load<Material>("wall-mat");
        Mesh mazeMesh = TestMesh();
        meshFilter.mesh = mazeMesh;
    }
 
    void Awake()
    {
        data = GenerateMazeDataFromDimensions(5, 5);
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
 
                     
                        if (x + offset[0] >= 0 && x + offset[0] < numRows &&
                            y + offset[1] >= 0 && y + offset[1] < numCols)
                        {
                            maze[x + offset[0], y + offset[1]] = 1;
                        }
                    }
                }
            }
        }
 
        return maze;
    }
 
   
    public Mesh TestMesh()
    {
        List<Vector3> newVertices = new List<Vector3>
        {
            new Vector3(-0.5f, -0.5f, 0),
            new Vector3(-0.5f, 0.5f, 0),
            new Vector3(0.5f, 0.5f, 0),
            new Vector3(0.5f, -0.5f, 0)
        };
 
        List<int> newTriangles = new List<int> { 0, 1, 2, 0, 2, 3 };
 
        List<Vector2> newUVs = new List<Vector2>
        {
            new Vector2(1, 0),
            new Vector2(1, 1),
            new Vector2(0, 1),
            new Vector2(0, 0)
        };
 
        Mesh mesh = new Mesh();
        mesh.SetVertices(newVertices);
        mesh.SetUVs(0, newUVs);
        mesh.SetTriangles(newTriangles, 0);
 
        return mesh;
    }
}
