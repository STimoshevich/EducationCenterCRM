import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PaginationComponent } from './Pagination.component';

@NgModule({
  imports: [CommonModule],
  declarations: [PaginationComponent],
  exports: [PaginationComponent],
})
export class PaginationModule {}
