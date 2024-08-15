# AppTransacaoFinanceira

### Refatorei o código em pastas para separar as responsabilidades, abstrair e criei interface para facilitar os testes unitários.

### Modifiquei de int para long pela característica do campo para não ter possibilidade de novos erros.

### Modifiquei o retorno do CW para não ter mais os erros.

### Retirei o paralelismo para não processar transações da mesma conta ao mesmo tempo, podendo causar erros.

### Criei testes unitários para os services.

### Estrutura de Pastas

### AppTransacaoFinanceira/
### ├── Models/
### │ ├── ContaSaldo.cs
### │ ├── Transação.cs

### ├── Services/
### │ ├── TransacaoService.cs

### ├── Data/
### │ ├── AcessoDados.cs

### ├── Program.cs
