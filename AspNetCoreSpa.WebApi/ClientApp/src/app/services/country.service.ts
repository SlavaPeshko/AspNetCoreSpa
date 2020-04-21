import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from './base.service';
import { config } from '../config';
import { Country } from '../models/country';

@Injectable({
  providedIn: 'root'
})
export class CountryService extends BaseService<Country> {
  
  constructor(httpClient: HttpClient) {
    super(httpClient,
      config.apiUrl,
      config.endpoint.countries.route);
  }
}
