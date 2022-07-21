/* eslint-disable no-param-reassign */
import { createSlice } from "@reduxjs/toolkit";

const studentsSlice = createSlice({
  name: "students",

  initialState: {
    isLoading: false,

    student: {},

    studentsList: [],
  },

  reducers: {
    fetchStudents: (state) => {
      state.isLoading = true;
    },
    addStudents: (state, action) => {
      state.isLoading = false;
      state.studentsList = action.payload.studentsList;
    },
    updateStudents: (state, action) => {
      state.isLoading = false;
      state.studentsList = [
        ...state.studentsList,
        ...action.payload.studentsList,
      ];
    },
  },
});

export const { fetchStudents, addStudents } = studentsSlice.actions;

export default studentsSlice.reducer;
