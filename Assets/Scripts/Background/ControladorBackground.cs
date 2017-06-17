using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorBackground : MonoBehaviour {

    // Partes do background    
    private BackgroundParte[] backgroundPartes;
    
    // Velocidade de movimentação do background
    [SerializeField]
    private float velocidadeMovimentoBackground;




    private void Start() {
        this.backgroundPartes = this.GetComponentsInChildren<BackgroundParte>();

        BackgroundParte parteAnterior = null;
        BackgroundParte parteAtual = null;
        for (int i = 0; i < this.backgroundPartes.Length; i++) {
            parteAtual = this.backgroundPartes[i];
            parteAtual.Inicializar(this);
            if (parteAnterior == null) {
                parteAtual.SetarPosicao(this.transform.position);
            } else {
                Vector2 position = parteAnterior.GetPosicao();
                position.y += ((parteAtual.GetAltura() / 2) + (parteAnterior.GetAltura() / 2));
                parteAtual.SetarPosicao(position);
            }
            parteAnterior = parteAtual;
        }
    }

    private void Update() {
        BackgroundParte parteAtual = null;
        for (int i = 0; i < this.backgroundPartes.Length; i++) {
            parteAtual = this.backgroundPartes[i];
            parteAtual.Mover((this.velocidadeMovimentoBackground * Time.deltaTime));
        }
    }

    // Método executado quando uma parte do background sair dos limites da tela
    public void SaiuTela(BackgroundParte backgroundParte) {
        BackgroundParte parteMaiorY = GetParteMaiorY();        
        Vector2 posicao = parteMaiorY.GetPosicao();
        posicao.y += ((backgroundParte.GetAltura() / 2) + (parteMaiorY.GetAltura() / 2));        
        backgroundParte.SetarPosicao(posicao);
    }

    // Retorna o BackgroundParte que está localizada na posição Y de maior valor
    private BackgroundParte GetParteMaiorY() {
        BackgroundParte parteMaiorY = null;
        BackgroundParte parteAtual = null;
        for (int i = 0; i < this.backgroundPartes.Length; i++) {
            parteAtual = this.backgroundPartes[i];
            if (parteMaiorY == null) {
                parteMaiorY = parteAtual;
            } else {
                Vector2 posicaoParteMaiorY = parteMaiorY.GetPosicao();
                Vector2 posicaoParteAtual = parteAtual.GetPosicao();
                if (posicaoParteAtual.y > posicaoParteMaiorY.y) {                    
                    parteMaiorY = parteAtual;
                }
            }
        }
        return parteMaiorY;
    }




}
