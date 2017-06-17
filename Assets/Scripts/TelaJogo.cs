using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TelaJogo : MonoBehaviour {

	[SerializeField]
	private Text pontuacaoTexto;

	
	// Update is called once per frame
	void Update () {
		this.pontuacaoTexto.text = ControladorPontuacao.GetPontuacao().ToString();
	}
}
