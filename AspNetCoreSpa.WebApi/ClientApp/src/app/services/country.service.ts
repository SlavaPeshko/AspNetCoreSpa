import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from './base.service';
import { config } from '../config';
import { Country } from '../models/country';

@Injectable({
  providedIn: 'root'
})
export class CountryService extends BaseService {
  
  constructor(private http: HttpClient) {
    super();
  }

  getCountries() {
    return this.http.get<Country[]>(`${config.apiUrl}countries`);
  }
}
