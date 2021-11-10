import { Component, Inject, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { CourseFilterComponent } from 'src/app/Filters/CourseFilter/CourseFilter.component';
import { CourseSearchComponent } from 'src/app/Filters/CourseSearch/CourseSearch.component';
import { Course, CourseList } from 'src/app/Interfaces/courseInterfaces';
import { IdentityService } from '../../Services/identity.service';
import { CourseService } from '../../Services/course.service';
import { PageItesPerPage as PageItemsPerPage } from 'src/app/Pagination/Pagination.component';

enum ResultType {
  GetAll,
  Search,
  Filter,
}

@Component({
  selector: 'app-courses-page',
  templateUrl: './courses-page.component.html',
  styleUrls: [],
})
export class CoursesPageComponent implements OnInit {
  public courses: Course[] = [];
  public resultType: ResultType = ResultType.GetAll;
  public pageAmount: number = 0;
  public topicsNames: number[] = [];
  public filterList: number[] = [];
  public pickedCourseId: number = 0;
  public stydingType: string | null = '';
  public itemsPerPage = 4;
  @ViewChild(CourseSearchComponent) searchComponent: CourseSearchComponent =
    {} as CourseSearchComponent;
  @ViewChild(CourseFilterComponent) filterComponent: CourseFilterComponent =
    {} as CourseFilterComponent;

  constructor(
    public service: CourseService,
    public authService: IdentityService,
    public router: Router
  ) {
    this.GetAll(1, this.itemsPerPage);
  }

  GetAll(pageN: number, itemsPerPage: number) {
    this.service.GetAll(pageN, itemsPerPage).subscribe(
      (result) => {
        this.courses = result.courses;
        this.pageAmount = this.PageAmountCalculator(
          result.coursesAmount,
          this.itemsPerPage
        );
        this.resultType = ResultType.GetAll;
      },
      (error) => console.error(error)
    );
  }

  ChangeByFilter(courseList: CourseList) {
    this.courses = courseList.courses;
    this.pageAmount = this.PageAmountCalculator(
      courseList.coursesAmount,
      this.itemsPerPage
    );
    this.resultType = ResultType.Filter;
  }
  ChangeBySearch(courseList: CourseList) {
    this.courses = courseList.courses;
    this.pageAmount = this.PageAmountCalculator(
      courseList.coursesAmount,
      this.itemsPerPage
    );
    this.resultType = ResultType.Search;
  }

  ChangeFilter(e: any) {
    if (e.target.checked) {
      this.filterList.push(e.target.value);
    } else {
      let i = this.filterList.indexOf(e.target.value);
      if (i > -1) {
        this.filterList.splice(i, 1);
      }
    }
  }

  MoveToPage(pageItemsPerPage: PageItemsPerPage) {
    this.itemsPerPage = pageItemsPerPage.itemsPerPage;
    if (this.resultType === ResultType.GetAll) {
      this.GetAll(pageItemsPerPage.pageN, this.itemsPerPage);
    }

    if (this.resultType === ResultType.Filter) {
      this.searchComponent.Search(pageItemsPerPage.pageN, this.itemsPerPage);
    }

    if (this.resultType === ResultType.Search) {
      this.filterComponent.FieldChanged(
        pageItemsPerPage.pageN,
        this.itemsPerPage
      );
    }
  }

  SignUp(courseId: number) {
    if (!this.authService.isAuthorized()) {
      this.authService.logout();
      this.router.navigate(['/indentity/registration'], {
        queryParams: { returnUrl: 'allcourses' },
      });
    } else {
      this.service.SignUp(courseId).subscribe(
        (result) => {},
        (error) => console.error(error)
      );
    }
  }

  PageAmountCalculator(itemsAmount: number, itemsPerPage: number): number {
    return Math.round(itemsAmount / itemsPerPage);
  }

  ngOnInit(): void {}
}
