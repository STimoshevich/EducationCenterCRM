import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';

@Injectable()
export class AuthService {
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

  login(){

  }

  logout(){

  }
  registration(){
      
  }
  refresh(){

  }
 
  }
}
