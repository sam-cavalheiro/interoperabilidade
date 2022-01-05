using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TMPro.TMP_Text))]
public class JogadorHUD : MonoBehaviour
{
    [SerializeField] bool jogadorUm;

    TMPro.TMP_Text text;

    Corredor corredor;
    int maximoVoltas;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TMPro.TMP_Text>();

        Partida partida = DadosJogo.partida;

        maximoVoltas = partida.MaximoVoltas;

        if (jogadorUm)
        {
            corredor = partida.Corredor1;
        }
        else
        {
            corredor = partida.Corredor2;
        }
    }

    // Update is called once per frame
    void Update()
    {
        char numeroJogador;
        if (jogadorUm)
        {
            numeroJogador = '1';
        }
        else
        {
            numeroJogador = '2';
        }

        text.text = "Jogador " + numeroJogador  + "\nVoltas: " + corredor.VoltasRealizadas + '/' + maximoVoltas + "\nVelocidade: " + corredor.Velocidade;
    }
}
