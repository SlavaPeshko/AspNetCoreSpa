import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from './base.service';
import { config } from '../config';
import { User } from '../models/user';

@Injectable({
  providedIn: 'root'
})
export class UserService extends BaseService<User> {
  
  constructor(httpClient: HttpClient) {
    super(
      httpClient,
      config.apiUrl,
      config.endpoint.user.route);
  }

  changeEmail(id: number, oldEmail: string, newEmail: string) {
    const body = JSON.stringify({oldEmail, newEmail});
    return this._httpClient.put(`${config.apiUrl}/${config.endpoint.user.changeEmail(id)}`, body, this.httpOptions);
  }

  getUser(id: string) {
    return this._httpClient.get<User>(`${config.apiUrl}user/${id}`);
  }
}
