using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nave : MonoBehaviour {

	public Rigidbody2D rb;
	public float velocity = 5.0f;
	public Tiro tiroPrefab;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		//Identifica se está cm a tecla W pressionada
		move();
		shoot();
	}

	void shoot() {
		bool atirar = Input.GetKeyDown(KeyCode.Space);
		if (atirar) {
			//Cria um novo tiro baseado no objeto de referência
			Tiro tiro = Tiro.Instantiate(this.tiroPrefab);
			//Obtém a posição atual da nave
			Vector2 posicao = (Vector2)this.transform.position;
			//Define a posição atual do tiro
			tiro.SetarPosicao (posicao);
			tiro.SetarDirecao(false);
		}
	}

	void move() {
		bool moverCima = Input.GetKey(KeyCode.W);
		bool moverBaixo = Input.GetKey(KeyCode.S);
		bool moverEsquerda = Input.GetKey(KeyCode.A);
		bool moverDireita = Input.GetKey(KeyCode.D);
		int x, y;

		x = moverDireita ? 1 : moverEsquerda ? -1 : 0;
		y = moverCima ? 1 : moverBaixo ? -1 : 0;

		this.rb.velocity = new Vector2(x * this.velocity, y * this.velocity);
	}

	public void OnTriggerEnter2D(Collider2D collider) {
		if (collider.gameObject.CompareTag("TiroInimigo")) {
			Destroy(this.gameObject);
			Destroy(collider.gameObject);
		}
	}
}
