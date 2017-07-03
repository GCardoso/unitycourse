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
        LTDescr tween = LeanTween.scale(this.painel, Vector3.one, 0.35f);
		tween.setFrom(Vector3.one * 2);
		tween.setEase(LeanTweenType.easeOutBack);

		int pontuacao = ControladorPontuacao.GetPontuacao();
		tween = LeanTween.value(0, pontuacao, 3);
		tween.setEase(LeanTweenType.easeOutCubic);
		tween.setOnUpdate(EscreveValor);
    }

	private void EscreveValor(float valor) {
		pontuacaoTexto.text = ((int) valor).ToString();
	}
}
