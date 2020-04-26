import { Injectable } from '@angular/core';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { BaseService } from './base.service';
import { config } from '../config';
import { Observable } from 'rxjs';
import { Like } from '../models/like';

@Injectable({
  providedIn: 'root'
})
export class LikeService extends BaseService<Like> {
  
  constructor(httpClient: HttpClient) {
    super(
      httpClient,
      config.apiUrl,
      config.endpoint.posts.route);
  }

  public createLike(postId: number, isLike: boolean): Observable<number> {

    const url = `${this._url}/${config.endpoint.posts.createLike(postId)}`;

    return this._httpClient.post<number>(url, { isLike }, this.httpOptions);
  }
}
