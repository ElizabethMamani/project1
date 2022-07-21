import React from "react";
import { Route, Routes } from "react-router-dom";
import "./App.css";
import Header from "./components/Header";
import CoursePage from "./pages/Courses";
import HomePage from "./pages/Home";
import StudentsPage from "./pages/Students";
import StudentPage from "./pages/Student";

function App() {
  return (
    <div>
      <Header />
      <Routes>
        <Route path="/" element={<HomePage />} />
        <Route path="/students" element={<StudentsPage />} />
        <Route path="/courses/:courseId" element={<CoursePage />} />
        <Route path="/students/:studentId" element={<StudentPage />} />
      </Routes>
    </div>
  );
}

export default App;
