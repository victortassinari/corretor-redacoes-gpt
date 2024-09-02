# Use uma imagem Node.js 20.11 como base
FROM node:20.11-alpine

# Defina o diretório de trabalho dentro do contêiner
WORKDIR /app

# Copie o package.json e o package-lock.json
COPY package.json ./

RUN rm -rf node_modules package-lock.json

# Instale as dependências com npm e resolva problemas de compatibilidade
RUN npm install

# Copie o restante dos arquivos do projeto
COPY . .

# Exponha a porta onde o app será servido, com um valor padrão caso FRONTEND_PORT não seja definido
ARG FRONTEND_PORT=3000
EXPOSE ${FRONTEND_PORT}

# Comando para rodar o frontend, com uma porta padrão caso não seja definida
CMD npm run dev -- --host 0.0.0.0 --port ${FRONTEND_PORT}