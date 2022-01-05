using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FimDeJogoCena : MonoBehaviour
{
    [SerializeField] TMPro.TMP_Text textoVitoria;
    [SerializeField] int menuPrincipalCenaId = 0;

    // Start is called before the first frame update
    void Start()
    {
        char vitoriosoNumero;
        Partida partida = DadosJogo.partida;
        if (partida.Corredor1.VoltasRealizadas > partida.Corredor2.VoltasRealizadas)
        {
            vitoriosoNumero = '1';
        }
        else
        {
            vitoriosoNumero = '2';
        }

        textoVitoria.text = "Jogador " + vitoriosoNumero + " venceu!";
    }

    public void Comando_Continuar()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(menuPrincipalCenaId);
    }
}
