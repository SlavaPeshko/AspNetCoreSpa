import { Component, OnInit } from '@angular/core';
import { FormControl, Validators, FormGroup } from '@angular/forms';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  public loginForm: FormGroup;

  constructor(private auth: AuthService) { }
  
  ngOnInit() {
    this.loginForm = new FormGroup({
      email: new FormControl('', [Validators.required, Validators.email]),
      password: new FormControl('', [Validators.required, Validators.pattern('(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9]).{8,}$')])
    })
  }

  get email() {
    return this.loginForm.get('email');
  }

  get password() {
    return this.loginForm.get('password');
  }

  // public hasError(controlName: string, errorName: string): boolean {
  //   return this.loginForm.controls[controlName].hasError(errorName);
  // }

  public login() {
    if(this.email.errors || this.password.errors) {
      this.loginForm.markAllAsTouched();
    } else {
      this.auth.login({ email: this.email.value, password: this.password.value });
    }
  }
}
