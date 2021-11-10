import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CourseTitleWithId } from 'src/app/Interfaces/courseInterfaces';
import { Teacher } from 'src/app/Interfaces/teacherInterfaces';
import { CourseService } from 'src/app/Services/course.service';
import { TeacherService } from 'src/app/Services/teacher.service';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css'],
})
export class EditComponent implements OnInit {
  constructor(
    public teacherService: TeacherService,
    public courseService: CourseService,
    public route: ActivatedRoute,
    public router: Router
  ) {}

  public teacher: Teacher = {} as Teacher;
  public courseTitlesWithId: CourseTitleWithId[] = [];
  public courses: CourseTitleWithId[] = [];
  @ViewChild('selected') selected: ElementRef = {} as ElementRef;

  GetTeacherByid(id: number) {
    this.teacherService.GetById(id).subscribe(
      (result) => {
        if (result) {
          this.teacher = result;
          if (result.courses) {
            for (let course of result.courses) {
              let courseTitleWithId = {} as CourseTitleWithId;
              courseTitleWithId.id = course.id;
              courseTitleWithId.title = course.title;
              this.courses.push(courseTitleWithId);
            }
          }
        }
      },
      (error) => {
        console.error(error);
      }
    );
  }

  GetAllCoursesTitlesWithId() {
    if (this.courseTitlesWithId.length === 0) {
      this.courseService.GetAllTitlesWithId().subscribe(
        (result) => {
          this.courseTitlesWithId = result;
        },
        (error) => console.error(error)
      );
    }
  }

  DeleteCourse(id: number) {
    let index = this.courses.findIndex((x) => x.id === id);
    console.log(index);
    if (index != -1) {
      this.courses.splice(index, 1);
    }
  }

  AddCourse() {
    let selectedId = this.selected.nativeElement.value;
    if (this.courseTitlesWithId) {
      let index = this.courseTitlesWithId.findIndex((x) => x.id == selectedId);
      if (index != -1) {
        this.courses.push(this.courseTitlesWithId[index]);
      }
      console.log(this.courses);
    }
  }

  Save() {
    if (this.courses) {
      let res = this.courses.map((x) => x.id);
      this.teacherService.updateCourses(this.teacher.id, res).subscribe(
        (result) => {
          this.confirmWindowWithRedirect('/administrating/teachers');
        },
        (error) => console.error(error)
      );
    }
  }

  confirmWindowWithRedirect(redirectUrl: string) {
    if (confirm('Changes saved \n return to list?')) {
      this.router.navigate([redirectUrl]);
    }
  }

  ngOnInit() {
    this.route.params.subscribe((param) => {
      this.GetTeacherByid(param.id);
    });
  }
}
