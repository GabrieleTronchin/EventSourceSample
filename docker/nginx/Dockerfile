FROM docker.io/nginx:latest
COPY ./nginx.conf /etc/nginx/nginx.conf
COPY ./global.pass /etc/keys/global.pass

EXPOSE 80
EXPOSE 443

CMD ["nginx", "-g", "daemon off;"]
