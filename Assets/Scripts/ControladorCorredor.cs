using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(Rigidbody2D))]
public class ControladorCorredor : MonoBehaviour
{
    public float aceleracao = 1f;
    public float desaceleracao = 1f;
    public float velocidadeRotacao = 1f;
    public float velocidadeMovimentoMaxima = 10f;

    Corredor corredor;
    string inputPrefix;
    float velocidadeMovimento;

    public void Setup(bool jogadorUm)
    {
        if (jogadorUm)
        {
            corredor = DadosJogo.partida.Corredor1;
            inputPrefix = "p1_";
        }
        else
        {
            corredor = DadosJogo.partida.Corredor2;
            inputPrefix = "p2_";
        }

        if (DadosJogo.carregouPorArquivo)
        {
            transform.position = corredor.Posicao;
            velocidadeMovimento = corredor.Velocidade;
            transform.eulerAngles = Vector3.forward * corredor.Angulo;
        }

        GetComponent<SpriteRenderer>().color = corredor.Cor;
    }

    // Update is called once per frame
    void Update()
    {
        // Atualizar as informações pertinentes do Corredor para salvar arquivo
        corredor.Posicao = transform.position;
        corredor.Angulo = transform.eulerAngles.z;
        corredor.Velocidade = velocidadeMovimento;

        // Movimentação
        //rb.AddForce(transform.up * Input.GetAxis(inputPrefix + "Vertical") * aceleracao);
        transform.eulerAngles -= Vector3.forward * Input.GetAxis(inputPrefix + "Horizontal") * velocidadeRotacao * Time.deltaTime;
        velocidadeMovimento += Input.GetAxis(inputPrefix + "Vertical") * aceleracao * Time.deltaTime;

        transform.position += transform.up * velocidadeMovimento;

        if (velocidadeMovimento < 0f)
        {
            //velocidadeMovimento = Mathf.Min(velocidadeMovimento + Time.deltaTime, 0f);
            velocidadeMovimento = Mathf.Clamp(velocidadeMovimento + desaceleracao * Time.deltaTime, -velocidadeMovimentoMaxima, 0f);
        }
        else if (velocidadeMovimento > 0f)
        {
            //velocidadeMovimento = Mathf.Max(velocidadeMovimento - Time.deltaTime, 0f);
            velocidadeMovimento = Mathf.Clamp(velocidadeMovimento - desaceleracao * Time.deltaTime, 0f, velocidadeMovimentoMaxima);
        }
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.CompareTag("Chegada"))
        {
            if (++corredor.VoltasRealizadas > DadosJogo.partida.MaximoVoltas)
                FindObjectOfType<GerenciadorJogo>().FimDeJogo();
        }
    }
}
