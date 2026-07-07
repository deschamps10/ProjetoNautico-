# Sistema de Controlo da Estação Nautilus-Console

Trabalho prático da disciplina de Lógica de Programação com C#.

## Eduardo Deschamps e Gabriel de Souza

| Integrante | Módulo desenvolvido |
|---|---|
| [Eduardo Deschamps] | Módulo de Controlo de Equipamento e Inventário Marinho |
| [Gabriel de Souza] | Módulo de Requisições para Expedição e Módulo de Custos Atmosféricos e Relatórios Operacionais |

## Sobre o projeto

Nas profundezas do Oceano Atlântico, a estação de pesquisa Nautilus precisa gerir o inventário dos equipamentos de mergulho, controlar os pedidos de material feitos pelos biólogos antes de cada expedição e calcular o custo de oxigénio gasto em cada missão.

O nosso programa simula esse controlo através de um terminal com menu principal, seguindo as regras da disciplina:

- Não usamos classes próprias, structs ou objetos — só programação estrutural.
- Os dados do inventário ficam guardados em **listas paralelas** (`codigos`, `nomes`, `custos`, `quantidades`), onde o mesmo índice representa sempre o mesmo equipamento.
- Toda a lógica está dividida em métodos `static`, com passagem de parâmetros e retornos.
- Todas as entradas do utilizador são validadas com `int.TryParse` e `double.TryParse`, para o programa nunca fechar sozinho por erro de digitação.

## Menu principal

```
1. Novo Equipamento (Reabastecimento)
2. Listar Equipamentos em Estoque
3. Consultar Item por Código
4. Iniciar Nova Expedição
5. Relatório de Eficiência da Estação
0. Sair
```

## Funcionalidades

**Inventário**
- Cadastro de novos equipamentos/consumíveis (código, nome, custo em litros de O2 e quantidade).
- Listagem de todo o estoque em formato de tabela, destacando em vermelho os itens com quantidade zerada.
- Consulta de um item pelo código, com aviso caso esteja indisponível.

**Expedição**
- Registo do cientista responsável pela missão.
- Pedido de itens um a um (código + quantidade), com verificação de estoque disponível antes de aceitar cada item.
- Caso não haja quantidade suficiente, o sistema emite um alerta de risco à missão e não adiciona o item.
- A lista de pedidos é fechada quando o utilizador digita `0`.

**Custos e relatórios**
- Cálculo do custo total de oxigénio da expedição, com duas taxas de ambiente possíveis:
  - **Fossa Abissal (Profundidade Extrema):** +25% no consumo.
  - **Recife de Coral (Baixa Profundidade):** -10% de poupança.
- Emissão de um manifesto de saída com o resumo da missão (responsável, ambiente, itens levados e custo final).
- Relatório de eficiência da estação, com o total acumulado de oxigénio gasto e o número de expedições já realizadas.

## Como executar

**Visual Studio**
1. Criar um novo projeto de Console App (.NET).
2. Substituir o conteúdo do `Program.cs` gerado pelo deste repositório.
3. Executar com `F5` ou `Ctrl+F5`.

**Linha de comando**
```
dotnet new console -o ProjetoNautico
# copiar o Program.cs para dentro da pasta ProjetoNautico
cd ProjetoNautico
dotnet run
```

## Observações finais

- Os totais do relatório de eficiência (oxigénio gasto e número de expedições) existem apenas durante a execução do programa; eles não são salvos em ficheiro.
- Optamos por manter a interface do terminal simples, usando apenas cores do console e separadores de texto, sem depender de bibliotecas externas.
