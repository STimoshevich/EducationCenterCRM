import { Component, OnInit } from '@angular/core';
import { Teacher, TeacherList } from 'src/app/Interfaces/teacherInterfaces';
import { CommonService } from 'src/app/Services/common.service';
import { TeacherService } from 'src/app/Services/teacher.service';
import { PageItesPerPage as PageItemsPerPage } from 'src/app/Pagination/Pagination.component';

@Component({
  selector: 'app-teachers',
  templateUrl: './teachers.component.html',
  styleUrls: ['./teachers.component.css'],
})
export class TeachersComponent implements OnInit {
  public teachers: Teacher[] = [];
  public itemsPerPage: number = 10;
  public pageAmount: number = 1;
  constructor(
    public teacherService: TeacherService,
    public commonService: CommonService
  ) {
    this.GetAll(1);
  }

  GetAll(pageN: number) {
    this.teacherService.GetAll(pageN, this.itemsPerPage).subscribe(
      (result) => {
        console.log(result);
        this.teachers = result.teachers;
        this.pageAmount = this.commonService.PageCountCalculator(
          result.teachersAmount,
          this.itemsPerPage
        );
      },
      (error) => console.error(error)
    );
  }

  changebyfilter(teacherList: TeacherList) {
    console.log(teacherList);
    this.teachers = teacherList.teachers;
    this.pageAmount = this.commonService.PageCountCalculator(
      teacherList.teachersAmount,
      this.itemsPerPage
    );
  }

  MoveToPage(pageItemsPerPage: PageItemsPerPage) {
    this.itemsPerPage = pageItemsPerPage.itemsPerPage;
    this.GetAll(pageItemsPerPage.pageN);
  }

  ngOnInit() {}
}
