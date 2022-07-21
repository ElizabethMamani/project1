const getAllCoursesAdapter = (data) => {
  if (data !== undefined) {
    const listCourses = [];
    for (let i = 0; i <= data.length - 1; i += 1) {
      const { courseName, description, courseId, startDate, endDate, imageId } =
        data[i];
      const d = new Date(startDate);
      const status = new Date(endDate) < Date.now;

      const [yeard, monthd, dayd] = [
        d.getFullYear(),
        d.toLocaleString("default", { month: "long" }),
        d.getDate(),
      ];

      const date = `${yeard},${dayd} ${monthd}`;
      listCourses.push({
        name: courseName,
        CourseId: courseId,
        StartDate: date,
        Status: status,
        BirthDate: date,
        Description: description,
        ImageId: imageId,
      });
    }
    return listCourses;
  }
  return [];
};

const getCourseAdapter = (data) => {
  let course;
  if (data !== undefined) {
    const startDate = new Date(data.startDate);
    const endDate = new Date(data.endDate);
    const [yeard, monthd, dayd] = [
      startDate.getFullYear(),
      startDate.toLocaleString("default", { month: "long" }),
      startDate.getDate(),
    ];
    const [yeare, monthe, daye] = [
      endDate.getFullYear(),
      endDate.toLocaleString("default", { month: "long" }),
      endDate.getDate(),
    ];

    const showS = `Starts ${monthd} ${dayd},${yeard}`;
    const showE = `Ends ${monthe} ${daye},${yeare}`;
    course = {
      CourseName: data.courseName,
      Description: data.description,
      StartDate: showS,
      EndDate: showE,
      Status: Date.now > startDate && Date.now < endDate,
    };
  }
  return course;
};

const getSubjectAdapter = (data) => {
  const subjects = [];
  if (data !== undefined) {
    const list = [];
    for (let j = 0; j < data.length; j += 1) {
      for (let i = 0; i < data[j].schedules.length - 1; i += 1) {
        if (!list.includes(data[j].schedules[i].day)) {
          list.push(data[j].schedules[i].day);
        }
      }
      const startDate = new Date(data[j].startDate);
      const [yeard, monthd, dayd] = [
        startDate.getFullYear(),
        startDate.toLocaleString("default", { month: "long" }),
        startDate.getDate(),
      ];
      const startTime = new Date(data[0].schedules[0].startTime).getHours();
      const endTime = new Date(data[0].schedules[0].endTime).getHours();
      const showS = `Starts ${monthd} ${dayd},${yeard}`;
      const showDays = list.join(",");
      subjects.push({
        SubjectId: data[j].subjectId,
        name: data[j].subjectName,
        Days: showDays,
        StartDate: showS,
        Instructor: data[j].instructorname,
        Horary: `${startTime} to ${endTime}`,
      });
    }
  }
  console.log(subjects);
  return subjects;
};

export { getAllCoursesAdapter, getCourseAdapter, getSubjectAdapter };
