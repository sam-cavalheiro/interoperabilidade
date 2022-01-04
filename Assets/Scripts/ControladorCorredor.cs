using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorCorredor : MonoBehaviour
{
    Corredor corredor;

    public void Setup(bool jogadorUm)
    {
        if (jogadorUm)
        {
            corredor = DadosJogo.partida.Corredor1;
        }
        else
        {
            corredor = DadosJogo.partida.Corredor2;
        }

        if (DadosJogo.carregouPorArquivo)
            transform.position = corredor.Posicao;

        GetComponent<SpriteRenderer>().color = corredor.Cor;
    }

    // Update is called once per frame
    void Update()
    {
        // Atualizar as informações pertinentes do Corredor para salvar arquivo
        Vector2 _posicao = transform.position;
        if (_posicao != corredor.Posicao)
            corredor.Posicao = _posicao;

        // TODO Dar um jeito de atualizar as voltas realizadas
    }
}
