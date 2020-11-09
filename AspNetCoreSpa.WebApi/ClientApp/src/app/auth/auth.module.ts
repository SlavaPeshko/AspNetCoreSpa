import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from "./login/login.component";
import { ForgotComponent } from './forgot/forgot.component';
import { SignUpComponent } from './sign-up/sign-up.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { NgxIntlTelInputModule } from 'ngx-intl-tel-input';
import { PhoneForgotComponent } from './phone-forgot/phone-forgot.component';
// import { AppMaterialModule } from "../app-material/app-material.module";

@NgModule({
  declarations: [LoginComponent, ForgotComponent, SignUpComponent, PhoneForgotComponent],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule,
    // AppMaterialModule,
    NgxIntlTelInputModule,
  ],
})
export class AuthModule { }
