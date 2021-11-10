import {
  Component,
  OnChanges,
  OnInit,
  SimpleChanges,
  ViewChild,
} from '@angular/core';
import { Course, CourseList } from 'src/app/Interfaces/courseInterfaces';
import { PageItesPerPage as PageItemsPerPage } from 'src/app/Pagination/Pagination.component';
import { CommonService } from 'src/app/Services/common.service';
import { CourseService } from 'src/app/Services/course.service';

@Component({
  selector: 'app-courses',
  templateUrl: './courses.component.html',
  styleUrls: ['./courses.component.css'],
})
export class CoursesComponent implements OnInit {
  public courses: Course[] = [];
  public pageAmount: number = 1;
  public courseFilters: string[] = [];
  public itemsPerPage: number = 100;

  constructor(
    public service: CourseService,
    public commonService: CommonService
  ) {
    this.GetAll(1);
  }

  GetAll(pageN: number) {
    this.service.GetAll(pageN, this.itemsPerPage).subscribe(
      (result) => {
        this.courses = result.courses;
        this.pageAmount = this.commonService.PageCountCalculator(
          result.coursesAmount,
          this.itemsPerPage
        );
      },
      (error) => console.error(error)
    );
  }

  changebyfilter(coursList: CourseList) {
    this.courses = coursList.courses;
    this.pageAmount = this.commonService.PageCountCalculator(
      coursList.coursesAmount,
      this.itemsPerPage
    );
  }

  MoveToPage(pageItemsPerPage: PageItemsPerPage) {
    this.itemsPerPage = pageItemsPerPage.itemsPerPage;
    this.GetAll(pageItemsPerPage.pageN);
  }

  ngOnInit() {}
}
