import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from './base.service';
import { HttpHeaders } from '@angular/common/http';
import { config } from '../config';
import { Tokens } from '../models/tokens';

@Injectable({
  providedIn: 'root'
})
export class AuthService extends BaseService {
  
  private readonly JWT_TOKEN = 'jwt';
  private readonly REFRESH_TOKEN = 're_jwt';

  constructor(private http: HttpClient) {
    super();
  }

  login(body: any) {
    const headers = new HttpHeaders()
      .set('Content-Type', 'application/json')
      .set('Accept', 'application/json');
    return this.http.post(`${config.apiUrl}user/login`, body, { headers })
      .subscribe(response => {
        let accessToken = (<any>response).accessToken;
        let token = accessToken.token;
        let refreshToken = (<any>response).rerfreshToken;
        this.storeTokens({ jwt: token, refreshToken: refreshToken });

        // this.invalidLogin = false;
        // this.router.navigate(["/"]);
      }, err => {
        // this.invalidLogin = true;
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
