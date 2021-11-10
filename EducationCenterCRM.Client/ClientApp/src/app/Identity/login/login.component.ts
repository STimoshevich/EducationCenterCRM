import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { IdentityService } from '../../Services/identity.service';
import { Tokens } from '../../Interfaces/IdentityInterfaces';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {
  loginForm!: FormGroup;
  requestErrors: string[] = [];

  constructor(
    public authService: IdentityService,
    public route: ActivatedRoute,
    public router: Router
  ) {}

  ngOnInit() {
    this.loginForm = new FormGroup({
      email: new FormControl(),
      password: new FormControl(),
    });
  }

  Submit() {
    this.authService.login(this.loginForm.value).subscribe(
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
