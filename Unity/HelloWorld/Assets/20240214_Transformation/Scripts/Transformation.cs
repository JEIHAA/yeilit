using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(MeshFilter))]
public class Transformation : MonoBehaviour
{
    [System.Serializable] // 구조체는 이거 추가해줘야 인스펙터 창에서 볼 수 있음.  Serialize 직렬화 
    private struct MyTransform {
        public Vector3 pos;
        public Vector3 rot;
        public Vector3 scale;
    }

    // Mesh Filter
    // Mesh Renderer
    private MeshFilter mf = null;
    private MeshRenderer mr = null;

    [SerializeField] private MyTransform tr; // 사용자 정의 자료형은 바로 인스펙터 창에 안나옴
    // T:Translate
    private Matrix4x4 T = Matrix4x4.identity;

    private void Awake()
    {
        mf = GetComponent<MeshFilter>(); // GetComponent는 앞에 오브젝트가 없어도 가능 없으면 null 들어감
        mr = gameObject.AddComponent<MeshRenderer>(); // 없으면 새로 만듦. 이미 있으면 null이 나옴

        tr.scale.x = 1f;
        tr.scale.y = 1f;
        tr.scale.z = 1f;
    }

    private void Start()
    {
        mf.mesh = Utility.CreateMeshQuad("Test Quad");

        // Material / shader
        Material mat = new Material(Shader.Find("Standard")); // Material에는 shader가 반드시 있어야 함
        Texture2D tex = Resources.Load("Textures\\T_Waddle Dee")as Texture2D;
        mat.mainTexture = tex;

        mr.material = mat;
    }

    private void Update()
    {
        ResetMesh();
        Matrix4x4 world = TRS();
        LocalToWorld(world);
    }


    private void ResetMesh() {
        Mesh mesh = mf.mesh;

        Vector3[] vertices = new Vector3[4] {
            new Vector3(-0.5f, 0.5f, 0f), // Vertex Buffer
            new Vector3(0.5f, 0.5f, 0f),  // Vertex Buffer
            new Vector3(-0.5f, -0.5f, 0f), // Vertex Buffer
            new Vector3(0.5f, -0.5f, 0f), // Vertex Buffer
        };
        mesh.vertices = vertices;
    }

    private void LocalToWorld(Matrix4x4 _mWorld)
    {
        Vector3[] vertices = mf.mesh.vertices;
        for (int i = 0; i<vertices.Length; ++i)
        {
            vertices[i] = _mWorld.MultiplyPoint(vertices[i]);
        }

        mf.mesh.vertices = vertices; // Vector3는 구조체이기 때문에 값을 바꿔도 원본이 바뀌지 않음. 그래서 변경 후 직접 넣어줘야함

        
    }

    private Matrix4x4 TRS() {
        Matrix4x4 world = Matrix4x4.identity;
        // Matrix4x4.identity; 단위 행렬 반환. 주대각선은 1이고 나머지는 0

        // T: Translate
        Matrix4x4 T = Matrix4x4.identity;
        T.m03 = tr.pos.x;
        T.m13 = tr.pos.y;
        T.m23 = tr.pos.z;

        //R: Rotation
        //  1  0  0  0
        //  0  C -S  0
        //  0  S  C  0
        //  0  0  0  1
        Matrix4x4 Rx = Matrix4x4.identity;
        Rx.m11 = Mathf.Cos(tr.rot.x);
        Rx.m12 = Mathf.Sin(tr.rot.x) * -1f;
        Rx.m21 = Mathf.Sin(tr.rot.x);
        Rx.m22 = Mathf.Cos(tr.rot.x); // 꼬(Cos)마신(Sin) 신(Sin) 고(Cos)

        //  C  0  S  0
        //  0  1  0  0
        // -S  0  C  0
        //  0  0  0  1
        Matrix4x4 Ry = Matrix4x4.identity;
        Ry.m00 = Mathf.Cos(tr.rot.x);
        Ry.m02 = Mathf.Sin(tr.rot.x) * -1f;
        Ry.m20 = Mathf.Sin(tr.rot.x);
        Ry.m22 = Mathf.Cos(tr.rot.x); 

        // C -S  0  0
        // S  C  0  0
        // 0  0  1  0
        // 0  0  0  1
        Matrix4x4 Rz = Matrix4x4.identity;
        Rz.m00 = Mathf.Cos(tr.rot.x);
        Rz.m01 = Mathf.Sin(tr.rot.x) * -1f;
        Rz.m10 = Mathf.Sin(tr.rot.x);
        Rz.m11 = Mathf.Cos(tr.rot.x); 

        // S: Scale
        Matrix4x4 S = Matrix4x4.identity;
        S[0, 0] = tr.scale.x;
        S.m11 = tr.scale.y;
        S.m22 = tr.scale.z;

        //TRS
        world = T * Rx* Ry * Rz * S; // 오일러방식. 짐벌락 생길 수 있음
        //SRT
        //world = S * Rz * Ry * Rx * T;

        return world;
    }
}