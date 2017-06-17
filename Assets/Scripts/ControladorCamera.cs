using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorCamera : MonoBehaviour {

	public Vector2 distancia;
	public Transform nave;
	public Camera cameraJogo;
	private static ControladorCamera instancia;

	public void Awake() {
		ControladorCamera.instancia = this;
	}

	// Use this for initialization
	void Start () {
		Vector3 posicao = this.nave.position;
		posicao.x += distancia.x;
		posicao.y += distancia.y;
		posicao.z = this.transform.position.z;
		this.transform.position = posicao;
	}

	public bool EstaForeTela(Vector2 posicao) {
		Vector3 posicaoViewPort = this.cameraJogo.WorldToViewportPoint (posicao);
		if ((posicaoViewPort.x < 0) || (posicaoViewPort.x > 1)) {
			return true;
		}

		return false;
	}

	public bool EstaForaTelaEsquerda(Vector2 posicao) {
		Vector3 posicaoViewPort = this.cameraJogo.WorldToViewportPoint (posicao);
		return (posicaoViewPort.x < 0);
	}

	public bool EstaForaTelaDireita(Vector2 posicao) {
		Vector3 posicaoViewPort = this.cameraJogo.WorldToViewportPoint (posicao);
		return (posicaoViewPort.x > 1);
	}

	public bool EstaForaTelaCima(Vector2 posicao) {
		Vector3 posicaoViewPort = GetPosicaoViewport(posicao);
		return posicaoViewPort.y > 1;
	}

	public bool EstaForaTelaBaixo(Vector2 posicao) {
		Vector3 posicaoViewPort = GetPosicaoViewport(posicao);
		return posicaoViewPort.y < 1;
	}

	// Update is called once per frame
	void Update () {
		
	}

	public Vector2 GetPosicaoViewport(Vector2 posicao) {
		Vector3 posicaoViewPort = this.cameraJogo.WorldToViewportPoint(posicao);
		return posicaoViewPort;
	}

	public static ControladorCamera GetInstancia() {
		return ControladorCamera.instancia;
	}

	public bool EstaDentroTelaVertical(Vector2 posicao) {
		return !this.EstaForaTelaCima(posicao) && !!this.EstaForaTelaBaixo(posicao);
	}
}
