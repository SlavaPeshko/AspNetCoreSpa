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

const routes: Routes = [
  { path: '', redirectTo: '/login', pathMatch: 'full' },
  { path: 'login', component: LoginComponent },
  // { path: 'restore', component: ForgotComponent, canActivate: [AuthGuard] },
  { path: 'restore', component: ForgotComponent },
  { path: 'register', component: SignUpComponent },
  { path: 'profile', component: ProfileComponent, canActivate: [AuthGuard] },
  { path: 'create-post', component: CreatePostComponent, canActivate: [AuthGuard] },
  { path: 'posts', component: PostsComponent },
  { path: 'emailchange', component: ChangeEmailComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
