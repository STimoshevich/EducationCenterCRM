import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import {
  RoleNameWithId,
  UserFilter,
  UserList,
} from 'src/app/Interfaces/IdentityInterfaces';
import { IdentityService } from 'src/app/Services/identity.service';

@Component({
  selector: 'app-UserFilter',
  templateUrl: './UserFilter.component.html',
  styleUrls: ['./UserFilter.component.css'],
})
export class UserFilterComponent implements OnInit {
  public userFilter: UserFilter = {} as UserFilter;
  public rolesNamesWithId: RoleNameWithId[] = [];
  @Output() FilteredResultEvent = new EventEmitter<UserList>();
  constructor(public identityService: IdentityService) {}

  FieldChanged(page: number = 1, itemsPerPage: number = 4) {
    this.identityService
      .GetAllByFilters(this.userFilter, page, itemsPerPage)
      .subscribe(
        (result) => {
          this.FilteredResultEvent.emit(result);
        },
        (error) => console.error(error)
      );
  }

  GetAllRoles() {
    if (this.rolesNamesWithId?.length === 0) {
      this.identityService.GetAllRolesNameWithId().subscribe(
        (result) => {
          if (result) this.rolesNamesWithId = result;
        },
        (error) => console.error(error)
      );
    }
  }

  ngOnInit() {}
}
