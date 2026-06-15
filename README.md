# AppImcMaui

Calculadora de IMC feita com .NET MAUI. Você digita peso e altura, toca em calcular e o app mostra o resultado com a classificação da OMS e uma cor pra cada faixa.

## Pra que serve

O app responde uma pergunta simples: "qual é o meu IMC e o que isso significa?". Não guarda histórico, não pede login e não conecta com nada externo. É uma tela só, direto ao ponto.

## Como funciona

1. O usuário informa o **peso em kg** e a **altura em cm**
2. Ao tocar em **Calcular IMC**, o app converte a altura pra metros (divide por 100)
3. Aplica a fórmula: `IMC = peso / (altura em metros)²`
4. Mostra o valor com duas casas decimais e a categoria correspondente
5. A cor do texto muda conforme a faixa (verde pra normal, vermelho pra extremos, etc.)

### Faixas de classificação

| IMC | Categoria |
|-----|-----------|
| Menor que 18,5 | Abaixo do peso |
| 18,5 a 24,9 | Peso normal |
| 25 a 29,9 | Sobrepeso |
| 30 a 34,9 | Obesidade grau I |
| 35 a 39,9 | Obesidade grau II |
| 40 ou mais | Obesidade grau III |

## Stack

- **.NET MAUI 10** com C# e XAML
- **Arquitetura:** code-behind (sem MVVM, sem camadas extras)
- **Navegação:** Shell com uma rota só (`MainPage`)

## Estrutura do projeto

```
AppImcMaui/
├── AppImcMaui.slnx
└── AppImcMaui/
    ├── MainPage.xaml(.cs)     # Tela principal + toda a lógica
    ├── AppShell.xaml          # Container de navegação
    ├── MauiProgram.cs         # Bootstrap do app
    ├── App.xaml(.cs)          # Janela fixa em 400x600
    ├── Resources/             # Ícones, splash, estilos, fontes
    └── Platforms/             # Android, iOS, Mac Catalyst, Windows
```

A lógica inteira fica em `MainPage.xaml.cs`, no evento do botão. Não tem Models, ViewModels nem Services.

## Plataformas

| SO de build | O que compila |
|-------------|---------------|
| Linux | Android |
| macOS | Android, iOS, Mac Catalyst |
| Windows | Android, iOS, Mac Catalyst, Windows |

Versões mínimas: Android API 21, iOS/Mac 15, Windows 10 17763.

## Dependências

- `Microsoft.Maui.Controls`
- `Microsoft.Extensions.Logging.Debug` (só em modo debug)

## Como rodar

### Pré-requisitos

- .NET 10 SDK
- Workload MAUI: `dotnet workload install maui`
- Pra Android no Linux: Android SDK + emulador ou celular com depuração USB

### Comandos

```bash
cd AppImcMaui
dotnet restore
dotnet build AppImcMaui/AppImcMaui.csproj

# Android (Linux)
dotnet build -t:Run -f net10.0-android AppImcMaui/AppImcMaui.csproj

# Windows
dotnet build -t:Run -f net10.0-windows10.0.19041.0 AppImcMaui/AppImcMaui.csproj
```

Também dá pra abrir o `AppImcMaui.slnx` no Visual Studio e rodar com F5.

## Observações

- Não valida campos vazios: se deixar peso ou altura em branco, o `Convert.ToDouble` vai estourar exceção
- Altura zero causaria divisão por zero
- A janela é fixada em 400x600 no `App.xaml.cs` (mais útil pra simular celular no desktop)
- Tem um `int count = 0` no code-behind que sobrou do template original e não é usado

## Ideias de evolução

MVVM com validação de formulário, histórico de medições salvo localmente, gráfico de evolução do IMC ao longo do tempo.
