import { Component, OnInit } from '@angular/core';
import { FormControl, Validators, FormGroup } from '@angular/forms';

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
      emailOrPhone: new FormControl('', [Validators.required]),
      password: new FormControl('', [Validators.required, Validators.minLength(8)])
    })
  }

  public hasError(controlName: string, errorName: string): boolean {
    return this.loginFormGroup.controls[controlName].hasError(errorName);
  }

}
