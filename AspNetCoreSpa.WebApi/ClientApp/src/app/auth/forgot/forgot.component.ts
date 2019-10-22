import { Component, OnInit } from '@angular/core';
import { FormControl, Validators, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-forgot',
  templateUrl: './forgot.component.html',
  styleUrls: ['./forgot.component.css']
})
export class ForgotComponent implements OnInit {
  public fogotForm: FormGroup;

  constructor() { }

  ngOnInit() {
    this.fogotForm = new FormGroup({
      email: new FormControl('', [Validators.required, Validators.email]),
    })
  }

  get email() {
    return this.fogotForm.get('email');
  }

  next() {
    if(this.email.errors) {
      this.email.markAsTouched();
    } else {
      console.log(this.email.value);
    }
  }
}
