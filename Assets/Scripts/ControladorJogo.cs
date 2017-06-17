using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorJogo : MonoBehaviour {

	private static ControladorJogo instancia;
	// Use this for initialization
	void Start () {
		
	}
		
	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	void Awake()
	{
		ControladorJogo.instancia = this;	
	}

	public static ControladorJogo GetInstancia() {
		return ControladorJogo.instancia;
	}

	// Update is called once per frame
	void Update () {
		
	}

	public void ExibirJogo() {
		SceneManager.LoadScene("Fase01");
	}

	public void ExibirFimDeJogo() {
		SceneManager.LoadScene("FimDeJogo");
	}
}
