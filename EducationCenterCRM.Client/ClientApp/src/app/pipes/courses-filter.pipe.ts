import { Pipe, PipeTransform } from '@angular/core';
import { Course } from '../interfaces/interfaces';

@Pipe({
  name: 'coursefilter',
  pure: false,
})
export class CourseFilterPipe implements PipeTransform {
  transform(courses: Course[], topicsId: number[]): Course[] {
    if (!topicsId || !courses || topicsId.length === 0) {
      return courses;
    }

    const filteredcourses: Course[] = courses.filter((course) => {
      if (topicsId.find((x) => +x == course.topicId)) {
        return true;
      }
      return false;
    });

    return filteredcourses;
  }
}
