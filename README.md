# Interoperabilidade

Trabalho realizado em 2022 para a disciplina "Interoperabilidade Aplicada a Jogos", do **Curso Superior em Tecnologia em Jogos Digitais** no **IFRJ CEPF** (Instituto de Educação, Ciência e Tecnologia do Rio de Janeiro, Campus Eng. Paulo de Frontin).

## Projeto

Leitura e escrita de arquivo XML e JSON (Newtonsoft) em projeto Unity em C#.

Todas as informações do jogo são salvas assim que o jogo é fechado, e carregadas assim que o jogo é aberto.

## Instruções

> Requer Unity (qualquer versão indicada pelo Unity Hub, já que o projeto é antigo e está usando uma versão com falha de segurança reconhecida).

### Configurando e executando

1. Clone ou baixe esse projeto: `git clone https://github.com/sam-cavalheiro/interoperabilidade.git`;
2. Ao terminar de baixar ou clonar, abra o projeto em uma versão segura do Unity;
3. Abra o script `Assets/Scripts/DadosJogo.cs` e mude a constante booleana `ARMAZENANDO_JSON` para `true` para armazenar em JSON, ou `false` para armazenar em XML, e salve o script ao finalizar;
4. Caso esteja na cena errada, abra a cena `Assets/Scenes/MenuJogoCena.unity`;
5. Clique no ícone de *play* para testar o projeto. (Opcionalmente, você pode fazer uma build).

### Controles

| Ação               | Jogador 1          | Jogador 2                    |
|--------------------|--------------------|------------------------------|
| Acelerar           | W                  | Seta para cima               |
| Frear              | S                  | Seta para baixo              |
| Virar              | A ou D             | Seta para esquerda ou direita|

## Em breve

- [ ] Migrar para uma versão segura da Unity
- [ ] Testar no Linux
- [ ] Disponibilizar binários
- [ ] Melhorar forma de alternar entre XML e JSON, sem precisar editar script
