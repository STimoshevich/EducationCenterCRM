import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

export interface PageItesPerPage {
  pageN: number;
  itemsPerPage: number;
}

@Component({
  selector: 'app-Pagination',
  templateUrl: './Pagination.component.html',
  styleUrls: ['./Pagination.component.css'],
})
export class PaginationComponent implements OnInit {
  @Input() pagesAmount: number = 1;
  public currentPage: number = 1;
  public itemsPerPageList: number[] = [2, 4, 6, 8, 10, 12];
  public currentItemsPerPage: number = 0;
  @Output() newItemEvent = new EventEmitter<PageItesPerPage>();

  constructor() {
    this.currentItemsPerPage = this.itemsPerPageList[1];
    this.setCurrentPage(this.currentPage, this.itemsPerPageList);
  }

  setCurrentPage(page: number, itemsPerPage: any = null) {
    // if (!itemsPerPage) itemsPerPage = 1;
    // this.currentItemsPerPage = itemsPerPage?.target?.value;

    this.currentPage = page;

    this.newItemEvent.emit({
      pageN: page,
      itemsPerPage: this.currentItemsPerPage,
    } as PageItesPerPage);
  }

  ngOnInit() {}
}
