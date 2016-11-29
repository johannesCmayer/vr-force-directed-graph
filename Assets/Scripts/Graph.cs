using UnityEngine;
using System.Collections.Generic;

public class Graph : MonoBehaviour
{
	public static Graph instance;
	public GameObject center;
	public float repulsion;
	public float attraction;
	public float springLength;
	public float damping;

	public List<Node> nodes = new List<Node> ();
	public List<Edge> edges = new List<Edge> ();


	public void Awake ()
	{
		instance = this;

	}

}