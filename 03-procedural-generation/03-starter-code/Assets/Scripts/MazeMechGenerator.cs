using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeMechGenerator : MonoBehaviour
{
    GameObject newGameObject = new GameObject("Maze");
    // Start is called before the first frame update
    void Start()
    {
        GameObject newGameObject = new GameObject("Maze");
        mazeObject.transform.position = Vector3.zero;
        MeshFilter meshFilter = mazeObject.AddComponent<MeshFilter>();
        Mesh mesh = TestMesh();
        meshFilter.mesh = mesh;
        MeshRenderer meshRenderer = mazeObject.AddComponent<MeshRenderer>();
        meshRenderer.material = Resources.Load<Material>("wall-mat");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Mesh TestMesh()
    {
    // Our mesh will need a list of vertices.
    List<Vector3> newVertices = new List<Vector3>();

    // Declare 4 vertices. These points will form a square shape.
    newVertices = new List<Vector3>
    {
        new Vector3(-.5f, -.5f, 0),
        new Vector3(-.5f, .5f, 0),
        new Vector3(.5f, .5f, 0),
        new Vector3(.5f, -.5f, 0)
    };

    // Triangles are a way of defining edges and faces together.
    // The way this list is structured is quite specific:
    //     - Each element represents the index of a vertex from our newVertices list.
    //     - Every 3 indices indicate a triangle, so:
    //           - { 0, 1, 2... indicates a triangle between vertices 0, 1, and 2
    //           -  ...0, 2, 3} indicates a triangle between vertices 0, 2 and 3.
    //     - From these triangles, our mesh determines its edges and faces.
    List<int> newTriangles = new List<int> { 0, 1, 2, 0, 2, 3 };

    // UVs store the texture co-ordinates of each vertex 
    // (used to figure out which part of the texture goes on which part of the mesh.)
    List<Vector2> newUVs = new List<Vector2>();

    // Each UV is associated with a vertex. 
    // Don't worry about these too much, we won't do anything more advanced with them than this.
    newUVs = new List<Vector2>
    {
        new Vector2(1, 0),
        new Vector2(1, 1),
        new Vector2(0, 1),
        new Vector2(0, 0)
    };

    // Declare a new mesh instance.
    Mesh mesh = new Mesh();
    // Call SetVertices to assign our list of vertices to the mesh.
    mesh.SetVertices(newVertices);
    // Assign the UVs. The 0 isn't important, you can look it up if you're curious.
    mesh.SetUVs(0, newUVs);
    // Assign the triangles. Again, the 0 isn't important for this example. 
    // It's only relevant if our mesh is broken up into multiple sub-meshes (which we will do for the maze).
    mesh.SetTriangles(newTriangles, 0);

    return mesh;
    }
}
