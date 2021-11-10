import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TeacherFilterComponent } from './TeacherFilter.component';
import { FormsModule } from '@angular/forms';

@NgModule({
  imports: [CommonModule, FormsModule],
  declarations: [TeacherFilterComponent],
  exports: [TeacherFilterComponent],
})
export class TeacherFilterModule {}
