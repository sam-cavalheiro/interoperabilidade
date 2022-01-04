using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Text;
using UnityEngine;

public class FabricaXML
{
    // TODO Testar em build
    public void EscreverXML(string caminho, Partida partida)
    {
        IFormatProvider floatFormat = System.Globalization.CultureInfo.InvariantCulture;

        //XmlTextWriter writer = new XmlTextWriter(@"D:\Desenvolvimento\Projetos da Faculdade\Período atual\Interoperabilidade\Aula 03\arquivo gerado.xml", null);
        XmlTextWriter writer = new XmlTextWriter(caminho, null);
        writer.WriteStartDocument();
        writer.Formatting = Formatting.Indented;

        Corredor corredor1 = partida.Corredor1;
        Corredor corredor2 = partida.Corredor2;
        Vector2 corredorPosicao1 = corredor1.Posicao;
        Vector2 corredorPosicao2 = corredor2.Posicao;
        Color corredorCor1 = corredor1.Cor;
        Color corredorCor2 = corredor2.Cor;

        writer.WriteStartElement("PARTIDA");

        writer.WriteStartElement("CORREDOR1");
        //writer.WriteElementString("POSICAO", corredor1.Posicao.ToString());

        writer.WriteStartElement("POSICAO");
        writer.WriteElementString("X", corredorPosicao1.x.ToString(floatFormat));
        writer.WriteElementString("Y", corredorPosicao1.y.ToString(floatFormat));
        writer.WriteEndElement();

        //writer.WriteElementString("COR", corredor1.Cor.ToString());
        writer.WriteStartElement("COR");
        writer.WriteElementString("R", corredorCor1.r.ToString(floatFormat));
        writer.WriteElementString("G", corredorCor1.g.ToString(floatFormat));
        writer.WriteElementString("B", corredorCor1.b.ToString(floatFormat));
        writer.WriteEndElement();

        writer.WriteElementString("VOLTAS", corredor1.VoltasRealizadas.ToString());

        writer.WriteEndElement();

        writer.WriteStartElement("CORREDOR2");
        //writer.WriteElementString("POSICAO", corredor1.Posicao.ToString());

        writer.WriteStartElement("POSICAO");
        writer.WriteElementString("X", corredorPosicao2.x.ToString(floatFormat));
        writer.WriteElementString("Y", corredorPosicao2.y.ToString(floatFormat));
        writer.WriteEndElement();

        //writer.WriteElementString("COR", corredor1.Cor.ToString());
        writer.WriteStartElement("COR");
        writer.WriteElementString("R", corredorCor2.r.ToString(floatFormat));
        writer.WriteElementString("G", corredorCor2.g.ToString(floatFormat));
        writer.WriteElementString("B", corredorCor2.b.ToString(floatFormat));
        writer.WriteEndElement();

        writer.WriteElementString("VOLTAS", corredor2.VoltasRealizadas.ToString());

        writer.WriteEndElement();

        writer.WriteElementString("MAXIMO_VOLTAS", partida.MaximoVoltas.ToString());

        writer.WriteFullEndElement();

        writer.Close();
    }

    /*public string LerXMLDeArquivo()
    {
        return System.IO.File.ReadAllText(@"D:\Desenvolvimento\Projetos da Faculdade\Período atual\Interoperabilidade\Aula 03\arquivo gerado.xml");
    }*/

    public string LerXMLDeArquivo(string caminho)
    {
        return System.IO.File.ReadAllText(caminho);
    }

    public Partida ConverterXMLParaPartida(string xml)
    {
        byte[] byteArray = Encoding.UTF8.GetBytes(xml);
        MemoryStream stream = new MemoryStream(byteArray);

        XmlTextReader xtr = new XmlTextReader(stream);

        Partida p = new Partida();
        //p.Corredor1 = new Corredor();
        //p.Corredor2 = new Corredor();

        Corredor atualCorredor = p.Corredor1;

        while (xtr.Read())
        {
            if (xtr.NodeType == XmlNodeType.Element)
            {
                switch (xtr.Name)
                {
                    // Elemento "POSICAO"
                    case "X":
                        atualCorredor.Posicao.x = xtr.ReadElementContentAsFloat(); break;
                    case "Y":
                        atualCorredor.Posicao.y = xtr.ReadElementContentAsFloat(); break;

                    // Elemento "COR"
                    case "R":
                        atualCorredor.Cor.r = xtr.ReadElementContentAsFloat(); break;
                    case "G":
                        atualCorredor.Cor.g = xtr.ReadElementContentAsFloat(); break;
                    case "B":
                        atualCorredor.Cor.b = xtr.ReadElementContentAsFloat();
                        atualCorredor.Cor.a = 1f;
                        break;

                    case "VOLTAS":
                        atualCorredor.VoltasRealizadas = xtr.ReadElementContentAsInt();
                        atualCorredor = p.Corredor2;
                        break;

                    case "MAXIMO_VOLTAS":
                        p.MaximoVoltas = xtr.ReadElementContentAsInt();
                        return p;
                }
            }
        }

        return null;
    }

    /*public Pessoa ConverterXMLParaPessoa(string xml)
    {
        byte[] byteArray = Encoding.UTF8.GetBytes(xml);
        MemoryStream stream = new MemoryStream(byteArray);

        XmlTextReader xtr = new XmlTextReader(stream);

        Pessoa p = new Pessoa();

        while (xtr.Read())
        {
            if (xtr.NodeType == XmlNodeType.Element)
            {
                switch (xtr.Name)
                {
                    case "ID":
                        p.Id = xtr.ReadElementContentAsInt(); break;
                    case "NOME":
                        p.Nome = xtr.ReadElementContentAsString(); break;
                    case "IDADE":
                        p.Idade = xtr.ReadElementContentAsInt(); break;
                    case "CIDADE":
                        p.Cidade = xtr.ReadElementContentAsString();
                        return p;
                }
            }
        }

        return null;
    }*/

}