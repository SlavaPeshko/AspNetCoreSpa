import { Component, OnInit } from '@angular/core';
import { FormControl, Validators, FormGroup } from '@angular/forms';
import { AuthService } from '../../services/auth.service';

const emailRegex: RegExp = new RegExp(/^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$/g);
const passwordRegex: RegExp = new RegExp(/^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,15}$/g);

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
      emailOrPhone: new FormControl('', [Validators.required, Validators.pattern(emailRegex)]),
      password: new FormControl('', [Validators.required, Validators.minLength(8), Validators.pattern(passwordRegex)])
    })
  }

  get emailOrPhone() {
    return this.loginForm.get('emailOrPhone');
  }

  get password() {
    return this.loginForm.get('password');
  }

  // public hasError(controlName: string, errorName: string): boolean {
  //   return this.loginForm.controls[controlName].hasError(errorName);
  // }

  public login() {
    if (this.emailOrPhone.value && this.password.value){
      this.auth.login({ emailOrPhone: this.emailOrPhone.value, password: this.password.value });
    }
  }
}
