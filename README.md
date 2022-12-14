# tryiiter
A Trybe decidiu desenvolver sua própria rede social, totalmente baseada em texto. O objetivo é proporcionar um ambiente em que as pessoas estudantes poderão, por meio de textos e imagens, compartilhar suas experiências e também acessar posts que possam contribuir para seu aprendizado.

# Arquitetura do Projeto
<details>

![topologia-da-aplicacao](https://github.com:Fernando-Olmedo/tryiiter/blob/Rota-de-login/Utils/Arquitetura%20do%20Tema%201.jpegraw=true)

</details>


# Premissas do projeto
- Utilizar C#, SQL Server e Azure;
- Ter rotas autenticadas e rotas anônimas;
- Utilizar os frameworks xUnit e FluentAssertions para criar testes.
- Esse serviço recebe muitas requisições, então cuidado para não travar o servidor e deixar outras requisições esperando;
- Algumas rotas devem ser autenticadas por motivos de segurança;
- As principais funcionalidades do Back-End devem ter testes para garantir que sejam de boa manutenção.


# Requisitos do Projeto

Nessa rede social, as pessoas estudantes devem conseguir se cadastrar com nome, e-mail, módulo atual que estão estudando na Trybe, status personalizado e senha para se autenticar. Deve ser possível também alterar essa conta a qualquer momento, desde que a pessoa usuária esteja autenticada.

Uma pessoa estudante deve poder também publicar posts em seu perfil, que poderão conter texto com até 300 caracteres e arquivos de imagem, além de conseguir pesquisar outras contas por nome e optar por listar todos seus posts ou apenas o último.
- Realizar operações de C.R.U.D. para as contas de pessoas estudantes;
- Realizar operações de C.R.U.D. para um post de uma pessoa estudante;
- 30%, no mínimo, de cobertura de testes;