import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from './base.service';
import { catchError } from 'rxjs/operators';
import { throws } from 'assert';
import { HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class AuthService extends BaseService {

  constructor(private http: HttpClient) {
    super();
  }

  public login(body: any) {
    debugger;
    const headers = new HttpHeaders()
      .set('Content-Type', 'application/json')
      .set('Accept', 'application/json');
    return this.http.post('http://localhost:5000/api/user/login', body, { headers })
    .subscribe(result => console.log(result));
  }
}
