import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class TopicService {
  baseurl!: string;
  constructor(
    public httpClient: HttpClient,
    @Inject('BASE_URL') baseUrl: string
  ) {
    this.baseurl = baseUrl;
  }

  getAllTitles(): Observable<string[]> {
    return this.httpClient.get<string[]>(this.baseurl + 'topics/alltitles');
  }
}
