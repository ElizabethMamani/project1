import { takeEvery, put, call } from "redux-saga/effects";
import { fetchCourses, addCourses } from "../reducer/course";
import { getCourses } from "../../services/app.service";
import { getAllCoursesAdapter } from "../../adapter";

function* getCr() {
  try {
    const resolver = yield call(getCourses);
    const courses = getAllCoursesAdapter(resolver.data);
    yield put(addCourses({ coursesList: courses }));
  } catch (e) {
    console.log(e);
  }
}

// function* getCrById(action) {
//   try {
//     console.log("llego hasta aqui");
//     console.log(action.payload);
//     // const resolver = yield call(getCourseById);

//     yield put(updateCourses({ coursesList: courses }));
//   } catch (e) {
//     console.log(e);
//   }
// }

function* CoursesSaga() {
  yield takeEvery(fetchCourses.type, getCr);
  //   yield takeEvery(updateCourses.type, getCrById(updateCourses.payload));
}
export default CoursesSaga;
