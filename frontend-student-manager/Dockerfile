FROM node:14-alpine AS builder
ENV NODE_ENV production
WORKDIR /app
COPY package.json .
COPY yarn.lock .
RUN yarn install --network-timeout 1000000
ENV REACT_APP_SERVER_API=localhost:8000/api
ENV REACT_APP_SERVER_SCHEME=http://
COPY . .
RUN yarn build

FROM nginx:1.21.0-alpine as production
ENV NODE_ENV production
COPY --from=builder /app/build /usr/share/nginx/html
COPY nginx.conf /etc/nginx/conf.d/default.conf
EXPOSE 80
# Start nginx
CMD ["nginx", "-g", "daemon off;"]