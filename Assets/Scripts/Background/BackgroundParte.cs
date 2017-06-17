using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundParte : MonoBehaviour {

    [SerializeField]
    private float largura;

    [SerializeField]
    private float altura;
    

    /// <summary>
    /// Identifica se a parte do background está dentro dos limites da tela
    /// </summary>
    private bool estaDentroTela;


    private ControladorBackground controladorBackground;
   



    
    private void Update() {
        ControladorCamera controladorCamera = ControladorCamera.GetInstancia();
        Vector2 position = this.transform.position;
        position.y -= (GetAltura() / 2f);
        // Esta fora da tela
        if (!estaDentroTela) {            
            if (controladorCamera.EstaDentroTelaVertical(position)) {
                this.estaDentroTela = true;                
            }
        } else {
            // Caso esteja dentro da tela
            position = this.transform.position;
            position.y += (GetAltura() / 2f);
            if (controladorCamera.EstaForaTelaBaixo(position)) {
                this.estaDentroTela = false;
                this.controladorBackground.SaiuTela(this);
            }
        }

    }

    private void OnDrawGizmos() {
        Vector2 origem;
        Vector2 destino;
    
        float metadeLargura = (this.largura / 2);
        float metadeAltura = (GetAltura() / 2);

        Gizmos.color = new Color(1, 0.7647f, 0);

        origem = (this.transform.position + new Vector3(-metadeLargura, -metadeAltura, 0));
        destino = (this.transform.position + new Vector3(metadeLargura, -metadeAltura, 0));
        Gizmos.DrawLine(origem, destino);

        origem = (this.transform.position + new Vector3(-metadeLargura, metadeAltura, 0));
        destino = (this.transform.position + new Vector3(metadeLargura, metadeAltura, 0));
        Gizmos.DrawLine(origem, destino);

        origem = (this.transform.position + new Vector3(-metadeLargura, -metadeAltura, 0));
        destino = (this.transform.position + new Vector3(-metadeLargura, metadeAltura, 0));
        Gizmos.DrawLine(origem, destino);

        origem = (this.transform.position + new Vector3(metadeLargura, -metadeAltura, 0));
        destino = (this.transform.position + new Vector3(metadeLargura, metadeAltura, 0));
        Gizmos.DrawLine(origem, destino);
    }


    public void Inicializar(ControladorBackground controlador) {
        this.controladorBackground = controlador;
        ControladorCamera controladorCamera = ControladorCamera.GetInstancia();
        Vector2 posicao = this.transform.position;
        //position.y += (GetHeight() / 2);
        if (controladorCamera.EstaDentroTelaVertical(posicao)) {
            this.estaDentroTela = true;
        } else {
            this.estaDentroTela = false;
        }        
    }

    /// <summary>
    /// Retorna a altura do BackgroundPart
    /// </summary>
    /// <returns></returns>
    public float GetAltura() {
        return this.altura;
    }

    public Vector2 GetPosicao() {
        return this.transform.position;
    }

    public void SetarPosicao(Vector2 posicao) {
        this.transform.position = posicao;
    }

    public void Mover(float velocidade) {
        Vector2 posicao = GetPosicao();
        posicao.y -= velocidade;
        this.transform.position = posicao;
    }



}
