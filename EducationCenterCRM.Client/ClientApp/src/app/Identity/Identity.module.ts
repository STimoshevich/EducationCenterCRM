import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './login/login.component';
import { RegistrationComponent } from './registration/registration.component';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';
import { IdentityService } from '../Services/identity.service';

@NgModule({
  imports: [
    CommonModule,
    ReactiveFormsModule,
    RouterModule.forChild([
      {
        path: 'registration',
        component: RegistrationComponent,
      },
      { path: 'login', component: LoginComponent },
    ]),
  ],
  declarations: [LoginComponent, RegistrationComponent],
  providers: [IdentityService],
})
export class IdentityModule {}
