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

  // getUser(id: string) {
  //   return this.http.get<User>(`${config.apiUrl}user/${id}`);
  // }

  // postUser(user: User, id: string) {

  //   const headers = new HttpHeaders()
  //     .set('Content-Type', 'application/json')
  //     .set('Accept', 'application/json');

  //   return this.http.post<any>(`${config.apiUrl}user/${id}`, user, { headers });
  // }
}
