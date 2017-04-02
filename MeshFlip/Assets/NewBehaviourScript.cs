using UnityEngine;
using System.Collections;


//Aquired from: http://wiki.unity3d.com/index.php/ReverseNormals

public class NewBehaviourScript : MonoBehaviour {

    //Mesh mesh;

    //void Start()
    //{
    //    mesh = GetComponent<MeshFilter>().mesh;
    //    int[] newTri;
    //    newTri = new int[mesh.triangles.Length];  


    //    for(int i = 0; i < mesh.triangles.Length-2;i= i+2)
    //    {
    //        newTri[i] = mesh.triangles[i + 2];
    //        newTri[i+1] = mesh.triangles[i+1];
    //        newTri[i + 2] = mesh.triangles[i];

    //    }
    //    GetComponent<MeshFilter>().mesh.triangles = newTri;


    void Start()
    {
        MeshFilter filter = GetComponent(typeof(MeshFilter)) as MeshFilter;
        if (filter != null)
        {
            Mesh mesh = filter.mesh;

            Vector3[] normals = mesh.normals;
            for (int i = 0; i < normals.Length; i++)
                normals[i] = -normals[i];
            mesh.normals = normals;

            for (int m = 0; m < mesh.subMeshCount; m++)
            {
                int[] triangles = mesh.GetTriangles(m);
                for (int i = 0; i < triangles.Length; i += 3)
                {
                    int temp = triangles[i + 0];
                    triangles[i + 0] = triangles[i + 1];
                    triangles[i + 1] = temp;
                }
                mesh.SetTriangles(triangles, m);
            }
        }
    }



}


