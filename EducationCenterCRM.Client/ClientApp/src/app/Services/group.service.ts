import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Group, GroupFilter, GroupList } from '../Interfaces/groupInterfaces';
import { Student } from '../Interfaces/studentInterfaces';
import { CommonService } from './common.service';

@Injectable({
  providedIn: 'root',
})
export class GroupService {
  baseurl: string;
  constructor(
    public httpClient: HttpClient,
    public commonService: CommonService,
    @Inject('BASE_URL') baseUrl: string
  ) {
    this.baseurl = baseUrl;
  }

  GetAllByFilters(
    groupFilter: GroupFilter,
    pageN: number,
    itemsPerPage: number
  ): Observable<GroupList> {
    let params = this.commonService.ObjectToHttpParams(groupFilter);

    params = params.append('page', pageN);
    params = params.append('itemsPerPage', itemsPerPage);

    return this.httpClient.get<GroupList>(this.baseurl + 'groups/getbyfilter', {
      params: params,
    });
  }
  Update(form: any): Observable<any> {
    console.log(form);
    return this.httpClient.put<any>(this.baseurl + 'groups/update', form);
  }
  Create(form: any): Observable<any> {
    return this.httpClient.post<any>(this.baseurl + 'groups/create', form);
  }
  GetById(id: number): Observable<Group> {
    return this.httpClient.get<Group>(this.baseurl + 'groups/getbyid', {
      params: { id: id },
    });
  }

  GetCoursesByRequestId(pickedRequestId: number): Observable<Group[]> {
    return this.httpClient.get<Group[]>(this.baseurl + 'groups/getbyrequest', {
      params: { requestId: pickedRequestId },
    });
  }

  GetAllStatusNames(): Observable<string[]> {
    return this.httpClient.get<string[]>(
      this.baseurl + 'groups/getallstatuses'
    );
  }

  GetAll(pageN: number, itemsPerPage: number): Observable<GroupList> {
    return this.httpClient.get<GroupList>(this.baseurl + 'groups', {
      params: { page: pageN, itemsPerPage: itemsPerPage },
    });
  }

  GetAllStudentsByCourseid(groupId: number): Observable<Student[]> {
    return this.httpClient.get<Student[]>(this.baseurl + 'groups/getstudents', {
      params: { groupId: groupId },
    });
  }
}
