using UnityEngine;
using System.Collections;


public class Edge : MonoBehaviour
{
	public Graph graph;
	public Node node1;
	public Node node2;
	public float weight;

	public Node Other (Node ask)
	{
		if (ask == node1)
			return node2;
		else if (ask == node2)
			return node1;
		else
			return null;
	}

	public static Edge CreateEdge (Graph graph, Node node1, Node node2, float weight)
	{
		GameObject newEdgeGO = GameObject.Instantiate (GraphImporter.instance.edgePrefab) as GameObject;
		newEdgeGO.transform.SetParent (graph.transform);
		newEdgeGO.name = "Edge " + node1.name + "/" + node2.name + " (" + weight.ToString () + ")";
		Edge newEdge = newEdgeGO.GetComponent<Edge> ();

		newEdge.node1 = node1;
		newEdge.node2 = node2;

		node1.attractionlist.Add (newEdge);
		node2.attractionlist.Add (newEdge);

		newEdge.weight = weight;

		newEdge.graph = graph;
		graph.edges.Add (newEdge);

		return newEdge;

	}

	public virtual void Update ()
	{
		Vector3 pos1 = node1.transform.position;
		Vector3 pos2 = node2.transform.position;

		GetComponent<LineRenderer> ().SetPosition (0, pos1);
		GetComponent<LineRenderer> ().SetPosition (1, pos2);
		transform.position = Vector3.Lerp (pos1, pos2, 0.5f);
	}

}
