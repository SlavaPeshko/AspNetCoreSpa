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
  public loginFormGroup: FormGroup;
  public emailOrPhone: string;
  public password: string;
  hide: boolean = true;

  constructor(private auth: AuthService) { }
  
  ngOnInit() {
    this.loginFormGroup = new FormGroup({
      emailOrPhone: new FormControl('', [Validators.required, Validators.pattern(emailRegex)]),
      password: new FormControl('', [Validators.required, Validators.minLength(8), Validators.pattern(passwordRegex)])
    })
  }

  public hasError(controlName: string, errorName: string): boolean {
    return this.loginFormGroup.controls[controlName].hasError(errorName);
  }

  public login() {
    if (this.emailOrPhone && this.password ){
      this.auth.login({ emailOrPhone: this.emailOrPhone, password: this.password });
    }
  }
}
