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

Foi decidido criar novos projetos usando .NET 8, já que esta versão tem suporte de longo prazo, maior desempenho e performance, novas funcionalidades e mais segurança.

Foi realizada uma arquitetura mais modular para facilita a manutenção e escalabilidade.

O código anterior tinha forte acoplamento, responsabilidades múltiplas em classes únicas, com uma lógica difícil de manter.
Foi refatorada  utilizando os princípios SOLID e código limpo.

