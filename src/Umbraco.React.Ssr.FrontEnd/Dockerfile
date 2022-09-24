FROM node:18.7.0-alpine

RUN apk update && apk add python3 make g++

RUN mkdir -p /home/node/express-ssr/node_modules && chown -R node:node /home/node/express-ssr

WORKDIR /home/node/express-ssr

COPY . .

USER root

RUN npm install

USER node

COPY --chown=node:node . .

RUN npm run build:server

EXPOSE 3000

CMD [ "node", "./dist/server.js" ]
