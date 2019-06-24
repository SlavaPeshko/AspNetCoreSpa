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
  public labelPosition: string = 'after';
  user_validation_message: any;

  constructor() { 
    this.user_validation_message = User_Validation_Message;
  }

  ngOnInit() {
    this.signUpFormGroup = new FormGroup({
      firstName: new FormControl('', Validators.required),
      lastName: new FormControl('', Validators.required),
      emailOrPhoneNumber: new FormControl('', Validators.required),
      password: new FormControl('', Validators.required),
      confirmPassword: new FormControl('', Validators.required),
      birthDay: new FormControl('', Validators.required)
    })
  }

  public hasError(controlName: string, errorName: string): boolean {
    return this.signUpFormGroup.controls[controlName].hasError(errorName);
  }

}
