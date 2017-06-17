using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controladoritem : MonoBehaviour {

	[SerializeField]
	private Item[] itemPrefabs;
	private float tempoDecorridoCriacao;
	[SerializeField]
	private float intervaloCriacao;
	[SerializeField]
	private Transform[] spawnpoints;
	//Intervalos para gerar um random e criar o item
	[SerializeField]
	private float intervaloMinimo;
	[SerializeField]
	private float intervaloMaximo;
	// Use this for initialization
	
	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	void Awake() {
		this.tempoDecorridoCriacao = 0;
		this.intervaloCriacao = Random.Range(this.intervaloMinimo, this.intervaloMaximo);
	}
	
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.tempoDecorridoCriacao += Time.deltaTime;
		if (this.tempoDecorridoCriacao >= this.intervaloCriacao) {
			this.tempoDecorridoCriacao = 0;
			CriarItemAleatorio();
		}
	}

	private void CriarItemAleatorio() {
		this.intervaloCriacao = Random.Range(this.intervaloMinimo, this.intervaloMaximo);
		//Escolhe um item aleatoriamente para ser criado
		int indiceItem = Random.Range(0, this.itemPrefabs.Length);
		Item itemPrefab = this.itemPrefabs[indiceItem];
		//Cria o novo item
		Item item = Item.Instantiate(itemPrefab);

		//Escolhe um spawnpoint aleatoriamente
		int indiceSpawnpoint = Random.Range(0, this.spawnpoints.Length);
		Transform spawnpoint = this.spawnpoints[indiceSpawnpoint];
		//Move o item para a posição do spawnpoiint
		Vector2 posicao = spawnpoint.position;
		item.SetarPosicao(posicao);
	}
}
