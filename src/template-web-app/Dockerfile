# Etapa 1: Build da aplicação Angular
FROM node:latest as build

# Diretório de trabalho dentro do contêiner
WORKDIR /app

# Copia os arquivos package.json e package-lock.json
COPY package*.json ./

# Instala as dependências do projeto
RUN npm install

# Copia o restante dos arquivos da aplicação para o contêiner
COPY . .

# Build da aplicação Angular
RUN npm run build --prod

# Etapa 2: Servir a aplicação com Nginx
FROM nginx:alpine

# Remove a configuração padrão do Nginx
RUN rm -rf /usr/share/nginx/html/*

# Copia os arquivos da build Angular para o diretório do Nginx
COPY --from=build /app/dist/template-web-app/browser /usr/share/nginx/html

# Copia o arquivo de configuração do Nginx
COPY nginx.conf /etc/nginx/conf.d/default.conf

# Expondo a porta 80 para acessar a aplicação
EXPOSE 81

# Comando para iniciar o Nginx
CMD ["nginx", "-g", "daemon off;"]
