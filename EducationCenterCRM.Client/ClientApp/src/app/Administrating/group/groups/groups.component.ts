import { Component, OnInit } from '@angular/core';
import { Group, GroupList } from 'src/app/Interfaces/groupInterfaces';
import { CommonService } from 'src/app/Services/common.service';
import { GroupService } from 'src/app/Services/group.service';
import { PageItesPerPage as PageItemsPerPage } from 'src/app/Pagination/Pagination.component';

@Component({
  selector: 'app-groups',
  templateUrl: './groups.component.html',
  styleUrls: ['./groups.component.css'],
})
export class GroupsComponent implements OnInit {
  public groups: Group[] = [];
  public itemsPerPage: number = 100;
  public pageAmount: number = 1;
  constructor(
    public groupService: GroupService,
    public commonService: CommonService
  ) {
    this.GetAll(1);
  }

  GetAll(pageN: number) {
    this.groupService.GetAll(pageN, this.itemsPerPage).subscribe(
      (result) => {
        this.groups = result.groups;
        this.pageAmount = this.commonService.PageCountCalculator(
          result.groupsAmount,
          this.itemsPerPage
        );
      },
      (error) => console.error(error)
    );
  }

  changebyfilter(groupList: GroupList) {
    console.log('byfilter', groupList);
    this.groups = groupList.groups;
    this.pageAmount = this.commonService.PageCountCalculator(
      groupList.groupsAmount,
      this.itemsPerPage
    );
  }

  MoveToPage(pageItemsPerPage: PageItemsPerPage) {
    // this.itemsPerPage = pageItemsPerPage.itemsPerPage;
    // this.GetAll(pageItemsPerPage.pageN);
  }

  ngOnInit() {}
}
