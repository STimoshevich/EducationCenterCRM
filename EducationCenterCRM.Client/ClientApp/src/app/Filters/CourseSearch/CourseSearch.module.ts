import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CourseSearchComponent } from './CourseSearch.component';
import { FormsModule } from '@angular/forms';

@NgModule({
  imports: [CommonModule, FormsModule],
  declarations: [CourseSearchComponent],
  exports: [CourseSearchComponent],
})
export class CourseSearchModule {}
