# 🌤️ Aplicação de Previsão do Tempo

Esta aplicação web exibe a previsão do tempo para os próximos 3 dias de uma cidade escolhida. Utiliza a API da **OpenWeather** e está desenvolvida com **.NET (C#)** no padrão **MVC**, com frontend responsivo em HTML/CSS.

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






