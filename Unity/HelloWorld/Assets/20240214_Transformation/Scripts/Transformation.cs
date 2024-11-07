using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(MeshFilter))]
public class Transformation : MonoBehaviour
{
    [System.Serializable] // ����ü�� �̰� �߰������ �ν����� â���� �� �� ����.  Serialize ����ȭ 
    private struct MyTransform {
        public Vector3 pos;
        public Vector3 rot;
        public Vector3 scale;
    }

    // Mesh Filter
    // Mesh Renderer
    private MeshFilter mf = null;
    private MeshRenderer mr = null;

    [SerializeField] private MyTransform tr; // ����� ���� �ڷ����� �ٷ� �ν����� â�� �ȳ���
    // T:Translate
    private Matrix4x4 T = Matrix4x4.identity;

    private void Awake()
    {
        mf = GetComponent<MeshFilter>(); // GetComponent�� �տ� ������Ʈ�� ��� ���� ������ null ��
        mr = gameObject.AddComponent<MeshRenderer>(); // ������ ���� ����. �̹� ������ null�� ����

        tr.scale.x = 1f;
        tr.scale.y = 1f;
        tr.scale.z = 1f;
    }

    private void Start()
    {
        mf.mesh = Utility.CreateMeshQuad("Test Quad");

        // Material / shader
        Material mat = new Material(Shader.Find("Standard")); // Material���� shader�� �ݵ�� �־�� ��
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

        mf.mesh.vertices = vertices; // Vector3�� ����ü�̱� ������ ���� �ٲ㵵 ������ �ٲ��� ����. �׷��� ���� �� ���� �־������

        
    }

    private Matrix4x4 TRS() {
        Matrix4x4 world = Matrix4x4.identity;
        // Matrix4x4.identity; ���� ��� ��ȯ. �ִ밢���� 1�̰� �������� 0

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
        Rx.m22 = Mathf.Cos(tr.rot.x); // ��(Cos)����(Sin) ��(Sin) ��(Cos)

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
        world = T * Rx* Ry * Rz * S; // ���Ϸ����. ������ ���� �� ����
        //SRT
        //world = S * Rz * Ry * Rx * T;

        return world;
    }
}