using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiro : MonoBehaviour {

	private Rigidbody2D rb;
	public float velocidade;
	[SerializeField]
	private int dano;

	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	public void Awake(){
		this.rb = GetComponent<Rigidbody2D>();
	}

	// Use this for initialization
	void Start () {
		this.rb.velocity = new Vector2(0, velocidade);
		Destroy(this.gameObject, 2f);
	}
	
	public int GetDano() {
		return this.dano;
	}

	public void SetarPosicao(Vector2 posicao) {
		this.transform.position = posicao;
	}

	public void SetarDirecao(bool paraBaixo) {
		if (paraBaixo) {
			this.velocidade = (-1) * velocidade;
		}
	}

	public void OnTriggerEnter2D(Collider2D collider) {
		if (collider.gameObject.CompareTag("TiroInimigo")) {
			Destroy(this.gameObject);
			Destroy(collider.gameObject);
		}
	}
}
