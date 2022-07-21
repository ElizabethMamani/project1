import { configureStore } from "@reduxjs/toolkit";

import createSagaMidleware from "redux-saga";

import studentsSaga from "./saga/studentsSaga";

import CoursesSaga from "./saga/coursesSaga";

import reducers from "./reducers";

const SagaMiddleware = createSagaMidleware();

const store = configureStore({
  reducer: reducers,
  middleware: [SagaMiddleware],
});

SagaMiddleware.run(studentsSaga);
SagaMiddleware.run(CoursesSaga);

export default store;
