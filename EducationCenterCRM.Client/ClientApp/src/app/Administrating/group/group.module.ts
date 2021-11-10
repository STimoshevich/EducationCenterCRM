import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { GroupsComponent } from './groups/groups.component';
import { GroupCreateOrEditComponent } from './create-or-edit/create-or-edit.component';
import { PaginationModule } from 'src/app/Pagination/Pagination.module';
import { GroupFilterComponent } from '../../Filters/GroupFilter/filter.component';

@NgModule({
  imports: [
    CommonModule,
    ReactiveFormsModule,
    PaginationModule,
    FormsModule,
    RouterModule.forChild([
      {
        path: '',
        component: GroupsComponent,
        pathMatch: 'full',
      },
      {
        path: 'edit/:id',
        component: GroupCreateOrEditComponent,
      },
    ]),
  ],
  declarations: [
    GroupsComponent,
    GroupCreateOrEditComponent,
    GroupFilterComponent,
  ],
})
export class GroupModule {}
