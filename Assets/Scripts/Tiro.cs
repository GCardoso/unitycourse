using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiro : MonoBehaviour {

	public Rigidbody2D rb;
	public float velocidade;

	// Use this for initialization
	void Start () {
		this.rb.velocity = new Vector2(0, velocidade);
		Destroy(this.gameObject, 2f);
	}
	
	// Update is called once per frame
	void Update () {
		
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
