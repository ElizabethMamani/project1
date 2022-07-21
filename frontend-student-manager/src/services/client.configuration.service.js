import axios from "axios";
import { BASE_API_URL, HEADERS } from "../constants/client.constants";

const client = axios.create({
  baseURL: `${BASE_API_URL}`,
  headers: HEADERS,
});

client.interceptors.request.use(
  (config) => {
    const cfg = config;
    cfg.headers = { ...cfg.headers, authorization: "token" };
    return cfg;
  },
  (errors) => {
    return errors;
  },
);

client.interceptors.response.use(
  (response) => {
    if (response.status === 401) {
      alert("You are not authorized.");
    }
    return response;
  },
  (error) => {
    if (error.response && error.response.data) {
      return error.response.data;
    }
    return error.message;
  },
);

export default client;
