using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Utility // MonoBehaviour ��� �ȹ޾Ƶ� ��
{
    public static Mesh CreateMeshQuad(string _name = "Default")
    {
        Mesh mesh = new Mesh();
        mesh.name = _name;

        // 0 -- 1
        // |    |
        // 2 -- 3
        // Vertex / Vertex Buffer
        Vector3[] vertices = new Vector3[4] {
            new Vector3(-0.5f, 0.5f, 0f), // Vertex Buffer
            new Vector3(0.5f, 0.5f, 0f),  // Vertex Buffer
            new Vector3(-0.5f, -0.5f, 0f), // Vertex Buffer
            new Vector3(0.5f, -0.5f, 0f), // Vertex Buffer
        };
        mesh.vertices = vertices;

        // Index / Index Buffer
        // [CW] ����Ƽ / CCW
        // �ﰢ���� �׸��� ������ ���� �ո�� �޸��� ������
        // Backface Culling(���� ����) ������ �ʴ� �޸��� �׸��� ����
        int[] indices = new int[6] {
            0,1,2,
            1,3,2
        };
        // 012�� ���� �������. �ð�������� �׷���

        mesh.triangles = indices;

        // UV Coordinate
        // Texture / Texture Mapping
        Vector2[] uvs = new Vector2[4] {
            new Vector2(0f, 1f),  // LU
            new Vector2(1f, 1f),  // RU
            new Vector2(0f, 0f),  // LD
            new Vector2(1f, 0f),  // RD
        };
        mesh.uv = uvs;

        // Normal Vector
        Vector3[] normals = new Vector3[4] {
            new Vector3(0f, 0f, -1f),
            new Vector3(0f, 0f, -1f),
            new Vector3(0f, 0f, -1f),
            new Vector3(0f, 0f, -1f),

        };
        mesh.normals = normals;

        return mesh;
    }

    public static bool Picking(ref Vector3 _point) {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit)) {
            _point = hit.point;
            return true;
        }
        return false;
    }

}