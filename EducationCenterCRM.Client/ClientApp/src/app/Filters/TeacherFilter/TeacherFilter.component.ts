import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { CourseTitleWithId } from 'src/app/Interfaces/courseInterfaces';
import {
  TeacherFilter,
  TeacherList,
} from 'src/app/Interfaces/teacherInterfaces';
import { CourseService } from 'src/app/Services/course.service';
import { TeacherService } from 'src/app/Services/teacher.service';

@Component({
  selector: 'app-TeacherFilter',
  templateUrl: './TeacherFilter.component.html',
  styleUrls: ['./TeacherFilter.component.css'],
})
export class TeacherFilterComponent implements OnInit {
  public teacherFilter: TeacherFilter = {} as TeacherFilter;
  public allStatuses: string[] = [];
  public courseTitlesWithId: CourseTitleWithId[] = [];
  @Output() FilteredResultEvent = new EventEmitter<TeacherList>();
  constructor(
    public teacherService: TeacherService,
    public courseService: CourseService
  ) {}

  FieldChanged(page: number = 1, itemsPerPage: number = 4) {
    this.teacherService
      .GetAllByFilters(this.teacherFilter, page, itemsPerPage)
      .subscribe(
        (result) => {
          this.FilteredResultEvent.emit(result);
        },
        (error) => console.error(error)
      );
  }

  GetAllCourseTitles() {
    if (this.courseTitlesWithId?.length === 0) {
      this.courseService.GetAllTitlesWithId().subscribe(
        (result) => {
          if (result) this.courseTitlesWithId = result;
        },
        (error) => console.error(error)
      );
    }
  }

  ngOnInit() {}
}
