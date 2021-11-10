import { RecursiveTemplateAstVisitor } from '@angular/compiler';
import {
  Component,
  EventEmitter,
  OnChanges,
  OnInit,
  Output,
  SimpleChanges,
} from '@angular/core';
import { CourseFilter, CourseList } from 'src/app/Interfaces/courseInterfaces';
import { CourseService } from 'src/app/Services/course.service';
import { TopicService } from 'src/app/Services/topic.service';

@Component({
  selector: 'app-courses-filter',
  templateUrl: './CourseFilter.component.html',
  styleUrls: ['./CourseFilter.component.css'],
})
export class CourseFilterComponent implements OnInit {
  public courseFilter: CourseFilter = {} as CourseFilter;
  public courseLvlNames: string[] = [];
  public topictitles: string[] = [];
  @Output() FilteredResultEvent = new EventEmitter<CourseList>();
  constructor(
    public courseService: CourseService,
    public topicService: TopicService
  ) {}

  AddTopicToFilter(topicName: string) {
    if (topicName) {
      if (!this.courseFilter.topicNames) {
        this.courseFilter.topicNames = [];
      }
      let indexOfTopicName = this.courseFilter.topicNames.indexOf(topicName);
      if (indexOfTopicName === -1) {
        this.courseFilter.topicNames.push(topicName);
      } else {
        this.courseFilter.topicNames.splice(indexOfTopicName, 1);
        if (this.courseFilter.topicNames.length == 0) {
          this.courseFilter.topicNames = null;
        }
      }
    }
    this.FieldChanged();
  }

  FieldChanged(page: number = 1, itemsPerPage: number = 4) {
    this.courseService
      .GetAllByFilters(this.courseFilter, page, itemsPerPage)
      .subscribe(
        (result) => {
          this.FilteredResultEvent.emit(result);
        },
        (error) => console.error(error)
      );
  }

  ngOnInit(): void {
    this.topicService.getAllTitles().subscribe(
      (result) => {
        if (result) {
          this.topictitles = result;
        }
      },
      (error) => console.error(error)
    );

    this.courseService.GetAllCourseLvlNames().subscribe(
      (result) => {
        if (result) {
          this.courseLvlNames = result;
        }
      },
      (error) => {
        console.error(error);
      }
    );
  }
}
