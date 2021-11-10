import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import {
  Teacher,
  TeacherFilter,
  TeacherList,
  TeacherNameWithId,
} from '../Interfaces/teacherInterfaces';
import { CommonService } from './common.service';

@Injectable({
  providedIn: 'root',
})
export class TeacherService {
  baseurl: string;

  constructor(
    public httpClient: HttpClient,
    public commonService: CommonService,
    @Inject('BASE_URL') baseUrl: string
  ) {
    this.baseurl = baseUrl;
  }

  updateCourses(
    teacherId: number,
    res: number[]
  ): Observable<TeacherNameWithId[]> {
    return this.httpClient.post<any>(
      this.baseurl + 'teachers/updatecourses',
      res,
      { params: { teacherId: teacherId } }
    );
  }

  GetAllNamesWithId(): Observable<TeacherNameWithId[]> {
    return this.httpClient.get<TeacherNameWithId[]>(
      this.baseurl + 'teachers/allnames'
    );
  }
  GetAllByFilters(
    groupFilter: TeacherFilter,
    pageN: number,
    itemsPerPage: number
  ): Observable<TeacherList> {
    let params = this.commonService.ObjectToHttpParams(groupFilter);

    params = params.append('page', pageN);
    params = params.append('itemsPerPage', itemsPerPage);

    return this.httpClient.get<TeacherList>(
      this.baseurl + 'teachers/getbyfilter',
      {
        params: params,
      }
    );
  }
  Update(form: any): Observable<any> {
    return this.httpClient.put<any>(this.baseurl + 'teachers/update', form);
  }
  Create(form: any): Observable<any> {
    return this.httpClient.post<any>(this.baseurl + 'teachers/create', form);
  }
  GetById(id: number): Observable<Teacher> {
    return this.httpClient.get<Teacher>(this.baseurl + 'teachers/getbyid', {
      params: { id: id },
    });
  }

  GetAll(pageN: number, itemsPerPage: number): Observable<TeacherList> {
    return this.httpClient.get<TeacherList>(this.baseurl + 'teachers', {
      params: { page: pageN, itemsPerPage: itemsPerPage },
    });
  }
}
