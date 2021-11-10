import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import jwt_decode from 'jwt-decode';
import {
  AuthentificationResult,
  LoginModel,
  Tokens,
  RegistrationModel,
  UserFilter,
  UserList,
  RoleNameWithId,
} from '../Interfaces/IdentityInterfaces';
import { CommonService } from './common.service';

@Injectable()
export class IdentityService {
  baseurl!: string;
  refreshToken!: string;
  isRefreshTokenRequestSended: boolean = false;

  /**
   *
   */
  constructor(
    public httpClient: HttpClient,
    public commonService: CommonService,
    @Inject('BASE_URL') baseUrl: string
  ) {
    this.baseurl = baseUrl;
  }

  GetAllUsers(pageN: number, itemsPerPage: number): Observable<UserList> {
    return this.httpClient.get<UserList>(
      this.baseurl + 'identity/getallusers',
      {
        params: { page: pageN, itemsPerPage: itemsPerPage },
      }
    );
  }

  ChengeRoles(roleName: string, userId: string): Observable<any> {
    return this.httpClient.put<any>(this.baseurl + 'identity/changeroles', {
      roleName: roleName,
      userId: userId,
    });
  }

  GetAllRolesNameWithId(): Observable<RoleNameWithId[]> {
    return this.httpClient.get<RoleNameWithId[]>(
      this.baseurl + 'identity/getallroles'
    );
  }

  GetAllByFilters(
    userFilter: UserFilter,
    page: number,
    itemsPerPage: number
  ): Observable<UserList> {
    let params = this.commonService.ObjectToHttpParams(userFilter);

    params = params.append('page', page);
    params = params.append('itemsPerPage', itemsPerPage);

    return this.httpClient.get<UserList>(
      this.baseurl + 'identity/getbyfilter',
      {
        params: params,
      }
    );
  }

  login(loginModel: LoginModel): Observable<AuthentificationResult> {
    return this.httpClient.post<AuthentificationResult>(
      this.baseurl + 'identity/login',
      loginModel
    );
  }

  logout() {
    localStorage.clear();
  }

  registration(registrationModel: any): Observable<AuthentificationResult> {
    return this.httpClient.post<AuthentificationResult>(
      this.baseurl + 'identity/registration',
      registrationModel
    );
  }

  refresh(tokens: Tokens): Observable<AuthentificationResult> {
    return this.httpClient.post<AuthentificationResult>(
      this.baseurl + 'identity/refresh',
      tokens
    );
  }

  setTokens(tokens: Tokens) {
    if (tokens) {
      localStorage.setItem('token', tokens.token);
      localStorage.setItem('refreshToken', tokens.refreshToken);
    }
  }

  getTokens(): Tokens | null {
    let token = localStorage.getItem('token');
    let refreshToken = localStorage.getItem('refreshToken');
    if (!token || !refreshToken) {
      return null;
    }

    let tokens: Tokens = {
      token: token,
      refreshToken: refreshToken,
    };

    return tokens;
  }

  isAuthorized(): boolean {
    let token = localStorage.getItem('token');
    if (!token) {
      return false;
    }
    if (this.isRefreshTokenRequestSended === false) {
      let decodedToken: any = jwt_decode(token);
      if (new Date(decodedToken.exp * 1000) > new Date()) {
        return true;
      } else {
        let tokens: Tokens = {
          token: <string>localStorage.getItem('token'),
          refreshToken: <string>localStorage.getItem('refreshToken'),
        };
        this.isRefreshTokenRequestSended = true;
        this.refresh(tokens).subscribe(
          (result) => {
            this.isRefreshTokenRequestSended = false;
            let tokens: Tokens = {
              token: result.token,
              refreshToken: result.refreshToken,
            };
            this.setTokens(tokens);
          },
          (error) => {
            this.isRefreshTokenRequestSended = false;
            this.logout();
          }
        );
      }
    }

    return true;
  }

  GetRolles(): string[] | null {
    if (this.isAuthorized()) {
      let token = localStorage.getItem('token');
      if (token) {
        let decodedToken: any = jwt_decode(token);
        var roles = <string[]>decodedToken.role;
        return roles;
      }
    }

    return null;
  }

  isAdmin(): boolean {
    let roles = this.GetRolles();
    if (roles) {
      let roleIndex = roles.indexOf('Admin');
      if (roleIndex > -1) return true;
    }

    return false;
  }

  isStudent(): boolean {
    let roles = this.GetRolles();
    if (roles) {
      let roleIndex = roles.indexOf('Student');
      if (roleIndex > -1) return true;
    }

    return false;
  }

  isManager(): boolean {
    let roles = this.GetRolles();
    if (roles) {
      let roleIndex = roles.indexOf('Manager');
      if (roleIndex > -1) return true;
    }

    return false;
  }

  ExtractServerValidationErrors(error: any): string[] | null {
    let requestErrors: string[] = [];
    let errorKeys = Object.getOwnPropertyNames(error.error.errors);
    for (let errorKey of errorKeys) {
      if (Array.isArray(error.error.errors[errorKey])) {
        for (let errorMessage of error.error.errors[errorKey]) {
          requestErrors.push(errorKey + ': ' + errorMessage);
        }
      } else {
        requestErrors.push(error.error.errors[errorKey]);
      }
    }
    return requestErrors;
  }
}
