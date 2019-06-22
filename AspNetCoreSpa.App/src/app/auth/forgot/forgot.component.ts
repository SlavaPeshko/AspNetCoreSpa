import { Component, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-forgot',
  templateUrl: './forgot.component.html',
  styleUrls: ['./forgot.component.css']
})
export class ForgotComponent implements OnInit {
  public emailOrPhone: FormControl;

  constructor() { }

  ngOnInit() {
    this.emailOrPhone = new FormControl('', [Validators.required]);
  }
}
