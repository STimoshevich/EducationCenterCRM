import { Course } from './courseInterfaces';

export interface StudingRequest {
  id: number;
  created: Date;
  studentId: string;
  studingType: string;
  studentFullName: string;
  courseId: number;
  courseName: string;
  comments: string;
  email: string;
  course: Course;
}

export interface StudingRequestsList {
  requests: StudingRequest[];
  requestsAmount: number;
}
