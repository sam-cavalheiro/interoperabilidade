using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GerenciadorJogo : MonoBehaviour
{
    [SerializeField] ControladorCorredor jogador1;
    [SerializeField] ControladorCorredor jogador2;
    [SerializeField] int fimDeJogoCenaId = 2;

    void Start()
    {
        jogador1.Setup(true);
        jogador2.Setup(false);
        /*ControladorCorredor[] jogadores = FindObjectsOfType<ControladorCorredor>();

        jogadores[0].transform.localScale += Vector3.up;
        jogadores[0].Setup(true);
        jogadores[1].Setup(false);*/
    }

    public void FimDeJogo()
    {
        if (DadosJogo.ARMAZENANDO_JSON)
        {
            File.Delete("partida.json");
        }
        else
        {
            File.Delete("partida.xml");
        }
        UnityEngine.SceneManagement.SceneManager.LoadScene(fimDeJogoCenaId);
    }

    void OnApplicationQuit()
    {
        if (DadosJogo.ARMAZENANDO_JSON)
        {
            FabricaJSON fabricaJson = new FabricaJSON();
            fabricaJson.EscreverJSON(DadosJogo.partida, "partida.json");
        }
        else
        {
            FabricaXML fabricaXml = new FabricaXML();
            fabricaXml.EscreverXML("partida.xml", DadosJogo.partida);
        }
    }
}
