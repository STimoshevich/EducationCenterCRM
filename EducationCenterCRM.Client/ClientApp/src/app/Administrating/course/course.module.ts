import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { CoursesComponent } from './courses/courses.component';
import { CourseCreateOrEditComponent } from './create-or-edit/create-or-edit.component';
import { ReactiveFormsModule } from '@angular/forms';
import { CourseSearchModule } from 'src/app/Filters/CourseSearch/CourseSearch.module';
import { PaginationModule } from 'src/app/Pagination/Pagination.module';
import { CourseFilterModule } from 'src/app/Filters/CourseFilter/CourseFilter.module';

@NgModule({
  imports: [
    CommonModule,
    CourseSearchModule,
    CourseFilterModule,
    ReactiveFormsModule,
    CourseFilterModule,
    PaginationModule,
    RouterModule.forChild([
      {
        path: '',
        component: CoursesComponent,
        pathMatch: 'full',
      },
      {
        path: 'edit/:id',
        component: CourseCreateOrEditComponent,
      },
    ]),
  ],
  declarations: [CoursesComponent, CourseCreateOrEditComponent],
})
export class CourseModule {}
