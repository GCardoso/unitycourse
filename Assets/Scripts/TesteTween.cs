using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TesteTween : MonoBehaviour {

	public Text valorTexto;
	// Use this for initialization
	void Start () {
		LTDescr tween = LeanTween.move(this.gameObject, new Vector3(0, 3, 0), 3);
		tween.setFrom(new Vector3(0, -5, 0));
		tween.setDelay(2);

		tween.setEase(LeanTweenType.easeInBounce);
		tween.setOnUpdate(EscreveValor);
		tween.setEase(LeanTweenType.easeOutQuad);
	}

	private void EscreveValor(float valor) {
		valorTexto.text = ((int) valor).ToString();
	}
}
