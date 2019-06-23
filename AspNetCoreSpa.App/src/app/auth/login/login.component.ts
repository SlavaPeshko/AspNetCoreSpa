import { Component, OnInit } from '@angular/core';
import { FormControl, Validators, FormGroup } from '@angular/forms';

const emailOrPhonePattern: string = '([_a-z0-9]+(\.[_a-z0-9]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,5}))|(\d+$)$';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  public loginFormGroup: FormGroup;

  constructor() { }
  
  ngOnInit() {
    this.loginFormGroup = new FormGroup({
      // emailOrPhone: new FormControl('', [Validators.required, Validators.pattern(emailOrPhonePattern)]),
      emailOrPhone: new FormControl('', [Validators.required]),
      password: new FormControl('', [Validators.required, Validators.minLength(8)])
    })
  }

  public hasError(controlName: string, errorName: string): boolean {
    return this.loginFormGroup.controls[controlName].hasError(errorName);
  }

}
