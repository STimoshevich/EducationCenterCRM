import { analyzeAndValidateNgModules } from '@angular/compiler';
import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { CourseTitleWithId } from 'src/app/Interfaces/courseInterfaces';
import { Group } from 'src/app/Interfaces/groupInterfaces';
import { Student } from 'src/app/Interfaces/studentInterfaces';
import { TeacherNameWithId } from 'src/app/Interfaces/teacherInterfaces';
import { CourseService } from 'src/app/Services/course.service';
import { GroupService } from 'src/app/Services/group.service';
import { RequestService } from 'src/app/Services/request.service';
import { TeacherService } from 'src/app/Services/teacher.service';

@Component({
  selector: 'app-create-or-edit',
  templateUrl: './create-or-edit.component.html',
  styleUrls: ['./create-or-edit.component.css'],
})
export class GroupCreateOrEditComponent implements OnInit {
  public group: Group = {} as Group;
  public groupForm!: FormGroup;
  public isCreate: boolean = false;
  public allStatuses: string[] = [];
  public courseTitlesWithId: CourseTitleWithId[] = [];
  public teachersNamesWithId: TeacherNameWithId[] = [];
  public students: Student[] = [];
  public selectedCourseId: number = 0;
  public studingTypes: string[] = [];
  @ViewChild('selected') selected: ElementRef = {} as ElementRef;

  constructor(
    public groupService: GroupService,
    public courseService: CourseService,
    public teacherService: TeacherService,
    public requestService: RequestService,
    public route: ActivatedRoute,
    public router: Router
  ) {}

  GetCourseByid(id: number) {
    this.groupService.GetById(id).subscribe(
      (result) => {
        if (result) {
          console.log(result);
          this.group = result;
          this.formInitializer();
        }
      },
      (error) => {
        console.error(error);
      }
    );
  }

  Submit() {
    if (this.isCreate) {
      this.groupForm.value.id = 0;
      this.groupService.Create(this.groupForm.value).subscribe(
        (result) => {
          this.confirmWindowWithRedirect('/administrating/groups');
        },
        (error) => {
          console.error(error);
        }
      );
    } else {
      this.groupService.Update(this.groupForm.value).subscribe(
        (result) => {
          this.confirmWindowWithRedirect('/administrating/groups');
        },
        (error) => {
          console.error(error);
        }
      );
    }
  }

  confirmWindowWithRedirect(redirectUrl: string) {
    if (confirm('Changes saved \n return to list?')) {
      this.router.navigate([redirectUrl]);
    }
  }

  formInitializer() {
    this.groupForm = new FormGroup({
      id: new FormControl(this.group.id),
      title: new FormControl(this.group.title),
      startDate: new FormControl(this.group.startDate),
      status: new FormControl(this.group.status),
      studentCapacity: new FormControl(this.group.studentCapacity),
      courseId: new FormControl(this.group.courseId),
      teacherId: new FormControl(this.group.teacherId),
      studingType: new FormControl(this.group.studingType),
    });
  }

  GetAllTeachersNamesByCourseId() {
    if (
      this.teachersNamesWithId?.length === 0 ||
      this.group.courseId != this.groupForm.value.courseId
    ) {
      this.courseService
        .GetAllTeachersNamesAndIdByCourse(this.groupForm.value.courseId)
        .subscribe(
          (result) => {
            if (result) this.teachersNamesWithId = result;
          },
          (error) => console.error(error)
        );
    }
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

  GetStydingTypes() {
    if (this.studingTypes.length === 0) {
      this.requestService.GetAllStudingTypes().subscribe(
        (result) => {
          this.studingTypes = result;
        },
        (error) => console.error(error)
      );
    }
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

  GetAllStudents(groupId: number) {
    this.groupService.GetAllStudentsByCourseid(groupId).subscribe(
      (result) => {
        this.students = result;
      },
      (error) => console.error(error)
    );
  }

  ngOnInit() {
    this.route.params.subscribe((param) => {
      if (param.id > 0) {
        this.GetCourseByid(param.id);
        this.GetAllStudents(param.id);
      } else {
        this.isCreate = true;
        this.formInitializer();
      }
    });
  }
}
