import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserFilterComponent } from './UserFilter.component';
import { FormsModule } from '@angular/forms';

@NgModule({
  imports: [CommonModule, FormsModule],
  declarations: [UserFilterComponent],
  exports: [UserFilterComponent],
})
export class UserFilterModule {}
