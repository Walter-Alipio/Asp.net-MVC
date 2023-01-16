# E-Commerce com MVC e EF

Single page application(SPA) de um e-commerce de livros, Casa do Código .

| :placard: Vitrine.Dev |                                                               |
| --------------------- | ------------------------------------------------------------- |
| :sparkles: Nome       | **E-Commerce com MVC e EF**                                   |
| :label: Tecnologias   | c#, sqlserver, ef, jquery, bootstrap (tecnologias utilizadas) |

<!-- Inserir imagem com a #vitrinedev ao final do link -->

![Tela inicial com carrosel de livros](https://i.imgur.com/Q3IFwcK.png#vitrinedev)

## Detalhes do projeto

### Home

<p p align="center" width="100%">
  <img src="https://i.imgur.com/Q3IFwcK.png" alt="Página de sorteio" width="30%">
</p>

### Carrinho

<p p align="center" width="100%">
  <img src="https://i.imgur.com/bvbDvdV.png" alt="Página de sorteio" width="30%">
</p>

### Cadastro

<p p align="center" width="100%">
  <img src="https://i.imgur.com/G0tDVCa.png" alt="Página de sorteio" width="30%">
</p>

### Resumo do pedido

<p p align="center" width="100%">
  <img src="https://i.imgur.com/s5vbi3D.png" alt="Página de sorteio" width="30%">
</p>

O projeto foi criado ao longo do curso Asp.Net Core: Um e-commerce com MVC e EF Core parte 1 e 2 que juntos somam 18 horas de conteúdo.<br>
Optei por utilizar uma versão mais atualizada do framework para estar mais próximo da realidade do mercado. Isso ocasionou alguns desafios com relação a configurações do projeto, a começar pelo arquivo de configuração. Até a versão 5 do .Net Core, usava-se um arquivo Startup para configurações e nas versões mais recentes, 6 e 7, essas configurações passaram a ser feitas na classe Program. Com isso, algumas sintaxes de métodos também mudaram, como a usada para atualização automática do banco de dados ao iniciar a aplicação. Outra mudança foi acrescentar o newtonsoft json para desserializar o conteúdo recebido via requisição POST, usado para atualizar a quantidade de itens no carrinho e também o banco de dados.<br>
Também foram necessárias algumas alterações no bootstrap, para organizar o layout das páginas utilizei a classe “card”, que deixou a visualização bem semelhante ao apresentado durante as aulas.<br>
Fiz um pequeno tutorial citando os problemas relacionados a mudança de versões e sua resolução: [Post do tutorial no fórum da Alura](https://cursos.alura.com.br/forum/topico-projeto-dicas-para-seguir-o-curso-usando-net-6-262454)
