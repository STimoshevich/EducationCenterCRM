import { HttpClient } from '@angular/common/http';
import { getAllLifecycleHooks } from '@angular/compiler/src/lifecycle_reflector';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Course } from '../interfaces/interfaces';
import { tap } from 'rxjs/operators';

@Injectable()
export class CourseService {
  baseurl!: string;
  /**
   *
   */
  constructor(
    public httpClient: HttpClient,
    @Inject('BASE_URL') baseUrl: string
  ) {
    this.baseurl = baseUrl;
  }

  getAll(url: string): Observable<Course[]> {
    return this.httpClient.get<Course[]>(this.baseurl + 'courses');
  }
}
