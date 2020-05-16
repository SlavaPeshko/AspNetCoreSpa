import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { ProfileComponent } from './profile/profile.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ChangeEmailComponent } from './change-email/change-email.component';
import { SettingsComponent } from './settings/settings.component';
import { EditPictureComponent } from './edit-picture/edit-picture.component';
import { ImageCropperModule } from 'ngx-image-cropper';

@NgModule({
  declarations: [ProfileComponent, ChangeEmailComponent, SettingsComponent, EditPictureComponent],
  imports: [
    CommonModule,
    RouterModule,
    FormsModule,
    NgbModule,
    ReactiveFormsModule,
    ImageCropperModule
  ],
  exports: [
    ProfileComponent
  ]
})
export class UserModule { }