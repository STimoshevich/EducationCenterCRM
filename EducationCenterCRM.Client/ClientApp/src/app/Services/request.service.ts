import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Student } from '../Interfaces/studentInterfaces';
import {
  StudingRequest,
  StudingRequestsList,
} from '../Interfaces/studingRequestsInterfaces';

@Injectable()
export class RequestService {
  public requests: StudingRequest[] = [];
  baseurl!: string;
  constructor(
    public httpClient: HttpClient,
    @Inject('BASE_URL') baseUrl: string
  ) {
    this.baseurl = baseUrl;
  }

  GetAllOpen(
    pageN: number,
    itemsPerPage: number
  ): Observable<StudingRequestsList> {
    return this.httpClient.get<StudingRequestsList>(
      this.baseurl + 'studingrequests/getallopen',
      {
        params: { page: pageN, itemsPerPage: itemsPerPage },
      }
    );
  }

  ConfirmRequest(requestId: number, groupId: number): Observable<any> {
    return this.httpClient.post<any>(
      this.baseurl + 'studingrequests/confirmrequest',
      {
        requestId: requestId,
        groupId: groupId,
      }
    );
  }

  GetAllStudingTypes(): Observable<string[]> {
    return this.httpClient.get<string[]>(
      this.baseurl + 'studingrequests/getallstydingtypes'
    );
  }

  GetAllClosed(
    pageN: number,
    itemsPerPage: number
  ): Observable<StudingRequestsList> {
    return this.httpClient.get<StudingRequestsList>(
      this.baseurl + 'studingrequests/getallclosed',
      {
        params: { page: pageN, itemsPerPage: itemsPerPage },
      }
    );
  }
  GetStudentInfoById(id: string): Observable<Student> {
    return this.httpClient.get<Student>(this.baseurl + 'students/getbyid', {
      params: { id: id },
    });
  }
  GetOpenedGroupsByCourseId(Id: number): Observable<Student> {
    return this.httpClient.get<Student>(this.baseurl + 'groups/getnotstarted');
  }
}
