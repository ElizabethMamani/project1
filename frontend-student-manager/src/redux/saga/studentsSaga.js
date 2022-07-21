// import { takeEvery, put, call } from "redux-saga/effects";
import { takeEvery, put } from "redux-saga/effects";
import { fetchStudents, addStudents } from "../reducer/students";
import { getStudents } from "../../services/app.service";
import { getAllStudentsAdapter } from "../../adapter";

function* getSt() {
  try {
    // const resolver = yield call(getStudents);
    const resolver = yield getStudents();
    const students = getAllStudentsAdapter(resolver.data);
    yield put(addStudents({ studentsList: students }));
  } catch (e) {
    console.log(e);
  }
}

function* studentsSaga() {
  yield takeEvery(fetchStudents.type, getSt);
}
export default studentsSaga;
