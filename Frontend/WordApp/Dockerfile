# Aşama 1: Angular Build
FROM node:18 AS builder
WORKDIR /app

COPY package*.json ./
RUN npm install

COPY . .
RUN npx ng build WordApp --configuration production

FROM nginx:alpine
COPY --from=builder /app/dist/word-app/browser /usr/share/nginx/html

EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]
