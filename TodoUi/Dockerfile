# Use an official Node.js runtime as a parent image
FROM node:20-alpine
WORKDIR /app
COPY package*.json ./
RUN npm install
COPY . .
RUN npm run build --prod
EXPOSE 4200
CMD ["npm", "start", "--", "--host", "0.0.0.0"]
