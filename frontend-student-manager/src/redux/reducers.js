import { combineReducers } from "redux";
import reducerStudent from "./reducer/students";
import reducerCourse from "./reducer/course";

const rootReducer = combineReducers({
  student: reducerStudent,
  course: reducerCourse,
});

export default rootReducer;
