using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class TesteXML : MonoBehaviour
{
    const string PARTIDA_XML_CAMINHO = "partida.xml";

    FabricaXML fabricaXml = new FabricaXML();

    [SerializeField] Partida partida;

    void OnGUI()
    {
        if (GUI.Button(new Rect(0, 0, 100, 32), "CARREGAR"))
        {
            try
            {
                string xml = fabricaXml.LerXMLDeArquivo(Directory.GetCurrentDirectory() + '/' + PARTIDA_XML_CAMINHO);
                partida = fabricaXml.ConverterXMLParaPartida(xml);
                print("Carregado!");
            }
            catch (Exception e)
            {
                print(e.Message + '\n' + e.StackTrace);
            }
        }
        else if (GUI.Button(new Rect(110, 0, 100, 32), "SALVAR"))
        {
            try
            {
                fabricaXml.EscreverXML(Directory.GetCurrentDirectory() + '/' + PARTIDA_XML_CAMINHO, partida);
                print("Salvo!");
            }
            catch (Exception e)
            {
                print(e.Message + '\n' + e.StackTrace);
            }
        }
    }
}
