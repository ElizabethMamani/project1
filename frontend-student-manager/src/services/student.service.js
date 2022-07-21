import axios from "axios";

import loadAbortAxios from "../helper/loadAbortAxios";

import options from "../constants/service.constants";

const getStudents = () => {
  const controller = loadAbortAxios();
  return axios.request(options.GET_ALL_STUDENTS, { signal: controller.signal });
};

export default getStudents;
