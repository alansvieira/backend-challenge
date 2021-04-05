# Considerações Iniciais

- O projeto foi desenvolvido em .Net Core 3.1 (https://dotnet.microsoft.com/download/dotnet/3.1);
- Como o exemplo de código dado está em inglês, todo o código, com exceção apenas desse documento, está em **inglês** (incluindo alguns breves comentários);
- A arquitetura utilizada foi inspirada na "Clean Arquiteture"(ish) criada por Robert Martin. Acrescentei o "ish" porque meu foco não foi no desenho da arquitetura do projeto e sim na solução proposta. Porém, achei  importante ter algum ponto de base, sendo que o design da API está sendo levado em conta;
- Também por conta design da api estar sendo considerado, achei interessante ter uma estrutura básica de retorno do objeto que inclui: Dados, Metadados e Tratamento de erros;
- O objetivo de criar uma entidade chamada "Password" foi de evitar a "Primitive Obsession" (https://enterprisecraftsmanship.com/posts/functional-c-primitive-obsession/) e também abrir portas para que essa entidade possa ser composta com outra entidade, por exemplo "Usuario".
- Também acredito que a entidade deve ser retornada já validada e não depender de uma chamada externa para a sua validação. Por isso que o tratamente da entidade é realizado já no momento da construção do objeto.
- No método de validação da PasswordBehavior, escolhi por não retornar uma lista com todos os erros em ordem de priorizar a performance da API. Por isso, faço o método retornar no primeiro erro encontrado e não prosseguir com a validação. A ordem de validação também foi avaliada, ordenei por "custo" de memória/processamento.
- Embora não fora solicitado explicitamente, também adicionei um tratamento de valor máximo da senha por conta que o valor de entrada é uma string (que pode ter até 2,147,483,647 caracteres). Considerando que uma string gigantesca fosse o parametro de uma requisição, eu gastaria apenas tempo tentando calcular o tamanho dela. Mas, uma vez o tamanho sendo identificado como inválido, eu não precisaria percorrer ela para realizar as outras validações(que são mais custosas).



# Como utilizar

Na raiz do projeto, executar os seguintes comandos:

Para build:
```
dotnet build
```

Para executar os testes:
```
dotnet test
```

Para executar api:
```
dotnet run --project .\PasswordChallenge.API
```

<sub><sup> *Uma vez com a api sendo executada, a porta utilizada será a 5001.</sub></sup>

Para realizar uma requisição usando o Powershell:
```
$headers = New-Object "System.Collections.Generic.Dictionary[[String],[String]]"
$headers.Add("Content-Type", "application/json")
$body = "`"AbTp9!fok`""
$response = Invoke-RestMethod 'https://localhost:5001/password' -Method 'POST' -Headers $headers -Body $body
$response | ConvertTo-Json
```

ou cUrl:
```
curl --location --request POST 'https://localhost:5001/password' \
--header 'Content-Type: application/json' \
--data-raw '"AbTp9!foo"'
```

Modelo de resposta:

```
{
    "result": {
        "value": "AbTp9!foo"
    },
    "metadata": {},
    "errorHandling": {
        "isValid": false,
        "validationErrors": [
            "Your password must contain only distinct characters"
        ]
    }
}
```
