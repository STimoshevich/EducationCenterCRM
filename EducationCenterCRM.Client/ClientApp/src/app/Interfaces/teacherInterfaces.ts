import { Course } from './courseInterfaces';
import { User } from './IdentityInterfaces';

export interface TeacherNameWithId {
  id: number;
  name: string;
}

export interface Teacher {
  id: number;
  fullName: string;
  email: string;
  phone: string;
  birthDate: string;
  bio: string;
  linkToProfile: string;
  courses: Course[];
}

export interface TeacherList {
  teachers: Teacher[];
  teachersAmount: number;
}

export interface TeacherFilter {
  courseId: number;
}
