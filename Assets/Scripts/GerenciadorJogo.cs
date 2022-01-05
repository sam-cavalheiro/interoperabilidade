using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GerenciadorJogo : MonoBehaviour
{
    const string PARTIDA_XML_CAMINHO = "partida.xml";

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
        File.Delete(Directory.GetCurrentDirectory() + '/' + PARTIDA_XML_CAMINHO);
        UnityEngine.SceneManagement.SceneManager.LoadScene(fimDeJogoCenaId);
    }

    void OnApplicationQuit()
    {
        FabricaXML fabricaXml = new FabricaXML();
        fabricaXml.EscreverXML(Directory.GetCurrentDirectory() + '/' + PARTIDA_XML_CAMINHO, DadosJogo.partida);
    }
}
