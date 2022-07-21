/* eslint-disable no-param-reassign */
import { createSlice } from "@reduxjs/toolkit";

const coursesSlice = createSlice({
  name: "courses",

  initialState: {
    isLoading: false,

    course: {},

    coursesList: [],
  },

  reducers: {
    fetchCourses: (state) => {
      state.isLoading = true;
    },
    addCourses: (state, action) => {
      state.isLoading = false;
      state.coursesList = action.payload.coursesList;
    },
  },
});
export const { fetchCourses, addCourses } = coursesSlice.actions;

export default coursesSlice.reducer;
