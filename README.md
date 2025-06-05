# 🌤️ Aplicação de Previsão do Tempo

Esta aplicação web exibe a previsão do tempo atual de uma cidade escolhida. Utiliza a API da **OpenWeather** e está desenvolvida com **.NET (C#)** no padrão **MVC**, com frontend em HTML/CSS. Ela está programada para enviar requisições a cada 15 minutos e persistir em banco de memoria.

---

## 🧩 Funcionalidades

- Consulta do clima atual.
- Visualização de temperaturas mínimas, máximas e condição climática.
- Gráficos de barra verticais representando as temperaturas.
- Containerizada com **Docker**.

---

## ⚙️ Tecnologias Utilizadas

- .NET (C#) com ASP.NET MVC
- HTML5 + CSS3
- API OpenWeather
- Docker + Docker Compose

---

## 📦 Estrutura da Aplicação

- `/Controllers/WeatherController.cs` – lógica de requisição da API.
- `/Views/Home/Index.cshtml` – exibição dos dados no frontend.
- `/wwwroot/css/style.css` – estilos da interface.
- `docker-compose.yml` – orquestração dos containers.

---
## ⚙️ Arquitetura Lógica


                 +----------------+
                 |     Usuário    |
                 +----------------+
                          |
                          v
               +---------------------+
               |     Controlador     | <------+
               +---------------------+        |
                          |                  (Requisição GET)
                          v                   |
               +---------------------+        |
               |       Modelo        |        |
               +---------------------+        |
                          |                   |
                          v                   |
               +---------------------+        |
               | API de Previsão do  |        |
               |      Tempo (        | <------+
               |  OpenWeatherMap API)|
               +---------------------+
                          |
                          v
               +---------------------+
               |      Modelo         | (Mapeia dados recebidos)
               +---------------------+
                          |
                          v
               +---------------------+
               |     Visão (View)    | --> HTML/CSS Responsivo
               +---------------------+
                          |
                          v
                 +----------------+
                 |     Usuário    |
                 +----------------+

---
## ⚙️ Arquitetura Física

+------------------------+           +-------------------------+
|   Navegador Web        |           | Servidor .NET MVC       |
| (Usuário final)        |           | (Docker container)       |
|                        | <-------> |                         |
| - Requisições HTTP     |           | - Controller             |
| - Interface HTML/CSS   |           | - View (HTML)      |
+------------------------+           | - Model (C# classes)     |
                                     |                         |
                                     | - Serviço HTTP Client    |
                                     |   que consome a API      |
                                     +-------------+-----------+
                                                   |
                                                   v
                                     +---------------------------+
                                     | API de Clima Externa      |
                                     | (OpenWeather)    |
                                     |                           |
                                     +---------------------------+


## 🚀 Como Executar com Docker Compose

### Pré-requisitos:

- [Docker](https://www.docker.com/)
- [Docker Compose](https://docs.docker.com/compose/)

### Passo a passo:

1. **Clone o repositório:**

```bash
git clone https://github.com/Dougl4sSales/WeatherAPP.git
cd WEATHERAPP
```

2. **Com o docker e docker-compose já instalados :**
```bash
docker-compose up
```
3. **Entre no navegador e digite: :**
```bash
http://localhost:5000/
```






