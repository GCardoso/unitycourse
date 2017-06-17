using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruidorObjetos : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/// <summary>
	/// Sent when another object enters a trigger collider attached to this
	/// object (2D physics only).
	/// </summary>
	/// <param name="other">The other Collider2D involved in this collision.</param>
	public void OnTriggerEnter2D(Collider2D collider) {
		if (collider.gameObject.CompareTag("Player")) {
			ControladorJogo.GetInstancia().ExibirFimDeJogo();
		}
		Destroy(collider.gameObject);
	}
}
