import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { CourseFilterComponent } from '../CourseFilter/CourseFilter.component';

@NgModule({
  imports: [FormsModule, CommonModule],
  declarations: [CourseFilterComponent],
  exports: [CourseFilterComponent],
})
export class CourseFilterModule {}
