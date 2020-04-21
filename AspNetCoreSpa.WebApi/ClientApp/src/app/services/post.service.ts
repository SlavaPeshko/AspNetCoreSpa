import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from './base.service';
import { config } from '../config';
import { Observable } from 'rxjs';
import { Post } from '../models/post';

@Injectable({
  providedIn: 'root'
})
export class PostService extends BaseService<any> {
  
  constructor(httpClient: HttpClient) {
    super(
      httpClient,
      config.apiUrl,
      config.endpoint.posts.route);
  }

  public getByPageItems(page: number, items: number): Observable<Post[]> {
    return this._httpClient.get<Post[]>(`${this._url}/${this._endpoint}/${page}/${items}`);
  }
}
