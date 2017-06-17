using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroItem : Item {

	[SerializeField]
	private Tiro tiroPrefab;
	[SerializeField]
	private float intervaloTiro;
	[SerializeField]
	private int quantidadeTiros = 1;

	protected override void Colidiu() {
		Nave.GetInstancia().SetaIntervaloTiro(this.intervaloTiro);
		Nave.GetInstancia().SetarPrefabTiro(this.tiroPrefab);
		Nave.GetInstancia().SetarQuantidadeTiros(this.quantidadeTiros);
	}

	protected int GetQuantidadeTiros() {
		return this.quantidadeTiros;
	}
}
