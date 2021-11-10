import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { CourseTitleWithId } from 'src/app/Interfaces/courseInterfaces';
import { GroupFilter, GroupList } from 'src/app/Interfaces/groupInterfaces';
import { CourseService } from 'src/app/Services/course.service';
import { GroupService } from 'src/app/Services/group.service';

@Component({
  selector: 'app-group-filter',
  templateUrl: './filter.component.html',
  styleUrls: ['./filter.component.css'],
})
export class GroupFilterComponent implements OnInit {
  public groupFilter: GroupFilter = {} as GroupFilter;
  public allStatuses: string[] = [];
  public courseTitlesWithId: CourseTitleWithId[] = [];
  @Output() FilteredResultEvent = new EventEmitter<GroupList>();
  constructor(
    public groupService: GroupService,
    public courseService: CourseService
  ) {}

  FieldChanged(page: number = 1, itemsPerPage: number = 4) {
    this.groupService
      .GetAllByFilters(this.groupFilter, page, itemsPerPage)
      .subscribe(
        (result) => {
          this.FilteredResultEvent.emit(result);
        },
        (error) => console.error(error)
      );
  }

  GetAllGroupsStatuses() {
    if (this.allStatuses?.length === 0) {
      this.groupService.GetAllStatusNames().subscribe(
        (result) => {
          if (result) this.allStatuses = result;
        },
        (error) => console.error(error)
      );
    }
  }

  GetAllCourseTitles() {
    if (this.courseTitlesWithId?.length === 0) {
      console.log('tesetse');
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
