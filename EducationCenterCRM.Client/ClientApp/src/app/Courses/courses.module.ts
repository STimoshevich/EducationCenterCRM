import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { CourseSearchModule } from '../Filters/CourseSearch/CourseSearch.module';
import { PaginationModule } from '../Pagination/Pagination.module';
import { CourseFilterModule } from '../Filters/CourseFilter/CourseFilter.module';
import { CoursesPageComponent } from '../Courses/courses-page/courses-page.component';

@NgModule({
  imports: [
    CommonModule,
    CourseFilterModule,
    CourseSearchModule,
    PaginationModule,
    RouterModule.forChild([
      {
        path: '',
        component: CoursesPageComponent,
        pathMatch: 'full',
      },
    ]),
  ],

  declarations: [CoursesPageComponent],
})
export class CoursesModule {}
