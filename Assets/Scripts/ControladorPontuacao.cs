using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ControladorPontuacao {

	//Pontuação atual do jogador
	private static int pontuacao = 0;	

	public static void IncrementarPontuacao(int valor) {
		pontuacao += valor;
	}

	public static void DecrementarPontuacao(int valor) {
		pontuacao -= valor;
	}
	
	public static int GetPontuacao() {
		return pontuacao;
	}
}
