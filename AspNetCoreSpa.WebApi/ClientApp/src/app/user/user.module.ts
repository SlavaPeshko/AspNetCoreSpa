import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { ProfileComponent } from './profile/profile.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ChangeEmailComponent } from './change-email/change-email.component';
import { SettingsComponent } from './settings/settings.component';

@NgModule({
  declarations: [ProfileComponent, ChangeEmailComponent, SettingsComponent],
  imports: [
    CommonModule,
    RouterModule,
    FormsModule,
    NgbModule,
    ReactiveFormsModule
  ],
  exports: [
    ProfileComponent
  ]
})
export class UserModule { }