import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import {
  Course,
  CourseFilter,
  CourseList,
  CourseTitleWithId,
} from '../Interfaces/courseInterfaces';
import { TeacherNameWithId } from '../Interfaces/teacherInterfaces';
import { IdentityService } from './identity.service';
import { CommonService } from './common.service';

@Injectable()
export class CourseService {
  baseurl!: string;
  /**
   *
   */
  constructor(
    public httpClient: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    public authService: IdentityService,
    public commonService: CommonService
  ) {
    this.baseurl = baseUrl;
  }

  GetAll(pageN: number, itemsPerPage: number): Observable<CourseList> {
    return this.httpClient.get<CourseList>(this.baseurl + 'courses', {
      params: { page: pageN, itemsPerPage: itemsPerPage },
    });
  }

  GetAllTitlesWithId(): Observable<CourseTitleWithId[]> {
    return this.httpClient.get<CourseTitleWithId[]>(
      this.baseurl + 'courses/alltitles'
    );
  }

  Search(searchInput: string, pageN: number, itemsPerPage: number) {
    return this.httpClient.get<CourseList>(this.baseurl + 'courses/search', {
      params: { searchString: searchInput, itemsPerPage: itemsPerPage },
    });
  }

  GetById(id: number): Observable<Course> {
    return this.httpClient.get<Course>(this.baseurl + 'courses/getbyid', {
      params: { id: id },
    });
  }

  SignUp(courseId: number) {
    let tokens = this.authService.getTokens();

    const headerDict = {
      'Content-Type': 'application/json',
      Accept: '*/*',
      Authorization: ' bearer ' + tokens?.token,
    };
    const requestOptions = {
      headers: new HttpHeaders(headerDict),
    };
    return this.httpClient.post(
      this.baseurl + 'studingrequests/add',
      courseId,
      requestOptions
    );
  }

  GetAllCourseLvlNames(): Observable<string[]> {
    return this.httpClient.get<string[]>(
      this.baseurl + 'courses/courselvlnames'
    );
  }

  GetAllTeachersNamesAndIdByCourse(
    courseid: number
  ): Observable<TeacherNameWithId[]> {
    return this.httpClient.get<TeacherNameWithId[]>(
      this.baseurl + 'courses/getteachers',
      { params: { courseId: courseid } }
    );
  }

  GetAllByFilters(
    filter: CourseFilter,
    pageN: number,
    itemsPerPage: number
  ): Observable<CourseList> {
    let params = this.commonService.ObjectToHttpParams(filter);

    params = params.append('page', pageN);
    params = params.append('itemsPerPage', itemsPerPage);

    return this.httpClient.get<CourseList>(
      this.baseurl + 'courses/getbyfilter',
      {
        params: params,
      }
    );
  }

  Update(form: any): Observable<any> {
    // return this.httpClient.put<any>(this.baseurl + 'courses/update', form);
    return this.httpClient.put<any>(this.baseurl + 'courses', form);
  }

  Create(form: any): Observable<any> {
    return this.httpClient.post<any>(this.baseurl + 'courses', form);
  }
}
