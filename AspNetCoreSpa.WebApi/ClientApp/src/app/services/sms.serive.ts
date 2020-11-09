import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from './base.service';
import { config } from '../config';
import { Observable } from 'rxjs';
import { PhoneNumber } from '../models/phoneNumber';

@Injectable({
  providedIn: 'root'
})
export class SmsService extends BaseService<any> {
  
  constructor(httpClient: HttpClient) {
    super(
      httpClient,
      config.apiUrl,
      config.endpoint.sms.route);
  }

  public sendSms(phoneNumber: PhoneNumber): Observable<any> {
    const url = `${this.Url}/${config.endpoint.sms.sendSms}`;

    return this.HttpClient.post<any>(url, phoneNumber, this.httpOptions);
  }
}