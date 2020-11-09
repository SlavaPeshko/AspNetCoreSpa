import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from "./auth/login/login.component";
import { ForgotComponent } from "./auth/forgot/forgot.component";
import { SignUpComponent } from "./auth/sign-up/sign-up.component";
import { AuthGuard } from './guards/CanActivate';
import { ProfileComponent } from './user/profile/profile.component';
import { CreatePostComponent } from './post/create-post/create-post.component';
import { PostsComponent } from './post/posts/posts.component';
import { ChangeEmailComponent } from './user/change-email/change-email.component';
import { SettingsComponent } from './user/settings/settings.component';
import { EditPictureComponent } from './user/edit-picture/edit-picture.component';
import { PhoneForgotComponent } from './auth/phone-forgot/phone-forgot.component';

const routes: Routes = [
  { path: '', redirectTo: '/login', pathMatch: 'full' },
  { path: 'login', component: LoginComponent },
  // { path: 'restore', component: ForgotComponent, canActivate: [AuthGuard] },
  { path: 'resetpassword', component: ForgotComponent },
  { path: 'phoneresetpassword', component: PhoneForgotComponent },
  { path: 'register', component: SignUpComponent },
  { path: 'profile', component: ProfileComponent, canActivate: [AuthGuard] },

  { path: 'profile/edit-picture', component: EditPictureComponent, canActivate: [AuthGuard] },

  { path: 'create-post', component: CreatePostComponent, canActivate: [AuthGuard] },
  { path: 'posts', component: PostsComponent },
  { path: 'emailchange', component: ChangeEmailComponent },
  { path: 'settings', component: SettingsComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
