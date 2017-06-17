using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nave : MonoBehaviour {

	//Intervalo padrão entre os disparos do jogador
	private const float INTERVALO_TIRO_PADRAO = 0.4f;

	[SerializeField]
	private Rigidbody2D rb;
	public float velocity = 5.0f;
	public Tiro tiroPrefab;
	//incrementa comTime.deltaTime
	public float tempoDecorridoTiro;
	//intervalo atual entre disparos
	public float intervaloTiro;
	//singleton
	private static Nave instancia;
	//Qtd de vidas do jogador
	private int vidas = 3;


	public static Nave GetInstancia() {
		return Nave.instancia;
	}

	public void Awake() {
		this.tempoDecorridoTiro = 0;
		this.intervaloTiro = INTERVALO_TIRO_PADRAO;
		Nave.instancia = this;
	}

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
		this.tempoDecorridoTiro += Time.deltaTime;

		bool atirar = Input.GetKey(KeyCode.Space);

		if (atirar) {
			//Se o tempo decorrido for maior que o intervalo entre os tiros
			if (this.tempoDecorridoTiro >= this.intervaloTiro) {
				this.tempoDecorridoTiro = 0;

				//Cria um novo tiro baseado no objeto de referência
				Tiro tiro = Tiro.Instantiate(this.tiroPrefab);
				//Obtém a posição atual da nave
				Vector2 posicao = (Vector2)this.transform.position;
				//Define a posição atual do tiro
				tiro.SetarPosicao (posicao);
				tiro.SetarDirecao(false);
			}
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
			this.vidas--;
			if (this.vidas <= 0) {
				Destroy(this.gameObject);
				ControladorJogo.GetInstancia().ExibirFimDeJogo();
			}
			Destroy(collider.gameObject);
		}
	}
	public void SetaIntervaloTiro(float intervalo) {
		this.intervaloTiro = intervalo;		
	}

	public void SetarPrefabTiro(Tiro tiroPrefab) {
		this.tiroPrefab = tiroPrefab;
	}

}
