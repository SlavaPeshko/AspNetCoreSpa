import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from './base.service';
import { config } from '../config';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthService extends BaseService<any> {
  
  private readonly JWT_TOKEN = 'jwt';
  private readonly REFRESH_TOKEN = 're_jwt';

  constructor(HttpClient: HttpClient,  
    private router: Router) {
    super(HttpClient,
      config.apiUrl,
      config.endpoint.user.login);
  }

  login(body: any) {

    return this.create(body)
      .subscribe(response => {
        this.storeTokens(response);

        this.router.navigate(['/profile']);
      });
  }

  refreshToke() {
    const body = { accessToken: this.getJwtToken(), refreshToken: this.getRefreshToken() };

    return this.HttpClient.post(`${config.apiUrl}/${config.endpoint.tokens.refreshToken}`, JSON.stringify(body), this.httpOptions)
    .subscribe(response => {
      this.storeTokens(response);

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

  private storeTokens(response: any) {
    let accessToken = (<any>response).accessToken;
    let token = accessToken.token;
    let refreshToken = (<any>response).refreshToken;
    localStorage.setItem(this.JWT_TOKEN, token);
    localStorage.setItem(this.REFRESH_TOKEN, refreshToken);
  }

  private removeTokens() {
    localStorage.removeItem(this.JWT_TOKEN);
    localStorage.removeItem(this.REFRESH_TOKEN);
  }
}
