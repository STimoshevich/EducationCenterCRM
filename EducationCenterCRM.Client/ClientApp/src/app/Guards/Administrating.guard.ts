import { Injectable } from '@angular/core';
import {
  CanActivate,
  ActivatedRouteSnapshot,
  RouterStateSnapshot,
} from '@angular/router';
import { Observable } from 'rxjs';
import { IdentityService } from '../Services/identity.service';

@Injectable()
export class AdministratingGuard implements CanActivate {
  constructor(public authService: IdentityService) {}
  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): Observable<boolean> | boolean {
    if (this.authService.isAdmin() || this.authService.isManager()) {
      return true;
    }
    return false;
  }
}
