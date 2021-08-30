import { Component, Inject, OnInit } from '@angular/core';
import { Course } from '../interfaces/interfaces';
import { CourseService } from '../services/course.service';

@Component({
  selector: 'app-courses-page',
  templateUrl: './courses-page.component.html',
  styleUrls: ['./courses-page.component.css'],
})
export class CoursesPageComponent implements OnInit {
  public courses: Course[] = [];
  public topicsNames: number[] = [];
  public filterList: number[] = [];

  constructor(public service: CourseService) {
    service.getAll('courses').subscribe(
      (result) => {
        this.courses = result;
        this.generateTopicsList();
      },
      (error) => console.error(error)
    );
  }

  generateTopicsList() {
    if (this.courses.length > 0) {
      for (let course of this.courses) {
        if (!this.topicsNames.includes(course.topicId))
          this.topicsNames.push(course.topicId);
      }
    }
  }

  changeFilter(e: any) {
    if (e.target.checked) {
      this.filterList.push(e.target.value);
    } else {
      let i = this.filterList.indexOf(e.target.value);
      if (i > -1) {
        this.filterList.splice(i, 1);
      }
    }
  }

  ngOnInit(): void {}
}
