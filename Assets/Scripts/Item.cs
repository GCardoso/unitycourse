using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour {

	[SerializeField]
	private Rigidbody2D rb;


	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	void Awake(){
		this.rb.velocity = new Vector2(0, -2f);
	}

	public void OnTriggerEnter2D(Collider2D collider) {
		//Colidiu com alguma coisa
		Debug.Log("colidiu");
		if (collider.transform.tag == "Player") {
			Colidiu();
			Destroy(this.gameObject);
		}
	}

	protected abstract void Colidiu();

	public void SetarPosicao(Vector2 position){
		this.transform.position = position;
	}
}
