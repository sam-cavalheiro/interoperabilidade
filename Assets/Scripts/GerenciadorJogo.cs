using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GerenciadorJogo : MonoBehaviour
{
    const string PARTIDA_XML_CAMINHO = "partida.xml";

    void Start()
    {
        ControladorCorredor[] jogadores = FindObjectsOfType<ControladorCorredor>();

        jogadores[0].transform.localScale += Vector3.up;
        jogadores[0].Setup(true);
        jogadores[1].Setup(false);
    }

    void OnApplicationQuit()
    {
        FabricaXML fabricaXml = new FabricaXML();
        fabricaXml.EscreverXML(Directory.GetCurrentDirectory() + '/' + PARTIDA_XML_CAMINHO, DadosJogo.partida);
    }
}
