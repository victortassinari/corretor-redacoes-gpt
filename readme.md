# Correção de Redações do ENEM

Este projeto é uma aplicação completa para correção automática de redações do ENEM, utilizando o modelo GPT-4 da OpenAI. A aplicação é composta por um backend em .NET 8 que processa as redações e um frontend em Svelte que permite ao usuário submeter suas redações para correção.

---

## Tecnologias Utilizadas

- **Backend**:
  - .NET 8
  - OpenAI SDK
  - ASP.NET Core
- **Frontend**:
  - Svelte
  - Tailwind CSS
  - Vite
- **Infraestrutura**:
  - Docker
  - Docker Compose

  ---

## Como Usar
### Pré-requisitos

- Docker e Docker Compose instalados
- Chave de API da OpenAI (defina no arquivo `.env`)

---

### Configuração

1. **Clone o repositório**:

   ```
   git clone https://github.com/seu-usuario/seu-repositorio.git
   cd correcao-enem
   ```

2. **Configure o arquivo `.env`**:

   Crie um arquivo `.env` na raiz do projeto e configure suas variáveis de ambiente:

   ```
   OPENAI_API_KEY=your_openai_api_key
   FRONTEND_PORT=5173
   BACKEND_PORT=8080
   VITE_API_URL=http://localhost:8080/api
   ```

3. **Inicie os serviços com Docker Compose**:

   ```
   docker-compose up --build
   ```

---

### Acessando a Aplicação

- **Frontend**: Acesse `http://localhost:5173` para utilizar a interface de correção de redações.
- **Backend**: O backend estará disponível em `http://localhost:8080`, servindo a API que processa as redações.

### Estrutura do Projeto

- **backend/**: Contém o código do backend .NET 8.
- **frontend/**: Contém o código do frontend Svelte.

---

### Contribuições

Contribuições são bem-vindas! Sinta-se à vontade para abrir issues ou pull requests.

### Licença

Este projeto está sob a licença MIT. Veja o arquivo LICENSE para mais detalhes.