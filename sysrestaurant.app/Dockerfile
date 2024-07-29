FROM node:latest
RUN mkdir /app
WORKDIR /app
COPY package*.json .
COPY tsconfig.json .
RUN npm i
COPY src/ ./src
COPY public/ ./public
EXPOSE 3000
CMD ["npm", "start"]