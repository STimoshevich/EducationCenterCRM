import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserFilterModule } from 'src/app/Filters/UserFilter/UserFilter.module';
import { RouterModule } from '@angular/router';
import { UsersComponent } from './users/users.component';
import { PaginationModule } from 'src/app/Pagination/Pagination.module';

@NgModule({
  imports: [
    CommonModule,
    UserFilterModule,
    PaginationModule,
    RouterModule.forChild([
      {
        path: '',
        component: UsersComponent,
        pathMatch: 'full',
      },
    ]),
  ],
  declarations: [UsersComponent],
})
export class UserModule {}
