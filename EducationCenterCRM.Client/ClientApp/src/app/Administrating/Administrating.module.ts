import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RequestsComponent } from './requests/requests.component';
import { RouterModule } from '@angular/router';
import { AdministratingGuard } from '../Guards/Administrating.guard';
import { RequestService } from '../Services/request.service';
import { TeachersComponent } from './teacher/teachers/teachers.component';
import { FormsModule } from '@angular/forms';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    RouterModule.forChild([
      {
        path: 'courses',
        loadChildren: () =>
          import('./course/course.module').then((m) => m.CourseModule),
      },
      {
        path: 'groups',
        loadChildren: () =>
          import('./group/group.module').then((m) => m.GroupModule),
      },
      {
        path: 'requests',
        component: RequestsComponent,
      },
      {
        path: 'teachers',
        loadChildren: () =>
          import('./teacher/teacher.module').then((m) => m.TeacherModule),
      },
      {
        path: 'users',
        loadChildren: () =>
          import('./user/user.module').then((m) => m.UserModule),
      },
    ]),
  ],
  providers: [RequestService],
  declarations: [RequestsComponent],
})
export class AdministratingModule {}
