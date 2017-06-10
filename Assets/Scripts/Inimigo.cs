using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour {
	public Rigidbody2D rb;
	public float velocidade;
	public Tiro tiroPrefab;

	private bool movendoEsquerda = false;
	private float tempoDecorrido = 0;
	private float tempoDecorridoTiro = 0;

	// Use this for initialization
	void Start () {
		
	}

	void shoot() {
		//Cria um novo tiro baseado no objeto de referência
		Tiro tiro = Tiro.Instantiate(this.tiroPrefab);
		//Obtém a posição atual da nave
		Vector2 posicao = (Vector2)this.transform.position;
		//Define a posição atual do tiro
		tiro.SetarPosicao (posicao);
		tiro.SetarDirecao(true);
	
	}

	// Update is called once per frame
	void Update () {
		tempoDecorrido += Time.deltaTime;
		tempoDecorridoTiro += Time.deltaTime;

		if (tempoDecorrido >= 3f) {
			tempoDecorrido = 0;
			movendoEsquerda = !movendoEsquerda;
		}

		if (tempoDecorridoTiro >= 0.8f) {
			shoot();
			tempoDecorridoTiro = 0;
		}

		float direction = movendoEsquerda ? -2 : 2; 
		this.rb.velocity = new Vector2(direction , this.rb.velocity.y);
	}

	public void OnTriggerEnter2D(Collider2D collider) {
		if (collider.gameObject.CompareTag("TiroJogador")) {
			Destroy(this.gameObject);
			Destroy(collider.gameObject);
		}
	}
}
