using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TelaFimJogo : MonoBehaviour {

	[SerializeField]
	private Text pontuacaoTexto;
	// Use this for initialization
	void Start () {
		this.pontuacaoTexto.text = ControladorPontuacao.GetPontuacao().ToString();
	}
	
}
