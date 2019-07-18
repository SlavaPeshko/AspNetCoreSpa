import { Component, OnInit } from '@angular/core';
import { FormControl, Validators, FormGroup } from '@angular/forms';
import { HttpClient, HttpHeaders } from '@angular/common/http';

const emailOrPhonePattern: string = '([_a-z0-9]+(\.[_a-z0-9]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,5}))|(\d+$)$';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
};

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  public loginFormGroup: FormGroup;
  public emailOrPhone: string;
  public password: string;

  constructor(private http: HttpClient) { }
  
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

  public login() {
    const body = { emailOrPhone: this.emailOrPhone, password: this.password };
    debugger;
    try {
      this.http.post('http://localhost:5000/api/user/login', body, {
        headers: new HttpHeaders({
          'Content-Type': 'application/json'
        })
      });
    } catch (error) {
      
    }
  }
}
