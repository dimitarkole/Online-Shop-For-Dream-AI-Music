import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, AbstractControl } from '@angular/forms';
import { AuthService } from '../../core/services/auth.service';
import { Router } from '@angular/router';
import { ConfirmedValidator } from '../../common/confirmed.validator';
import User from '../../shared/models/user';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit {
  signUpForm: FormGroup;
  wrongCredentials: boolean = false;
  successfulCredentials: boolean = false;

  constructor(
    private fb: FormBuilder,
    private authService: AuthService,
    private router: Router
  ) { }

  ngOnInit() {
    this.signUpForm = this.fb.group({
      email: [null, [Validators.required, Validators.email]],
      firstName: [null, [Validators.required]],
      lastName: [null, [Validators.required]],
      username: [null, [Validators.required]],
      password: [null, [Validators.required]],
      confirmPassword: [null, [Validators.required]],
    }, {
      validator: ConfirmedValidator('password', 'confirmPassword')
    });
  }

  signUp() {
    let newUser: User = this.signUpForm.value;
    this.authService.create(newUser)
      .subscribe(_ => {
        this.successfulCredentials = true;
        setTimeout(function () { this.successfulCredentials = false }, 2000);
        this.authService.login(newUser.username, newUser.password)
          .subscribe((token: string) => {
            this.authService.setToken(token);
            this.authService.initializeAuthenticationState();
            this.router.navigate(['/']);
          },
            err => {
              this.wrongCredentials = true;
              setTimeout(function () { this.wrongCredentials = false }, 2000);
            });
      },
        err => {
          this.wrongCredentials = true;
          setTimeout(function () { this.wrongCredentials = false }, 2000);
        });
  }

  get password(): AbstractControl {
    return this.signUpForm.get('password');
  }

  get email(): AbstractControl {
    return this.signUpForm.get('email');
  }

  get username(): AbstractControl {
    return this.signUpForm.get('username');
  }

  get firstName(): AbstractControl {
    return this.signUpForm.get('firstName');
  }

  get lastName(): AbstractControl {
    return this.signUpForm.get('lastName');
  }

  get confirmPassword(): AbstractControl {
    return this.signUpForm.get('confirmPassword');
  }

  get birthday(): AbstractControl {
    return this.signUpForm.get('birthday');
  }
}
