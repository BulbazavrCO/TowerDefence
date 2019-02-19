
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class MapGeneration : MonoBehaviour
{
    Mesh mesh;

    Vector3[] verices;
    int[] triangles;


    public void CreateMap(int xSize, int zSize, int coef)
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;


        CreateShape(xSize, zSize, coef);
        UpdateMesh();
    }

    void CreateShape(int xSize, int zSize, int coef)
    {
        xSize *= coef;
        zSize *= coef;
        verices = new Vector3[(xSize + 1) * (zSize + 1)];


        for (int i = 0, z = 0; z <= zSize; z++)
        {
            for (int x = 0; x <= xSize; x++)
            {
                float y = 0;
                if (x < xSize && z < zSize)
                {
                    ICell cell = GameManager.instance.Cells[x / coef, z / coef];
                    if (cell != null)
                        y = cell.pos.position.y;
                }
                verices[i] = new Vector3(x, y, z);
                i++;
            }
        }

        triangles = new int[xSize * zSize * 6];

        int vert = 0;
        int tris = 0;
        for (int z = 0; z < zSize; z++)
        {
            for (int x = 0; x < xSize; x++)
            {

                triangles[tris + 0] = vert + 0;
                triangles[tris + 1] = vert + xSize + 1;
                triangles[tris + 2] = vert + 1;
                triangles[tris + 3] = vert + 1;
                triangles[tris + 4] = vert + xSize + 1;
                triangles[tris + 5] = vert + xSize + 2;

                vert++;
                tris += 6;
            }
            vert++;
        }


    }

    void UpdateMesh()
    {
        mesh.Clear();

        mesh.vertices = verices;
        mesh.triangles = triangles;

        mesh.RecalculateNormals();
    }

}
