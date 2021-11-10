import { Component, Inject, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Group } from 'src/app/Interfaces/groupInterfaces';
import { Student } from 'src/app/Interfaces/studentInterfaces';
import {
  StudingRequest,
  StudingRequestsList,
} from 'src/app/Interfaces/studingRequestsInterfaces';
import { GroupService } from 'src/app/Services/group.service';
import { RequestService } from '../../Services/request.service';

@Component({
  selector: 'app-requests',
  templateUrl: './requests.component.html',
  styleUrls: ['./requests.component.css'],
})
export class RequestsComponent implements OnInit {
  public requestsList: StudingRequestsList = {} as StudingRequestsList;
  public student!: Student | null;
  public itemsPerPage = 1000;
  public isResultOpenRequests: boolean = true;
  public stydingTypes: string[] = [];
  public pickedRequestId: number = 0;
  public avalibleGroups: Group[] = [];
  public pickedGroupId: number = 0;
  constructor(
    public requestService: RequestService,
    public groupService: GroupService,
    public route: ActivatedRoute,
    public router: Router
  ) {
    this.GetAllOpen(1);
  }

  GetAllOpen(pageN: number) {
    this.isResultOpenRequests = true;
    this.requestService.GetAllOpen(pageN, this.itemsPerPage).subscribe(
      (result) => {
        this.requestsList = result;
      },
      (error) => console.error(error)
    );
  }

  GetAvalibleGroups() {
    this.groupService.GetCoursesByRequestId(this.pickedRequestId).subscribe(
      (result) => {
        this.avalibleGroups = result;
      },
      (error) => console.log(error)
    );
  }

  GetAllClosed(pageN: number) {
    this.isResultOpenRequests = false;
    this.requestService.GetAllClosed(pageN, this.itemsPerPage).subscribe(
      (result) => {
        this.requestsList = result;
      },
      (error) => console.error(error)
    );
  }

  Save() {
    this.requestService
      .ConfirmRequest(this.pickedRequestId, this.pickedGroupId)
      .subscribe(
        (result) => {
          location.reload();
        },
        (error) => console.error(error)
      );
  }

  OffcanvasInfo(pickedrequestId: number, studentId: string, courseId: number) {
    this.student = null;
    this.pickedRequestId = pickedrequestId;
    this.GetAvalibleGroups();
    this.requestService.GetStudentInfoById(studentId).subscribe(
      (result) => {
        this.student = result;
        console.log(result);
      },
      (error) => console.error(error)
    );
  }

  GetStydingTypes() {
    if (this.stydingTypes.length === 0) {
      this.requestService.GetAllStudingTypes().subscribe(
        (result) => {
          this.stydingTypes = result;
        },
        (error) => console.error(error)
      );
    }
  }

  ngOnInit() {}
}
