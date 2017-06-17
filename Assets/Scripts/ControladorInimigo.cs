using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorInimigo : MonoBehaviour {

	public Inimigo inimigoPrefab;
	private float tempoDecorrido = 0;
	public Transform[] spawnPoints;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		tempoDecorrido += Time.deltaTime;
		if (tempoDecorrido >= 4f) {
			tempoDecorrido = 0;
			Inimigo inimigo = Inimigo.Instantiate(this.inimigoPrefab);

			//Escolhe um spawn point aleatoriamente
			int indiceSpawnPoint = Random.Range (0, this.spawnPoints.Length);
			Transform spawnPoint = this.spawnPoints[indiceSpawnPoint];


			Vector2 posicao = spawnPoint.position;
			inimigo.SetarPosicao (posicao);
		}
	}
}
