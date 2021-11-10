export interface Course {
  id: number;
  title: string;
  description: string;
  program: string;
  topicTitle: string;
  imageUrl: string;
  durationWeeks: number;
  price: number;
  courseLevel: string;
}

export interface CourseList {
  courses: Course[];
  coursesAmount: number;
}

export interface CourseFilter {
  priceFrom: number;
  priceTo: number;
  level: string;
  durationWeeksFrom: number;
  durationWeeksTo: number;
  topicNames: string[] | null;
}

export interface CourseTitleWithId {
  id: number;
  title: string;
}
