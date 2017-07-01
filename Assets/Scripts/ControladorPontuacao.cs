using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ControladorPontuacao {
    private const string BEST_SCORE = "best_score";

    //Pontuação atual do jogador
    private static int score = 0;

	public static void IncrementarPontuacao(int valor) {
		score += valor;
		int bestScore = PlayerPrefs.GetInt(BEST_SCORE, 0);
		if (score > bestScore) {
			PlayerPrefs.SetInt(BEST_SCORE, score);
		}
	}

	public static void Reiniciar() {
		score = 0;
	}

	public static void DecrementarPontuacao(int valor) {
		score -= valor;
	}
	
	public static int GetPontuacao() {
		return score;
	}
}
