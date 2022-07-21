const getAllStudentsAdapter = (data) => {
  if (data !== undefined) {
    const listStudents = [];
    for (let i = 0; i <= data.length - 1; i += 1) {
      const { studentName, studentId, courseId, country, email, birthDate } =
        data[i];
      const d = new Date(birthDate);
      const [year, month, day] = [
        d.getFullYear(),
        d.toLocaleString("default", { month: "long" }),
        d.getDate(),
      ];

      const date = `${year},${day} ${month}`;

      listStudents.push({
        name: studentName,
        StudentId: studentId,
        CourseId: courseId,
        Country: country,
        Email: email,
        BirthDate: date,
        Status: courseId !== 0,
      });
    }
    return listStudents;
  }
  return [];
};

export default getAllStudentsAdapter;
