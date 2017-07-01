using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TelaFimJogo : MonoBehaviour {

	[SerializeField]
	private Text pontuacaoTexto;
	[SerializeField]
	private Text melhorPontuacaoTexto;
	[SerializeField]
	private RectTransform painel;

	// Use this for initialization
	void Start () {
		this.melhorPontuacaoTexto.text = PlayerPrefs.GetInt("best_score").ToString();		
		this.pontuacaoTexto.text = ControladorPontuacao.GetPontuacao().ToString();
		ExecutarAnimacao();
		ControladorPontuacao.Reiniciar();
	}

    private void ExecutarAnimacao() {
        //throw new NotImplementedException();
    }
}
