import axios from "axios";
import client from "./client.configuration.service";
import loadAbortAxios from "../helper/loadAbortAxios";
import options from "../constants/service.constants";

const getStudents = () => {
  return client.request(options.GET_ALL_STUDENTS);
};

const getStudent = () => {
  options.GET_STUDENT.data = { id: 3 };
  return client.request(options.GET_STUDENT);
};
const getStudentById = (id) => {
  const controller = loadAbortAxios();
  options.GET_COURSE_BY_ID.url = `${options.GET_COURSE_BY_ID.url}/${id}`;
  return axios.request(options.GET_COURSE_BY_ID, { signal: controller.signal });
};
const postStudent = ({ student }) => {
  // const controller = loadAbortAxios();
  options.POST_STUDENT.data = student; // para enviar datos, id,objeto --- params es para parametros
  return client.request(options.POST_STUDENT);
  // return axios.request(options.GET_ALL_STUDENTS, { signal: controller.signal });
};

const getCourses = () => {
  const controller = loadAbortAxios();
  return axios.request(options.GET_ALL_COURSES, { signal: controller.signal });
};

const getCourseById = (id) => {
  const controller = loadAbortAxios();
  options.GET_COURSE_BY_ID.url = `${options.GET_COURSE_BY_ID.url}/${id}`;
  return axios.request(options.GET_COURSE_BY_ID, { signal: controller.signal });
};

const getSubjectsById = (id) => {
  const controller = loadAbortAxios();
  options.GET_SUBJECTS_BY_ID = `${options.GET_SUBJECTS_BY_ID.url}/${id}`;
  return axios.request(options.GET_SUBJECTS_BY_ID, {
    signal: controller.signal,
  });
};

export {
  getStudents,
  getCourses,
  getCourseById,
  getStudentById,
  getSubjectsById,
  postStudent,
  getStudent,
};
