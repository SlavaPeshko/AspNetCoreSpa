import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AuthModule } from './auth/auth.module';
import { ComponentModule } from './component/component.module';
import { HttpClientModule, HTTP_INTERCEPTORS  } from '@angular/common/http';
import { AuthGuard } from './guards/CanActivate';
import { JwtInterceptor } from './helpers/jwt.interceptor';
import { UserModule } from './user/user.module';
import { PostModule } from './post/post.module';
import { ToastrModule } from 'ngx-toastr';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ErrorIntercept } from './helpers/error.interceptor';
import { SpinnerHttpInterceptor } from './helpers/http.interceptor';

import { JwtModule } from "@auth0/angular-jwt";
import { FileService } from './services/file.service';
import { CheckPasswordsValidatorDirective } from './shared/check-password.directive';

export function tokenGetter() {
  return localStorage.getItem("jwt");
}

@NgModule({
  declarations: [
    AppComponent,
    CheckPasswordsValidatorDirective
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    AuthModule,
    FormsModule,
    ComponentModule,
    HttpClientModule,
    UserModule,
    PostModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot({
      timeOut: 5000,
      positionClass: 'toast-top-right',
      preventDuplicates: true,
    }),
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        whitelistedDomains: ["localhost:5000"],
        blacklistedRoutes: []
      }
    })
  ],
  providers: [AuthGuard, 
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ErrorIntercept, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: SpinnerHttpInterceptor, multi: true },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
