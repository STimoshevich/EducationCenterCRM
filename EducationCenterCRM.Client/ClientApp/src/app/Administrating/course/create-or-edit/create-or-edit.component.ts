import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Course } from 'src/app/Interfaces/courseInterfaces';
import { CourseService } from 'src/app/Services/course.service';
import { TopicService } from 'src/app/Services/topic.service';

@Component({
  selector: 'app-create-or-edit',
  templateUrl: './create-or-edit.component.html',
  styleUrls: ['./create-or-edit.component.css'],
})
export class CourseCreateOrEditComponent implements OnInit {
  public course: Course = {} as Course;
  public topicTitles: string[] = [];
  public courseForm!: FormGroup;
  public displayStatusNames: string[] = [];
  public isCreate: boolean = false;
  public courseLvlNames: string[] = [];
  constructor(
    public courseService: CourseService,
    public topicService: TopicService,
    public route: ActivatedRoute,
    public router: Router
  ) {}

  GetCourseByid(id: number) {
    this.courseService.GetById(id).subscribe(
      (result) => {
        if (result) {
          this.course = result;
          this.FormInitializer();
        }
      },
      (error) => {
        console.error(error);
      }
    );
  }

  Submit() {
    if (this.isCreate) {
      this.courseForm.value.id = 0;
      this.courseService.Create(this.courseForm.value).subscribe(
        (result) => {
          this.ConfirmWindowWithRedirect('/administrating/course');
        },
        (error) => {
          console.error(error);
        }
      );
    } else {
      this.courseService.Update(this.courseForm.value).subscribe(
        (result) => {
          this.ConfirmWindowWithRedirect('/administrating/courses');
        },
        (error) => {
          console.error(error);
        }
      );
    }
  }

  ConfirmWindowWithRedirect(redirectUrl: string) {
    if (confirm('Changes saved \n return to list?')) {
      this.router.navigate([redirectUrl]);
    }
  }

  FormInitializer() {
    this.courseForm = new FormGroup({
      id: new FormControl(this.course.id),
      title: new FormControl(this.course.title),
      description: new FormControl(this.course.description),
      program: new FormControl(this.course.program),
      imageUrl: new FormControl(this.course.imageUrl),
      topicTitle: new FormControl(this.course.topicTitle),
      durationWeeks: new FormControl(this.course.durationWeeks),
      price: new FormControl(this.course.price),
      courseLevel: new FormControl(this.course.courseLevel),
    });
  }

  GetTopicNames() {
    this.topicService.getAllTitles().subscribe(
      (result) => {
        this.topicTitles = result;
      },
      (error) => console.error(error)
    );
  }

  ngOnInit() {
    this.courseService.GetAllCourseLvlNames().subscribe(
      (result) => {
        this.courseLvlNames = result;
      },
      (error) => console.error(error)
    );

    this.route.params.subscribe((param) => {
      if (param.id > 0) {
        this.GetCourseByid(param.id);
      } else {
        this.isCreate = true;
        this.FormInitializer();
      }
    });
  }
}
