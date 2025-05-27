# Desafio Técnico – Refatoração de Código em C#

### Cenário:
Nosso sistema possui um método chamado Print (List<GeometricShape> shapes, int language), localizado na classe GeometricShape.cs.
Ele gera um relatório com base em uma lista de formas geométricas e o idioma fornecido.

### Problema:
Esse código está difícil de manter. É complicado adicionar novas formas ou novos idiomas.
Queremos que ele seja mais flexível para evoluções futuras.

### Objetivo:
Refatore o código para que:
• Novas formas geométricas possam ser adicionadas facilmente;
• Novos idiomas possam ser suportados com mínimo esforço;
• Os testes existentes (NUnit) continuem passando corretamente.

### Regras:
• Você pode alterar tudo (estrutura, métodos, testes);
• O código final deve passar todos os testes;
• Há um TODO no código com requisitos adicionais de negócio e técnicos;
• Se possível, atualize o projeto para Visual Studio 2022, .NET 6+ e use xUnit (isso dará pontos extras).

### Tecnologias:
• Linguagem: C#
• Framework atual: .NET Framework 4.6.2
• IDE: Visual Studio 2019 (atualização para VS2022 é opcional)
• Testes: NUnit (opcional migrar para xUnit)

### Tempo estimado:
Até 2 horas.
Entrega:
• Suba sua solução para um repositório público no GitHub ou GitLab;
• Mantenha o README atualizado, explicando as decisões que você tomou;
• Avise quando concluir.

-------

## SOLUÇÃO PROPOSTA

Foi decidido reestruturar o projeto usando .NET 8, versão com suporte de longo prazo (LTS), melhor desempenho, recursos atualizados e maior segurança.
Foi feita uma migração dos testes para usar o Xunit, que é um frameworks de teste muito utilizado no .NET. isto permite melhor integração com CI/CD, maior legibilidade dos testes, suporte aprimorado a testes assíncronos e uma estrutura mais flexível para organização e execução dos testes.
Essas atualizações garantem escolhas mais sustentáveis a longo prazo.

### Arquitetura e Organização

Foi implementada arquitetura modular, visando facilitar a manutenção, escalabilidade e reutilização de código.
O código legado apresentava forte acoplamento, responsabilidades múltiplas por classe e uma lógica de difícil compreensão e manutenção.

Durante a refatoração, aplicamos princípios de Programação Orientada a Objetos, SOLID e Código limpo.

O uso de tipos `enum` em vez de simples strings traz vantagens, tanto em termos de segurança, quanto de manutenibilidade e clareza de código e padronização.

Isso resultou em um sistema mais coeso, desacoplado e de fácil evolução.

### Expansão de Funcionalidades

Para suportar a inclusão de novas formas geométricas, foi criada a interface `IFormaGeometrica`, definindo o contrato comum a ser seguido.
Cada nova forma deve implementar essa interface, garantindo consistência e extensibilidade.

Os textos dos idiomas foram incluídos em arquivos de recursos .resx, centralizando a responsabilidade da tradução e localização num único lugar, separando da lógica de negócio. Usando resx, permite no Visual Studio 2022 editar os idiomas numa interface de planilha, podendo comparar facilmente um idioma com outro. Isso também permitiu a inclusão do idioma italiano com facilidade e clareza, inclusive nos testes.

### Geração de Relatórios

A classe `ReportGenerator`, gerar os relatórios combinando a lista de formas geométricas de acordo com a cultura (idioma) enviado.
Isso garante que o sistema seja extensível tanto em formas quanto em idiomas.

### Testes Automatizados

Foram implementados testes para validar o comportamento das novas formas geométricas (incluíndo trapézio), 
e a tradução para um novo novo idioma adicionado (italiano).

Os testes foram refatorados para usar `[Theory]` e `[InlineData(idioma, resultadoEsperado)]` para facilitar incluir um idioma novo para ser feito naquele mesmo teste, sem que o teste precise ser modificado, apenas incluindo uma novo InlineData com a string do idioma que se deseja testar.

Esses testes asseguram a confiabilidade da solução e reduzem o risco de regressões futuras.
