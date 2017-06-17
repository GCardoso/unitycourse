using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour {

	[SerializeField]
	private Rigidbody2D rb;
	[SerializeField]
	private float velocidadeMovimentacao;


	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	void Awake(){
		this.rb = GetComponent<Rigidbody2D>();
		this.rb.velocity = new Vector2(0, -2f);

	}

	public void OnTriggerEnter2D(Collider2D collider) {
		//Colidiu com alguma coisa
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
