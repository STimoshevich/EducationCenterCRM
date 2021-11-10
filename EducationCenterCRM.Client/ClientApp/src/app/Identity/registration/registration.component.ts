import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { IdentityService } from '../../Services/identity.service';
import {
  AuthentificationResult,
  RequestErrors,
  Tokens,
} from '../../Interfaces/IdentityInterfaces';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: [],
})
export class RegistrationComponent implements OnInit {
  registrationForm!: FormGroup;
  requestErrors: string[] = [];
  // formData: FormData = new FormData();
  constructor(
    public authService: IdentityService,
    public route: ActivatedRoute,
    public router: Router
  ) {}

  ngOnInit() {
    this.registrationForm = new FormGroup({
      email: new FormControl(),
      password: new FormControl(),
      name: new FormControl(),
      lastname: new FormControl(),
      birthdate: new FormControl(),
      phone: new FormControl(),
      photo: new FormControl(),
    });
  }

  Submit() {
    this.authService.registration(this.registrationForm.value).subscribe(
      (result) => {
        let tokens: Tokens = {
          token: result.token,
          refreshToken: result.refreshToken,
        };
        this.authService.setTokens(tokens);
        this.route.queryParams.subscribe((params) => {
          const returnUrl = params['returnUrl'];
          if (returnUrl) {
            this.router.navigate(['/' + returnUrl]);
          } else {
            this.router.navigate(['/allcourses']);
          }
        });
      },
      (error) => {
        let errors = this.authService.ExtractServerValidationErrors(error);
        if (errors) {
          this.requestErrors;
        }
      }
    );
  }
}
