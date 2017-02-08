using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class VertexLitSphere : MonoBehaviour {

	[SerializeField]
	float width = 10;

	[SerializeField]
	float height = 10;

	// Use this for initialization
	void Start () {
		//BasicSquare();
		StripOfSquares(10);
	}

	void DrawAnIcosahedron(float x, float y)
	{
		//lets start from origin.

	}

	/// <summary>
	/// Draws a grid of square polygons.
	/// </summary>
	/// <param name="rows">Row size.</param>
	/// <param name="columns">Column size.</param>
	void PatchOfSquare(int rows, int columns)
	{
		var meshFilter = GetComponent<MeshFilter>();
		var mesh = new Mesh();

		// vertices have an extra row/column for padding the edges.
		Vector3[] vertices = new Vector3[(rows + 1) * (columns + 1)];

		// x * y * number of triangles per cell * number of vertices per triangle
		int[] tri = new int[rows * columns * 2 * 3]; 

		// Now we programmaticall draw the patch.
		for(int i = 0; i < columns + 1; i ++)
		{
			for(int j = 0; j < rows + 1; j++)
			{
				vertices[i + j] = new Vector3(width * i, height * j, 0);
			}
		}

		// Draw triangles.
		for (int i = 0; i < columns; i++ )
		{
			for (int j = 0; j < columns; j++)
			{
				int a = (i + j) * 6; // this is the square offset.

				// Our base line is a 2 x 2 square.
				tri[a] = i + j;								// 0
				tri[a + 1] = i + columns / 2;		        // 3
				tri[a + 2] = i + 1;							// 1

				tri[a + 3] = i + vertices.Length / 2;		// 3
				tri[a + 4] = i + vertices.Length / 2 + 1;	// 4
				tri[a + 5] = i + 1;							// 1
			}
		}

		// Assign the colors.
		for (int i = 0; i < vertices.Length; i++)
		{

		}

		// Assign the lists.
		meshFilter.mesh = mesh;
		mesh.vertices = vertices;
		mesh.triangles = tri;
	}

	/// <summary>
	/// Draws a strip of rectangles with vector colors assigned.
	/// </summary>
	/// <param name="numberOfStrips">Number of strips in this mesh.</param>
	void StripOfSquares(int numberOfStrips)
	{
		var meshFilter = GetComponent<MeshFilter>();
		var mesh = new Mesh();

		Vector3[] vertices = new Vector3[numberOfStrips * 2 + 2];
		int[] tri = new int[6 * numberOfStrips];

		vertices[0] = new Vector3(0, 0, 0); // v0
		vertices[vertices.Length/2] = new Vector3(0, height, 0); // v2

		/*
			vertices[0] = new Vector3(0, 0, 0);
			vertices[1] = new Vector3(width, 0, 0);
			vertices[2] = new Vector3(0, height, 0);
			vertices[3] = new Vector3(width, height, 0);
		 */

		// Create 4 strips.
		for (int i = 0; i < numberOfStrips; i++)
		{
			vertices[i + vertices.Length / 2 + 1] = new Vector3(width * i + width, height, 0); // v3
			vertices[i + 1] = new Vector3(width + width * i, 0, 0); // v1

			int a = i * 6;

			// goes through the following sequence and repeat.
			tri[a] = i;									// 0
			tri[a + 1] = i + vertices.Length / 2;		// 2
			tri[a + 2] = i + 1;							// 1

			tri[a + 3] = i + vertices.Length / 2;		// 2
			tri[a + 4] = i + vertices.Length / 2 + 1;	// 3
			tri[a + 5] = i + 1;							// 1
		}

		meshFilter.mesh = mesh;
		mesh.vertices = vertices;
		mesh.triangles = tri;

		Debug.Log(printVectors(vertices));
		Debug.Log(printTriangles(tri));
		//mesh.normals = normals;
		//mesh.uv = uv;

		Color32[] colors = new Color32[vertices.Length];

		for (int i = 0; i < vertices.Length; i++)
		{
			colors[i] = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
		}

		mesh.colors32 = colors;
	}

	string printVectors(Vector3[] v)
	{
		string s = "";

		foreach( var v1 in v)
		{
			s += string.Format("[{0}]", v1);
		}

		return s;
	}

	string printTriangles(int[] tri)
	{
		string s = "";
		int tris = tri.Length / 3;

		for (int i = 0; i < tris; i++ )
		{
			s += string.Format("tri" + i + "[{0}, {1}, {2}]", tri[i * 3], tri[(i * 3 + 1)], tri[(i * 3 + 2)]);
		}

		return s;
	}

	void BasicSquare()
	{
		var meshFilter = GetComponent<MeshFilter>();
		var mesh = new Mesh();

		Vector3[] vertices = new Vector3[4];
		vertices[0] = new Vector3(0, 0, 0);
		vertices[1] = new Vector3(width, 0, 0);
		vertices[2] = new Vector3(0, height, 0);
		vertices[3] = new Vector3(width, height, 0);

		int[] tri = new int[6];
		tri[0] = 0;
		tri[1] = 2;
		tri[2] = 1;

		tri[3] = 2;
		tri[4] = 3;
		tri[5] = 1;

		Vector3[] normals = new Vector3[4];
		normals[0] = Vector3.forward;
		normals[1] = Vector3.forward;
		normals[2] = Vector3.forward;
		normals[3] = Vector3.forward;

		Vector2[] uv = new Vector2[4];
		uv[0] = new Vector2(0, 0);
		uv[1] = new Vector2(1, 0);
		uv[2] = new Vector2(0, 1);
		uv[3] = new Vector2(1, 1);

		//colors
		Color32[] colors = new Color32[vertices.Length];

		colors[0] = Color.cyan;
		colors[1] = Color.yellow;
		colors[2] = Color.blue;
		colors[3] = Color.green;

		//for (int i = 0; i < vertices.Length; i++ )
		//{
		//	colors[i] = Color32.Lerp(Color.red, Color.cyan, vertices[i].y);
		//}

		meshFilter.mesh = mesh;
		mesh.vertices = vertices;
		mesh.triangles = tri;
		//mesh.normals = normals;
		//mesh.uv = uv;
		mesh.colors32 = colors;
	}

	// Update is called once per frame
	void Update () {
	}
}
