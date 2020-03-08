import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from './base.service';
import { config } from '../config';
import { User } from '../models/user';

@Injectable({
  providedIn: 'root'
})
export class UserService extends BaseService {
  
  constructor(private http: HttpClient) {
    super();
  }

  getUser(id: string) {
    return this.http.get<User>(`${config.apiUrl}user/${id}`);
  }
}
