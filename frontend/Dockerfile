FROM node:alpine
WORKDIR /usr/src/app
COPY . /usr/src/app/

RUN set -ex; \
  yarn install;\
  yarn run build;

FROM nginx:alpine
WORKDIR /usr/share/nginx/html
COPY --from=0 /usr/src/app/build/ /usr/share/nginx/html