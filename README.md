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
Essa atualização garante uma base tecnológica moderna e sustentável a longo prazo.

### Arquitetura e Organização

Foi implementada arquitetura modular, visando facilitar a manutenção, escalabilidade e reutilização de código.
O código legado apresentava forte acoplamento, responsabilidades múltiplas por classe e uma lógica de difícil compreensão e manutenção.

Durante a refatoração, aplicamos princípios de Programação Orientada a Objetos, SOLID e Código limpo.

Isso resultou em um sistema mais coeso, desacoplado e de fácil evolução.

### Expansão de Funcionalidades

Para suportar a inclusão de novas formas geométricas, foi criada a interface IFormaGeometrica, definindo o contrato comum a ser seguido.
Cada nova forma deve implementar essa interface, garantindo consistência e extensibilidade.

De forma similar, a interface ITradutor define o contrato necessário para adicionar suporte a novos idiomas.
Isso permitiu a inclusão do idioma italiano com facilidade e clareza.

### Geração de Relatórios

A classe `ReportGenerator`, gerar os relatórios combinando a lista de formas geométricas com seus respectivos tradutores, de acordo com o respectivo idioma.
Isso garante que o sistema seja extensível tanto em formas quanto em idiomas.

### Testes Automatizados

Foram implementados testes para validar o comportamento das novas formas geométricas (incluíndo trapézio), 
e a tradução para um novo novo idioma adicionado (italiano).

Esses testes asseguram a confiabilidade da solução e reduzem o risco de regressões futuras.


## Melhorias Futuras

Embora a solução atual atenda plenamente aos requisitos do projeto, é possível melhorar o suporte a múltiplos idiomas no futuro, usando arquivos .resx e IStringLocalizer.

No entanto, optei por manter uma abordagem manual e controlada neste momento, para garantir a entrega no prazo e com qualidade, deixando essas melhorias para versões futuras.
