import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TeachersComponent } from './teachers/teachers.component';
import { TeacherFilterModule } from 'src/app/Filters/TeacherFilter/TeacherFilter.module';
import { RouterModule } from '@angular/router';
import { PaginationModule } from 'src/app/Pagination/Pagination.module';
import { EditComponent } from './edit/edit.component';

@NgModule({
  imports: [
    CommonModule,
    TeacherFilterModule,
    PaginationModule,
    RouterModule.forChild([
      {
        path: '',
        component: TeachersComponent,
        pathMatch: 'full',
      },
      {
        path: 'edit/:id',
        component: EditComponent,
      },
    ]),
  ],
  declarations: [EditComponent, TeachersComponent],
})
export class TeacherModule {}
