import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from './base.service';
import { config } from '../config';
import { Tokens } from '../models/tokens';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthService extends BaseService<any> {
  
  private readonly JWT_TOKEN = 'jwt';
  private readonly REFRESH_TOKEN = 're_jwt';

  constructor(httpClient: HttpClient,  
    private router: Router) {
    super(httpClient,
      config.apiUrl,
      config.endpoint.login,);
  }

  login(body: any) {

    return this.create(body)
      .subscribe(response => {
        let accessToken = (<any>response).accessToken;
        let token = accessToken.token;
        let refreshToken = (<any>response).rerfreshToken;
        this.storeTokens({ jwt: token, refreshToken: refreshToken });

        this.router.navigate(['/profile']);
      });
  }

  logout(){
    this.removeTokens();
  }

  isLoggedIn() {
    return !!this.getJwtToken();
  }

  private getJwtToken() {
    return localStorage.getItem(this.JWT_TOKEN);
  }

  private getRefreshToken() {
    return localStorage.getItem(this.REFRESH_TOKEN);
  }

  private storeJwtToken(jwt: string) {
    localStorage.setItem(this.JWT_TOKEN, jwt);
  }

  private storeTokens(tokens: Tokens) {
    localStorage.setItem(this.JWT_TOKEN, tokens.jwt);
    localStorage.setItem(this.REFRESH_TOKEN, tokens.refreshToken);
  }

  private removeTokens() {
    localStorage.removeItem(this.JWT_TOKEN);
    localStorage.removeItem(this.REFRESH_TOKEN);
  }
}
