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
	private int quantidadeTiros = 1;
	[SerializeField]
	private SpriteRenderer spriteRenderer;
	
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
		move();
		shoot();
	}

	void shoot() {
		this.tempoDecorridoTiro += Time.deltaTime;

		bool atirar = Input.GetKey(KeyCode.Space);

		if (atirar) {
			Debug.Log("atirou");
			//Se o tempo decorrido for maior que o intervalo entre os tiros
			if (this.tempoDecorridoTiro >= this.intervaloTiro) {
				this.tempoDecorridoTiro = 0;
				Debug.Log("entrou no intervalotiro");
				if (this.quantidadeTiros % 2 != 0) {
					Debug.Log("entrou no quantidadeTiro");
					bool paraDireita = true;
					this.CriarTiro(0f, 0f);
					for (int i = 2; i <= this.quantidadeTiros; i++) {
						int vetorDirecao = paraDireita ? 1 : -1;
						this.CriarTiro(vetorDirecao * 0.4f, -0.4f);
						paraDireita = !paraDireita;
					}
				} else {
					Debug.Log("nao deveria entrar aqui");
				}
			}
		}
	}

	private void CriarTiro(float offsetX, float offsetY) {
		//Cria um novo tiro baseado no objeto de referência
		Tiro tiro = Tiro.Instantiate(this.tiroPrefab);
		
		//Obtém a posição atual da nave
		Vector2 posicao = (Vector2)this.transform.position;
		posicao.x = posicao.x + offsetX;
		posicao.y = posicao.y + offsetY;

		//Define a posição atual do tiro
		tiro.SetarPosicao (posicao);
		tiro.SetarDirecao(false);
	}

	void move() {
		bool moverCima = Input.GetKey(KeyCode.W);
		bool moverBaixo = Input.GetKey(KeyCode.S);
		bool moverEsquerda = Input.GetKey(KeyCode.A);
		bool moverDireita = Input.GetKey(KeyCode.D);
		int x, y;

		x = moverDireita ? 1 : moverEsquerda ? -1 : 0;
		y = moverCima ? 1 : moverBaixo ? -1 : 0;
		
		Vector2 posicao = new Vector2(x * this.velocity, y * this.velocity);
		this.rb.velocity = posicao;

		//Testa se o jador saiu da tela
		ControladorCamera controladorCamera = ControladorCamera.GetInstancia();
		posicao = this.transform.position;
		posicao.y -= (GetAltura() / 2);
		//Verifica se saiu pela parte de baixo
		if (controladorCamera.EstaForaTelaBaixo(posicao)) {
			Debug.Log("entrou");
			Vector2 posicaoMundo = controladorCamera.GetPosicaoMundo(Vector2.zero);
			posicao = this.transform.position;
			posicao.y = (posicaoMundo.y + (GetAltura() / 2));
			this.transform.position = posicao;
		}

	}

	public float GetAltura() {
		return spriteRenderer.bounds.size.y;
	}

	public void OnTriggerEnter2D(Collider2D collider) {
		if (collider.gameObject.CompareTag("TiroInimigo")) {
			//this.vidas--;
		} 
		if (this.vidas <= 0 || collider.gameObject.CompareTag("Inimigo")) {
			Destroy(this.gameObject);
			ControladorJogo.GetInstancia().ExibirFimDeJogo();
		}
		if (!collider.gameObject.CompareTag("TiroJogador")) {
			Destroy(collider.gameObject);
		}
	}
	public void SetaIntervaloTiro(float intervalo) {
		this.intervaloTiro = intervalo;		
	}

	public void SetarPrefabTiro(Tiro tiroPrefab) {
		this.tiroPrefab = tiroPrefab;
	}

	public void SetarQuantidadeTiros(int quantidadeTiros) {
		this.quantidadeTiros = quantidadeTiros;
	}

}
