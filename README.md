# Criando um APP simples de cadastro de séries em .NET

## Sobre o projeto

- Criando uma aplicação para cadastro de uma série a partir do console.
- A aplicação permite criar, listar, atualizar e deletar. Aplicação CRUD
- Foi usada classe abstrata e interface para treinar e dividido por camada.

## Alterações

- No lugar de lançar um erro quando a opção de entrado estivesse fora do itens especificados, foi lançado apenas um aviso e código não existente voltando para o loop inicial.
- Adicionado condição para exibir apenas as séries não excluidas.
- Foi criado mais um atributo chamado de Rating, o qual é a avaliação do usuário sobre a série.
- Criado um novo método para listar em ordem crescente de rating. 
- Novo método de entrada de série e de seleção de série pelo Id, chamado EntradaSerie() e SelecionaIdSerie(), que facilita a legibilidade dos outros métodos de inserção e atualização.

## Exemplo Resultado Final

