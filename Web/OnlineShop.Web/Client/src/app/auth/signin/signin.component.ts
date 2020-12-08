import { Component, OnInit } from '@angular/core';
import { AbstractControl, Validators, FormBuilder, FormGroup } from '@angular/forms';
import { AuthService } from '../../core/services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-signin',
  templateUrl: './signin.component.html',
  styleUrls: ['./signin.component.css']
})
export class SigninComponent implements OnInit {
  signInForm: FormGroup;
  wrongCredentials: boolean = false;
  successfulCredentials: boolean = false;

  constructor(
    private fb: FormBuilder,
    private authService: AuthService,
    private router: Router
  ) { }

  ngOnInit() {
    this.signInForm = this.fb.group({
      username: [null, [Validators.required]],
      password: [null, [Validators.required]]
    })
  }

  signIn() {
    const { username, password } = this.signInForm.value;

    this.authService.login(username, password)
      .subscribe((token: string) => {
        this.successfulCredentials = true;
        setTimeout(function () { this.successfulCredentials = false }, 2000);
        this.authService.setToken(token);
        this.authService.initializeAuthenticationState();
        this.router.navigate(['/']);
      },
        err => {
          this.wrongCredentials = true;
          setTimeout(function () { this.wrongCredentials = false }, 2000);
        });
  }

  get username(): AbstractControl {
    return this.signInForm.get('username');
  }

  get password(): AbstractControl {
    return this.signInForm.get('password');
  }
}
