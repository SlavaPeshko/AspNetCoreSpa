import { Component, OnInit } from '@angular/core';
import { FormControl, Validators, FormGroup } from '@angular/forms';
import { User_Validation_Message } from "../user_validation_message";

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.css']
})
export class SignUpComponent implements OnInit {
  public signUpFormGroup: FormGroup;
  user_validation_message: any;

  constructor() { 
    this.user_validation_message = User_Validation_Message;
  }

  ngOnInit() {
    this.signUpFormGroup = new FormGroup({
      email: new FormControl('', [Validators.required, Validators.email]),
      password: new FormControl('', [Validators.required, Validators.pattern('(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9]).{8,}$')]),
      confirmPassword: new FormControl('', Validators.required),
    })
  }

  get email() {
    return this.signUpFormGroup.get('email');
  }

  get password() {
    return this.signUpFormGroup.get('password');
  }

  get confirmPassword() {
    return this.signUpFormGroup.get('confirmPassword');
  }
}
