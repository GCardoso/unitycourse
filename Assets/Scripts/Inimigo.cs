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
	private float velocityShip = 3;
	
	private int vidas = 3;
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

		ControladorCamera controladorCamera = ControladorCamera.GetInstancia();

		if (controladorCamera.EstaForaTelaEsquerda (this.transform.position)) {
			movendoEsquerda = false;
		} 

		if (controladorCamera.EstaForaTelaDireita (this.transform.position) ) {
			movendoEsquerda = true;
		}


//		if (tempoDecorrido >= 3f) {
//			tempoDecorrido = 0;
//			movendoEsquerda = !movendoEsquerda;
//		}

		if (tempoDecorridoTiro >= 0.8f && this.vidas > 0) {
			shoot();
			tempoDecorridoTiro = 0;
		}

		float direction = movendoEsquerda ? -1 : 1; 
		this.rb.velocity = new Vector2(direction * this.velocityShip, this.rb.velocity.y);
	}

	public void OnTriggerEnter2D(Collider2D collider) {
		if (collider.gameObject.CompareTag("TiroJogador")) {
			Tiro tiro = collider.gameObject.GetComponent<Tiro>();
			this.vidas -= tiro.GetDano();
			Destroy(collider.gameObject);

			if (this.vidas <= 0) {
				Destroy(this.gameObject);
			}
		}
	}

	public void SetarPosicao(Vector2 position) {
		this.transform.position = position;
	}
}
