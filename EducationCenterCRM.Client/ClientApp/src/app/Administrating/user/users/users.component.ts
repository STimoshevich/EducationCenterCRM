import { Component, OnInit } from '@angular/core';
import {
  User,
  UserList,
  RoleNameWithId,
} from 'src/app/Interfaces/IdentityInterfaces';
import { CommonService } from 'src/app/Services/common.service';
import { IdentityService } from 'src/app/Services/identity.service';
import { PageItesPerPage as PageItemsPerPage } from 'src/app/Pagination/Pagination.component';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css'],
})
export class UsersComponent implements OnInit {
  public users: User[] = [];
  public itemsPerPage: number = 100;
  public pageAmount: number = 1;
  public rolesNamesWithId: RoleNameWithId[] = [];
  constructor(
    public identityService: IdentityService,
    public commonService: CommonService
  ) {
    this.GetAll(1);
    this.GetAllRolesNamesWithId();
  }
  ngOnInit(): void {}

  GetAll(pageN: number) {
    this.identityService.GetAllUsers(pageN, this.itemsPerPage).subscribe(
      (result) => {
        console.log(result);
        this.users = result.users;
        this.pageAmount = this.commonService.PageCountCalculator(
          result.usersAmount,
          this.itemsPerPage
        );
      },
      (error) => console.error(error)
    );
  }

  GetAllRolesNamesWithId() {
    this.identityService.GetAllRolesNameWithId().subscribe(
      (result) => {
        console.log(result);
        this.rolesNamesWithId = result;
      },
      (error) => console.error(error)
    );
  }

  changebyfilter(userList: UserList) {
    this.users = userList.users;
    this.pageAmount = this.commonService.PageCountCalculator(
      userList.usersAmount,
      this.itemsPerPage
    );
  }

  MoveToPage(pageItemsPerPage: PageItemsPerPage) {
    this.itemsPerPage = pageItemsPerPage.itemsPerPage;
    this.GetAll(pageItemsPerPage.pageN);
  }

  ChangeRole(roleName: string, userId: string) {
    this.identityService.ChengeRoles(roleName, userId).subscribe(
      (result) => {
        this.GetAll(1);
      },
      (error) => {
        console.log(error);
        this.GetAll(1);
      }
    );
  }
}
