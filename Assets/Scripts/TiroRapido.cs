using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroRapido : Item {

	[SerializeField]
	private Tiro tiroRapidoPrefab;

	protected override void Colidiu() {
		Nave.GetInstancia().SetaIntervaloTiro(0.04f);
		Nave.GetInstancia().SetarPrefabTiro(this.tiroRapidoPrefab);
	}
}
