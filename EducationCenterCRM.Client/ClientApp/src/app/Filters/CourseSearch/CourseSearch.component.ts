import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { CourseList } from 'src/app/Interfaces/courseInterfaces';

import { CourseService } from '../../Services/course.service';

@Component({
  selector: 'app-courses-search',
  templateUrl: './CourseSearch.component.html',
  styleUrls: ['./CourseSearch.component.css'],
})
export class CourseSearchComponent implements OnInit {
  public searchInput: string = '';
  @Output() SearchResultEvent = new EventEmitter<CourseList>();
  /**
   *
   */
  constructor(public courseService: CourseService) {}
  Search(page: number = 1, itemsPerPage: number = 4) {
    setTimeout(() => {
      this.courseService.Search(this.searchInput, page, itemsPerPage).subscribe(
        (result) => {
          this.SearchResultEvent.emit(result);
        },
        (error) => console.error(error)
      );
    }, 300);
  }

  ngOnInit(): void {}
}
