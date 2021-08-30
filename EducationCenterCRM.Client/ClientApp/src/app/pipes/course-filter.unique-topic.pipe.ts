import { Pipe, PipeTransform } from '@angular/core';
import { Course } from '../interfaces/interfaces';

@Pipe({
  name: 'courseFilterUniqueTopic',
})
export class CourseFilterUniqueTopic implements PipeTransform {
  transform(courses: Course[]): Course[] {
    if (!courses) {
      return courses;
    }

    let uniqueCourses: Course[] = [];
    for (let course of courses) {
      if (!uniqueCourses.find((x) => x.topicId == course.topicId)) {
        uniqueCourses.push(course);
      }
    }

    return uniqueCourses;
  }
}
